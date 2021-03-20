enum movementDirections {
  MOVEMENT_LEFT,
  MOVEMENT_RIGHT
};

//Motor driver configuration
int motorDriverStepPin = 5;
int motorDriverDirectionPin = 6;
int motorDriverActivePin = 7;

//Endstop configuration
bool twoEndstopsAvailable = false;
int endstopRightPin = 2;
int endstopLeftPin = 3;

unsigned int loopCounter = 0;
unsigned int loopMessageInterval = 500;

bool limitActive = true;
unsigned long limitRight = 0;
unsigned long limitLeft = 0;

String command = "";
int motorDirection = 1; //switch the motor turn (0 or 1)

#define RAMP_STEPS 256
#define TIMERTICKS_PER_US 1

int onTime = 0; //ramp calculation
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
  pinMode(motorDriverStepPin, OUTPUT); // Motor Driver Step
  pinMode(motorDriverDirectionPin, OUTPUT); // Motor Driver Direction

  if (twoEndstopsAvailable) {
    pinMode(endstopRightPin, INPUT); // Endstop Right
    pinMode(endstopLeftPin, INPUT); // Endstop Left
  }

  digitalWrite(motorDriverDirectionPin, motorDirection);
  digitalWrite(motorDriverActivePin, LOW);

  //https://www.heise.de/developer/artikel/Timer-Counter-und-Interrupts-3273309.html
  noInterrupts();           // disable all interrupts
  TCCR1A = 0;               // set entire TCCR1A register to 0
  TCCR1B = 0;               // set entire TCCR1B register to 0

  TCNT1 = 65534;

  //TCCR1B |= (1 << CS10);    // 4.1ms (No Prescale)
  TCCR1B |= (1 << CS11);    // 32.8ms (Prescale = 8)
  //TCCR1B |= (1 << CS12);    // 1049.6ms (Prescale = 256)

  TIMSK1 |= (1 << TOIE1);   // enable Timer1 overflow interrupt
  interrupts();             // enable all interrupts

  //caculateAccel(3000, 1, 0.6);
  //US-17HS4401S
  //caculateAccel(1600, 1, 0.25);
  //caculateAccel(1500, 1, 0.6);
  caculateAccel(3000, 1, 0.2);
  //caculateAccel(300, 1, 0.2);

  //17HS13-0404S + A4988
  //caculateAccel(100, 200, 0.05);

  initialize();
  //trinamicAutomaticTuning();
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
  TCNT1 = 65536;

  if (rampIndex > 0) {
    onTime = ramp[rampIndex];
    TCNT1 = 65536 - onTime;

    checkLeftLimit();
    checkRightLimit();
    if (rampIndex == 0) {
      return;
    }

    digitalWrite(motorDriverStepPin, HIGH);
    digitalWrite(motorDriverStepPin, LOW);

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
    if (motorSpeed > rampIndex) {
      rampIndex++;
    } else if (motorSpeed < rampIndex) {
      rampIndex--;
    }
  }
}

void loop() {
  commandProcessing();
  checkEndstops();

  if (loopCounter == loopMessageInterval) {
    Serial.println((String)"{ \"limitLeft\":" + checkLeftLimit() +  ", \"limitRight\":" + checkRightLimit() + ", \"motorSpeed\":" + motorSpeed + " }");
    loopCounter = 0;
  }

  delayMicroseconds(50);
  loopCounter++;
}

void initialize() {
  steps = 2147483647;

  if (twoEndstopsAvailable) {
    calibrateLimitViaEndstops();
  } else {
    limitRight = -1000;
    limitLeft = 1000;
    steps = 0;
  }

  motorCheck();
}

void motorCheck() {
  for (int i = 0; i <= 10; i++) {
    moveOneStep();
  }

  nextMovementDirection = MOVEMENT_LEFT;
  delay(100);

  for (int i = 0; i <= 10; i++) {
    moveOneStep();
  }

  nextMovementDirection = MOVEMENT_RIGHT;
}

void calibrateLimitViaEndstops()
{
  int paddingEndstop = 100;

  //Disable Limits
  limitActive = false;

  //Drive to right end position
  for (int i = 1; i < 2000; i++) {
    motorSpeed = 1;
    if (digitalRead(endstopRightPin) == 0) {
      Serial.println("right end position reached");
      motorSpeed = 0;
      delay(1000);
      break;
    }
    delay(20);
  }
  motorSpeed = 0;
  limitRight = steps + paddingEndstop;

  //Switch direction
  nextMovementDirection = MOVEMENT_LEFT;

  //Drive to left end position
  for (int i = 1; i < 2000; i++) {
    motorSpeed = 1;
    if (digitalRead(endstopLeftPin) == 0) {
      Serial.println("left end position reached");
      motorSpeed = 0;
      delay(1000);
      break;
    }
    delay(20);
  }
  motorSpeed = 0;
  limitLeft = steps - paddingEndstop;

  nextMovementDirection = MOVEMENT_RIGHT;

  //Move away from limit
  for (int i = 0; i <= 50; i++) {
    moveOneStep();
  }

  //Activate limits
  limitActive = true;
}

void trinamicAutomaticTuning() {
  //Trinamic Automatic Tuning TMC2208
  for (int i = 1; i <= 2; i++) {
    nextMovementDirection = MOVEMENT_LEFT;
    motorSpeed = RAMP_STEPS - 1;
    delay(1000);
    motorSpeed = 0;
    delay(300); //standstill more than 130ms
    nextMovementDirection = MOVEMENT_RIGHT;
    motorSpeed = RAMP_STEPS - 1;
    delay(1000);
    motorSpeed = 0;
    delay(300); //standstill more than 130ms
  }
}

void checkEndstops() {
  if (twoEndstopsAvailable) {
    if (digitalRead(endstopRightPin) == 0) {
      digitalWrite(motorDriverActivePin, HIGH);
    }

    if (digitalRead(endstopLeftPin) == 0) {
      digitalWrite(motorDriverActivePin, HIGH);
    }
  }
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

    if (command.equals("enablemotordriver")) {
      digitalWrite(motorDriverActivePin, LOW);
      return;
    }

    if (command.equals("disablemotordriver")) {
      digitalWrite(motorDriverActivePin, HIGH);
      return;
    }

    if (command.equals("limitenable")) {
      limitActive = true;
      return;
    }

    if (command.equals("limitdisable")) {
      limitActive = false;
      return;
    }

    if (command.equals("setlimitleft")) {
      limitLeft = steps;
      return;
    }

    if (command.equals("setlimitright")) {
      limitRight = steps;
      return;
    }

    if (command.equals("step")) {
      moveOneStep();
      return;
    }

    if (command.equals("ramp")) {
      Serial.print((String)"{ ramp:[");
      for (int i = 0; i < RAMP_STEPS; i++)
      {
        Serial.print((String)"" + ramp[i] + ",");
      }
      Serial.println((String)"] }");
    }

    if (command.startsWith("setramp=")) {
      //setramp=0008000 -> rampIndex 0 -> 8000
      //setramp=0017000 -> rampIndex 1 -> 7000
      //setramp=0026000 -> rampIndex 2 -> 6000
      int index = command.substring(8, 11).toInt();
      int value = command.substring(11, 16).toInt();
      ramp[index] = value;
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
  }

  return distance;
}

void switchDirection() {
  if (movementDirection == nextMovementDirection) {
    return;
  }

  if (nextMovementDirection == MOVEMENT_LEFT) {
    movementDirection = MOVEMENT_LEFT;
    digitalWrite(motorDriverDirectionPin, !motorDirection);
    return;
  }

  movementDirection = MOVEMENT_RIGHT;
  digitalWrite(motorDriverDirectionPin, motorDirection);
}

void moveOneStep() {
  digitalWrite(motorDriverStepPin, HIGH);
  digitalWrite(motorDriverStepPin, LOW);

  if (movementDirection == MOVEMENT_LEFT) {
    steps++;
  } else {
    steps--;
  }
}
