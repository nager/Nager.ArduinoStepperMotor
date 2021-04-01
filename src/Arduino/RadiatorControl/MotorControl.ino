const unsigned long ULONG_MAX = 0UL - 1UL;

enum movementDirections {
  MOVEMENT_LEFT,
  MOVEMENT_RIGHT
};

//Motor driver configuration
int motorDriverStepPin = 5;
int motorDriverDirectionPin = 6;
int motorDriverActivePin = 7;

//Endstop configuration
bool endstopRightAvailable = true;
int endstopRightPin = 2;
bool endstopLeftAvailable = false;
int endstopLeftPin = 3;

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
volatile unsigned long steps = ULONG_MAX / 2;
volatile enum movementDirections movementDirection = MOVEMENT_RIGHT;
volatile enum movementDirections nextMovementDirection = MOVEMENT_RIGHT;

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

    if (movementDirection == MOVEMENT_RIGHT) {
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

void motorControlSetup() {
  pinMode(motorDriverActivePin, OUTPUT); // Motor Driver Active
  pinMode(motorDriverStepPin, OUTPUT); // Motor Driver Step
  pinMode(motorDriverDirectionPin, OUTPUT); // Motor Driver Direction

  if (endstopRightAvailable) {
    pinMode(endstopRightPin, INPUT); // Endstop Right
  }

  if (endstopLeftAvailable) {
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
  
  //last config
  //caculateAccel(1500, 1, 0.6);
  //test config
  caculateAccel(6000, 3, 0.1);
  
  //caculateAccel(3000, 1, 0.2);
  //caculateAccel(300, 1, 0.2);

  //17HS13-0404S + A4988
  //caculateAccel(100, 200, 0.05);

  motorInitialize();
  //trinamicAutomaticTuning();
}

void motorInitialize() {
  if (endstopRightAvailable || endstopLeftAvailable) {
    calibrateLimitViaEndstops();
  } else {
    setLimitRight(ULONG_MAX);
    setLimitLeft(0);
    steps = ULONG_MAX / 2;
  }

  motorCheck();
}

void motorCheck() {
  int motorMovementSteps = 5;
  
  for (int i = 0; i <= motorMovementSteps; i++) {
    moveOneStep();
  }

  nextMovementDirection = MOVEMENT_LEFT;
  delay(100);

  for (int i = 0; i <= motorMovementSteps; i++) {
    moveOneStep();
  }

  nextMovementDirection = MOVEMENT_RIGHT;
}

void calibrateLimitViaEndstop(int endstopPin) {
  for (int i = 1; i < 2000; i++) {
    motorSpeed = 1;
    Serial.println(digitalRead(endstopPin));
    if (digitalRead(endstopPin) == 0) {
      motorSpeed = 0;
      delay(1000);
      break;
    }
    delay(20);
  }
  motorSpeed = 0;
}

void calibrateLimitViaEndstops() {
  int paddingEndstop = 50;

  Serial.println("Calibration start");

  //Disable Limits
  limitActive = false;

  if (endstopRightAvailable) {

    nextMovementDirection = MOVEMENT_RIGHT;

    calibrateLimitViaEndstop(endstopRightPin);

    //Move away from limit
    nextMovementDirection = MOVEMENT_LEFT;
    for (int i = 0; i < paddingEndstop * 8; i++) {
      moveOneStep();
      delay(10);
    }

    setLimitRight(steps);
    Serial.println("End position reached for right endstop");
    Serial.println(limitRight);
  }
  else {
    setLimitRight(ULONG_MAX);
  }

  if (endstopLeftAvailable) {

    //Switch direction
    nextMovementDirection = MOVEMENT_LEFT;

    calibrateLimitViaEndstop(endstopLeftPin);
    setLimitLeft(steps + paddingEndstop);
    Serial.println("End position reached for left endstop");
    Serial.println(limitLeft);

    //Move away from limit
    nextMovementDirection = MOVEMENT_RIGHT;
    for (int i = 0; i < paddingEndstop * 8; i++) {
      moveOneStep();
      delay(10);
    }
  }
  else {
    setLimitLeft(0);
  }

  Serial.println("Calibration done");

  nextMovementDirection = MOVEMENT_RIGHT;

  Serial.println("Move away done");

  delay(1000);

  //Activate limits
  limitActive = true;
}

void setLimitLeft(unsigned long limit) {
  limitLeft = limit;
}

void setLimitRight(unsigned long limit) {
  limitRight = limit;
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
  if (endstopRightAvailable) {
    if (digitalRead(endstopRightPin) == 0) {
      digitalWrite(motorDriverActivePin, HIGH);
    }
  }
  if (endstopLeftAvailable) {
    if (digitalRead(endstopLeftPin) == 0) {
      digitalWrite(motorDriverActivePin, HIGH);
    }
  }
}

void setMotorSpeed(int speed) {
  //Check speed is higher as max
  if (abs(speed) > RAMP_STEPS) {
    motorSpeed = 0;
    return;
  }

  if (speed > 0) {
    nextMovementDirection = MOVEMENT_RIGHT;
  } else if (speed < 0) {
    nextMovementDirection = MOVEMENT_LEFT;
  }

  motorSpeed = abs(speed);
}

int getMotorSpeed() {
  return motorSpeed;
}

void commandProcessing() {
  if (Serial.available() > 0) {
    command = Serial.readStringUntil('\n');

    if (command.startsWith("speed")) {
      int nextSpeed = command.substring(6).toInt();
      setMotorSpeed(nextSpeed);
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
      setLimitLeft(steps);
      return;
    }

    if (command.equals("setlimitright")) {
      setLimitRight(steps);
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

unsigned long getCurrentPosition() {
  return steps;
}

unsigned long checkLeftLimit() {
  if (!limitActive) {
    return ULONG_MAX;
  }

  unsigned long distance = steps - limitLeft;

  if (movementDirection == MOVEMENT_LEFT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_LEFT && distance <= 0) {
    rampIndex = 0;
  }

  return distance;
}

unsigned long checkRightLimit() {
  if (!limitActive) {
    return ULONG_MAX;
  }

  unsigned long distance = limitRight - steps;

  if (movementDirection == MOVEMENT_RIGHT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_RIGHT && distance <= 0) {
    rampIndex = 0;
    motorSpeed = 0;
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
