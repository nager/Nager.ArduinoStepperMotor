enum movementDirections {
  MOVEMENT_LEFT,
  MOVEMENT_RIGHT
};

int motorDriverActivePin = 7;
int stepPin = 5;
int directionPin = 6;
int endstopRightPin = 2;
int endstopLeftPin = 3;

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
volatile enum movementDirections nextMovementDirection = MOVEMENT_RIGHT;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  pinMode(motorDriverActivePin, OUTPUT); // Motor Driver Active
  pinMode(stepPin, OUTPUT); // Motor Step
  pinMode(directionPin, OUTPUT); // Motor Direction
  pinMode(endstopRightPin, INPUT); // Endstop

  digitalWrite(directionPin, motorDirection);
  digitalWrite(motorDriverActivePin, LOW);

  //https://www.heise.de/developer/artikel/Timer-Counter-und-Interrupts-3273309.html
  noInterrupts();           // disable all interrupts
  TCCR1A = 0;               // set entire TCCR1A register to 0
  TCCR1B = 0;               // set entire TCCR1B register to 0

  TCNT1 = 65534;
  //TCNT1 = 0;            // Timer nach obiger Rechnung vorbelegen
  TCCR1B |= (1 << CS11);    // 0.5us
  TIMSK1 |= (1 << TOIE1);   // enable Timer1 overflow interrupt
  interrupts();             // enable all interrupts

  //caculateAccel(3000, 1, 0.6);
  caculateAccel(1600, 1, 0.25);
  //caculateAccel(1500, 1, 0.6);

  steps = 2147483647;

  //Disable Limits
  limitActive = false;

  //Drive to right end position 
  for (int i = 1; i < 1000; i++) {
    motorSpeed = 1;
    if (digitalRead(endstopRightPin) == 0) {
      motorSpeed = 0;
      delay(1000);
      break;
    }
    delay(20);
  }
  motorSpeed = 0;
  limitRight = steps + 100;

  nextMovementDirection = MOVEMENT_LEFT;

  //Drive to left end position 
  for (int i = 1; i < 1000; i++) {
    motorSpeed = 1;
    if (digitalRead(endstopLeftPin) == 0) {
      motorSpeed = 0;
      delay(1000);
      break;
    }
    delay(20);
  }
  motorSpeed = 0;
  limitLeft = steps - 100;

  //Activate limits
  limitActive = true;


  //Move away from limit
  nextMovementDirection = MOVEMENT_RIGHT;
  motorSpeed = 1;
  delay(500);
  motorSpeed = 0;


return;
  

  //Trinamic Automatic Tuning TMC2208
  for (int i = 1; i <= 2; i++) {
    nextMovementDirection = MOVEMENT_LEFT;
    motorSpeed = 255;
    delay(1000);
    motorSpeed = 0;
    delay(300); //standstill more than 130ms
    nextMovementDirection = MOVEMENT_RIGHT;
    motorSpeed = 255;
    delay(1000);
    motorSpeed = 0;
    delay(300); //standstill more than 130ms
  }
}

void caculateAccel(int startDelay, int angle, float acceleration) { 
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

  if (movementDirection != nextMovementDirection) {
    //Slow down motor for direction switch
    if (rampIndex > 0) {
      rampIndex--;
    } else {
      switchDirection();
    }
  } else {
    //Change motor motorSpeed to a new ramp position
    int index = motorSpeed;
    if (index > rampIndex) {
      rampIndex++;
    } else if (index < rampIndex) {
      rampIndex--;
    }
  }
}

void loop() {
  commandProcessing();

  if (digitalRead(endstopRightPin) == 0) {
    digitalWrite(motorDriverActivePin, HIGH);
  }

  if (digitalRead(endstopLeftPin) == 0) {
    digitalWrite(motorDriverActivePin, HIGH);
  }

  //if (counter == 20000) {
  if (counter == 500) {
    Serial.println((String)"{ \"limitLeft\":" + checkLeftLimit() +  ", \"limitRight\":" + checkRightLimit() + ", \"motorSpeed\":" + motorSpeed + " }");
    counter = 0;
  }

  delayMicroseconds(50);
  counter++;
}

void commandProcessing() {
  if (Serial.available() > 0) {
    command = Serial.readStringUntil('\n');

    if (command.startsWith("speed")) {
      int nextSpeed = command.substring(6).toInt();

      //Check speed is higher as max
      if (abs(nextSpeed) > RAMP_STEPS) {
        motorSpeed = 0;
        return;
      }

      if (nextSpeed > 0) {
        nextMovementDirection = MOVEMENT_RIGHT;
      } else if (nextSpeed < 0) {
        nextMovementDirection = MOVEMENT_LEFT;
      }

      motorSpeed = abs(nextSpeed);
    }

    if (command.startsWith("enablemotordriver")) {
      digitalWrite(motorDriverActivePin, LOW);
      return;
    }

    if (command.startsWith("disablemotordriver")) {
      digitalWrite(motorDriverActivePin, HIGH);
      return;
    }

    if (command.startsWith("limitenable")) {
      limitActive = true;
      return;
    }

    if (command.startsWith("limitdisable")) {
      limitActive = false;
      return;
    }

    if (command.startsWith("setlimitleft")) {
      limitLeft = steps;
      return;
    }

    if (command.startsWith("setlimitright")) {
      limitRight = steps;
      return;
    }

    if (command.startsWith("ramp")) {
      for (int i = 0; i < RAMP_STEPS; i++)
      {
        Serial.println((String)"Ramp:" + i + ":" + ramp[i]);
      }
    }
  }
}

int checkLeftLimit() {
  if (!limitActive) {
    return -1;
  }

  long distance = limitLeft - steps;

  if (movementDirection == MOVEMENT_LEFT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_LEFT && distance <= 0) {
    rampIndex = 0;
    //motorSpeed = 0;
  }

  return distance;
}

int checkRightLimit() {
  if (!limitActive) {
    return -1;
  }

  long distance = steps - limitRight;

  if (movementDirection == MOVEMENT_RIGHT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_RIGHT && distance <= 0) {
    rampIndex = 0;
    //motorSpeed = 0;
  }

  return distance;
}

void switchDirection() {
  if (movementDirection == nextMovementDirection){
    return;
  }
  
  if (nextMovementDirection == MOVEMENT_LEFT) {
    movementDirection = MOVEMENT_LEFT;
    digitalWrite(directionPin, !motorDirection);
    return;
  }
  
  movementDirection = MOVEMENT_RIGHT;
  digitalWrite(directionPin, motorDirection);
}
