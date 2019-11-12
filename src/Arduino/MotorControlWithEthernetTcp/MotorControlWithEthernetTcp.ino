#include <SPI.h>
#include <Ethernet.h>

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = { 0x06, 0x47, 0x3B, 0xA8, 0xF0, 0x9B };
IPAddress ip(192, 168 ,184, 65); //<<< ENTER YOUR IP ADDRESS HERE!!!

enum movementDirections {
  MOVEMENT_LEFT,
  MOVEMENT_RIGHT
};

int motorDriverActivePin = 7;
int stepPin = 5;
int directionPin = 6;

//Endstop configuration
bool endstopEnable = true;
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

EthernetServer TcpServer = EthernetServer(23);
EthernetClient client;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  Ethernet.begin(mac, ip);
  TcpServer.begin();

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

  //TCCR1B |= (1 << CS10);    // 4.1ms (No Prescale)
  TCCR1B |= (1 << CS11);    // 32.8ms (Prescale = 8)
  //TCCR1B |= (1 << CS12);    // 1049.6ms (Prescale = 256)
 
  TIMSK1 |= (1 << TOIE1);   // enable Timer1 overflow interrupt
  interrupts();             // enable all interrupts

  //caculateAccel(3000, 1, 0.6);
  //US-17HS4401S
  caculateAccel(1600, 1, 0.25);
  //caculateAccel(1500, 1, 0.6);
  //caculateAccel(300, 1, 0.2);

  //17HS13-0404S + A4988
  //caculateAccel(100, 200, 0.05);

  initialize();
  trinamicAutomaticTuning();
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
    if (motorSpeed > rampIndex) {
      rampIndex++;
    } else if (motorSpeed < rampIndex) {
      rampIndex--;
    }
  }
}

void loop() {

  int limitLeft = checkLeftLimit();
  int limitRight = checkRightLimit();

  if (!client) {
    client = TcpServer.available();
  }

  if (client) {
    if (client.connected()) {
      
      if (client.available()) {
        char dst[4];
        dst[0] = client.read();
        dst[1] = client.read();
        dst[2] = client.read();
        dst[3] = client.read();
        int nextSpeed = String(dst).toInt();
        if (nextSpeed > 0) {
          Serial.println("MOVEMENT_RIGHT");
          Serial.println(nextSpeed);
          nextMovementDirection = MOVEMENT_RIGHT;
          motorSpeed = abs(nextSpeed);
        } else {
          Serial.println("MOVEMENT_LEFT");
          Serial.println(nextSpeed);
          nextMovementDirection = MOVEMENT_LEFT;
          motorSpeed = abs(nextSpeed);
        }
      }
    } else {
      client.stop();
    }
  }
  
  commandProcessing();
  checkEndstops();

  //if (counter == 20000) {
  if (counter == 250) {
    Serial.println((String)"{ \"limitLeft\":" + limitLeft +  ", \"limitRight\":" + limitRight + ", \"motorSpeed\":" + motorSpeed + " }");
    counter = 0;
  }

  if (counter == 100) {
    if (client) {
      client.println((String) limitLeft +  ";" + limitRight + ";" + motorSpeed);
    }
  }

  delayMicroseconds(50);
  counter++;
}

void initialize() {
  steps = 2147483647;

  if (endstopEnable) {
    
    //Disable Limits
    limitActive = false;
  
    //Drive to right end position 
    for (int i = 1; i < 2000; i++) {
      motorSpeed = 1;
      if (digitalRead(endstopRightPin) == 0) {
        motorSpeed = 0;
        delay(1000);
        break;
      }
      delay(20);
    }
    motorSpeed = 0;
    limitRight = steps + 200;
  
    nextMovementDirection = MOVEMENT_LEFT;
  
    //Drive to left end position 
    for (int i = 1; i < 2000; i++) {
      motorSpeed = 1;
      if (digitalRead(endstopLeftPin) == 0) {
        motorSpeed = 0;
        delay(1000);
        break;
      }
      delay(20);
    }
    motorSpeed = 0;
    limitLeft = steps - 200;
  
    //Activate limits
    limitActive = true;
  }

    //Move away from limit
  nextMovementDirection = MOVEMENT_RIGHT;
  motorSpeed = 1;
  delay(500);
  motorSpeed = 0;
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
  if (endstopEnable) {
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
      digitalWrite(stepPin, HIGH);
      digitalWrite(stepPin, LOW);
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
      int index = command.substring(8,11).toInt();
      int value = command.substring(11,16).toInt();
      ramp[index] = value;
    }
  }
}

int checkLeftLimit() {
  if (!limitActive) {
    return -1;
  }

  long distance = limitLeft - steps;

  if (nextMovementDirection == MOVEMENT_LEFT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_LEFT && distance <= 0 && rampIndex != 0) {
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

  if (nextMovementDirection == MOVEMENT_RIGHT && distance < 400 && motorSpeed > 2) {
    int reduceSpeed = ceil(motorSpeed / 10.0);
    motorSpeed = motorSpeed - reduceSpeed;
  }

  if (movementDirection == MOVEMENT_RIGHT && distance <= 0 && rampIndex != 0) {
    rampIndex = 0;
    motorSpeed = 0;
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
