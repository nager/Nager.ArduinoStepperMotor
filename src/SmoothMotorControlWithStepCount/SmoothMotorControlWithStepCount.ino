enum movementDirections {
  MOVEMENT_LEFT,
  MOVEMENT_RIGHT
};

int motorDriverActivePin = 7;
int stepPin = 5;
int directionPin = 6;

unsigned int counter = 0;
int onTime = 0;

String command = "";
bool limitActive = true;
unsigned long limitRight = 0;
unsigned long limitLeft = 0;
int motorDirection = 0; //0 or 1 rotates the motor direction

#define RAMP_STEPS 256
#define TIMERTICKS_PER_US 1

volatile unsigned int ramp[RAMP_STEPS];
volatile byte rampIndex = 0;
volatile int motorSpeed  = 0;
volatile unsigned long steps = 0;
volatile enum movementDirections movementDirection = MOVEMENT_RIGHT;
volatile enum movementDirections movementDirection1 = MOVEMENT_RIGHT;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  pinMode(motorDriverActivePin, OUTPUT); // Motor Driver Active
  pinMode(stepPin, OUTPUT); // Motor Step
  pinMode(directionPin, OUTPUT); // Motor Direction

  digitalWrite(directionPin, LOW);
  //digitalWrite(motorDriverActivePin, HIGH);
  digitalWrite(motorDriverActivePin, LOW);

  //https://www.heise.de/developer/artikel/Timer-Counter-und-Interrupts-3273309.html
  noInterrupts();           // Alle Interrupts temporär abschalten
  TCCR1A = 0;               // set entire TCCR1A register to 0
  TCCR1B = 0;               // set entire TCCR1B register to 0

  TCNT1 = 65534;
  //TCNT1 = 0;            // Timer nach obiger Rechnung vorbelegen
  TCCR1B |= (1 << CS11);    // 0.5us
  TIMSK1 |= (1 << TOIE1);   // enable Timer1 overflow interrupt:
  interrupts();             // alle Interrupts scharf schalten

  caculateAccel(3000, 1, 0.6);
  //caculateAccel(1500, 1, 0.6);

  steps = 2147483647;
  limitRight = steps - 500;
  limitLeft = steps + 500;
}

void caculateAccel(int startDelay, int angle, float acceleration) {
  /*
  uint16_t maxDelay = 2000;
  uint16_t minDelay = 200;
  for(uint16_t i = 0; i < 256; i++)
  {
    ramp[i] = (uint16_t)maxDelay - (uint32_t)((uint32_t)(maxDelay - minDelay) * (uint32_t)i / 256);
  }
  */

  
  float c0 = startDelay * sqrt(2 * angle / acceleration) * 0.67703; // in us
  ramp[0] = c0 * TIMERTICKS_PER_US;
  float d = 0;
  float lastDelay = c0;

  for (int i = 1; i < RAMP_STEPS; i++) {
    d = lastDelay - (2 * lastDelay) / (4 * i + 1);
    ramp[i] = d * TIMERTICKS_PER_US;
    lastDelay = d;
  }
  
}

ISR(TIMER1_OVF_vect) {
  TCNT1 = 65536; // Zähler erneut vorbelegen



  /*
    if (checkLeftLimit() < 600) {
    if (rampIndex > 10) {
      rampIndex--;
    }
    }
    if (checkRightLimit() < 600) {
    if (rampIndex > 10) {
      rampIndex--;
    }
    }
  */

  if (rampIndex > 0) {
    onTime = ramp[rampIndex];
    TCNT1 = 65536 - onTime;

    checkLeftLimit();
    checkRightLimit();
    if (rampIndex == 0) {
      return;
    }

    //http://profhof.com/arduino-port-manipulation/
    //https://www.peterbeard.co/blog/post/why-is-arduino-digitalwrite-so-slow/
    digitalWrite(stepPin, HIGH);
    digitalWrite(stepPin, LOW);

    //stepPin = 5
    //PORTD |= B00001000;
    //PORTD &= B11110111;
    //PORTD = B00001000;
    //PORTD = B00000000;

    if (movementDirection == MOVEMENT_LEFT) {
      steps++;
    } else {
      steps--;
    }
  }

  if (movementDirection != movementDirection1) {
    //Slow down motor for direction switch
    if (rampIndex > 0) {
      rampIndex--;
    } else {
      switchDirection();
      TCNT1 = 65400;
    }
  } else {
    //Change motor motorSpeed to a new ramp position
    int index = abs(motorSpeed);
    if (index > rampIndex) {
      rampIndex++;
    } else if (index < rampIndex) {
      rampIndex--;
    }

    if (rampIndex == 0) {
      //Disable stepper driver
      //digitalWrite(motorDriverActivePin, HIGH);
    } else if (rampIndex == 1) {
      //Enable stepper driver
      //digitalWrite(motorDriverActivePin, LOW);
    }
  }
}

void loop() {
  if (Serial.available() > 0) {
    //Serial.println("read data");
    command = Serial.readStringUntil('\n');
    //Serial.println(command);

    if (command.startsWith("speed")) {
      //Serial.println(command.substring(6));
      motorSpeed = command.substring(6).toInt();
      if (abs(motorSpeed) > RAMP_STEPS) {
        motorSpeed = 0;
      }

      if (motorSpeed > 0) {
        movementDirection1 = MOVEMENT_RIGHT;
      } else if (motorSpeed < 0) {
        movementDirection1 = MOVEMENT_LEFT;
      }
    }

    if (command.startsWith("enablemotordriver")) {
      digitalWrite(motorDriverActivePin, LOW);
    }

    if (command.startsWith("disablemotordriver")) {
      digitalWrite(motorDriverActivePin, HIGH);
    }

    if (command.startsWith("limitenable")) {
      limitActive = true;
    }

    if (command.startsWith("limitdisable")) {
      limitActive = false;
    }

    if (command.startsWith("setlimitleft")) {
      limitLeft = steps;
    }

    if (command.startsWith("setlimitright")) {
      limitRight = steps;
    }
  }

  if (motorSpeed == 0) {


  } else {

  }

  //if (counter == 20000) {
  if (counter == 500) {
    //Serial.println((String)"Steps:" + steps + (String)" Direction:" + movementDirection + (String)" Speed:" + motorSpeed);
    //Serial.println((String)"LimitLeft:" + limitLeft + (String)" " + checkLeftLimit());
    //Serial.println((String)"LimitRight:" + limitRight + (String)" " + checkRightLimit());
    Serial.println((String)"{ \"limitLeft\":" + checkLeftLimit() +  ", \"limitRight\":" + checkRightLimit() + " }");
    counter = 0;
  }

  delayMicroseconds(50);
  counter++;
}

int checkLeftLimit() {
  if (!limitActive) {
    return -1;
  }

  long distance = limitLeft - steps;

  if (movementDirection == MOVEMENT_LEFT && distance <= 0) {
    rampIndex = 0;
    motorSpeed = 0;
  }

  return distance;
}

int checkRightLimit() {
  if (!limitActive) {
    return -1;
  }

  long distance = steps - limitRight;

  if (movementDirection == MOVEMENT_RIGHT && distance <= 0) {
    rampIndex = 0;
    motorSpeed = 0;
  }

  return distance;
}

void switchDirection() {
  if (movementDirection1 == MOVEMENT_LEFT) {
    movementDirection = MOVEMENT_LEFT;
    digitalWrite(directionPin, !motorDirection);
  } else {
    movementDirection = MOVEMENT_RIGHT;
    digitalWrite(directionPin, motorDirection);
  }
}
