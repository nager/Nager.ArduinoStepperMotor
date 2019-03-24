#include <Arduino.h>
#include "A4988.h"

#define MOTOR_STEPS 200
// Microstepping mode. If you hardwired it to save pins, set to the same value here.
#define MICROSTEPS 16
// Target RPM for cruise speed
#define RPM 120

#define DIR 5
#define STEP 2
#define MS1 8

//https://github.com/laurb9/StepperDriver/blob/master/src/BasicStepperDriver.h
//https://blog.protoneer.co.nz/arduino-cnc-shield-v3-00-assembly-guide/

A4988 stepper(MOTOR_STEPS, DIR, STEP, MS1);

String command = "";
int speed = 0;
int rotate = 0;
unsigned wait_time_micros = 0;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);
  Serial.println("Starting");

  
  //stepper.begin(RPM, MICROSTEPS);
  //stepper.begin(200, MICROSTEPS);
  stepper.begin(RPM, MICROSTEPS);
  stepper.setEnableActiveState(LOW);
  stepper.enable();
  stepper.rotate(100);
  delay(100);
  stepper.rotate(-100);

  stepper.setSpeedProfile(stepper.LINEAR_SPEED, 300, 300);

  stepper.disable();

  Serial.println("Ready");
  
  //pinMode(2, OUTPUT); //Movement, Steps
  //pinMode(5, OUTPUT); //Direction
  //pinMode(8, OUTPUT); //Motor
}

void loop() {
  wait_time_micros = stepper.nextAction();
  if (wait_time_micros > 0) {
    //Serial.println(wait_time_micros);
    //Serial.println(stepper.getSteps());
  }

  if (Serial.available() > 0) {
    command = Serial.readString();
    if (command == "start") {
      Serial.println("enable stepper");
      stepper.enable();
    }
    if (command == "stop") {
      Serial.println("disable stepper");
      stepper.stop();
      stepper.disable();
    }
    if (command.startsWith("move")) {
         
      rotate = command.substring(5).toInt();

      //stepper.startMove(rotate * 15 * 200);
      stepper.startMove(rotate);
      Serial.println(rotate);
    }
    if (command.startsWith("speed")) {
      speed = command.substring(6).toInt();
      stepper.begin(speed, MICROSTEPS);
      Serial.println(speed);
    }
  }
}
