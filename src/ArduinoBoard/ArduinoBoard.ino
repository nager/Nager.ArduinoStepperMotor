#include <Arduino.h>
#include "A4988.h"

#define MOTOR_STEPS 200
// Microstepping mode. If you hardwired it to save pins, set to the same value here.
#define MICROSTEPS 4
//#define MICROSTEPS 1
// Target RPM for cruise speed
#define RPM 150

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
int Led = 13 ;// define LED Interface

int pin9 = 0;
int pin10 = 0;
int pin11 = 0;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);
  Serial.println("Starting");

  pinMode (Led, OUTPUT) ;// define LED as output interface
  
  //stepper.begin(RPM, MICROSTEPS);
  //stepper.begin(200, MICROSTEPS);
  stepper.begin(RPM, MICROSTEPS);
  stepper.setEnableActiveState(LOW); //important if stepper.disable not work
  stepper.enable();
  stepper.rotate(100);
  delay(100);
  stepper.rotate(-100);

  //stepper.setSpeedProfile(stepper.CONSTANT_SPEED, 300, 300);
  //stepper.setSpeedProfile(stepper.LINEAR_SPEED, 300, 300);

  stepper.disable();

  Serial.println("Ready");
  
  //pinMode(2, OUTPUT); //Movement, Steps
  //pinMode(5, OUTPUT); //Direction
  //pinMode(8, OUTPUT); //Motor

  pinMode(11, INPUT_PULLUP); //
  pinMode(10, INPUT_PULLUP); //
  pinMode(9, INPUT_PULLUP); //
}

void loop() {


  pin9 = digitalRead(9);
  pin10 = digitalRead(10);
  pin11 = digitalRead(11);

  if (pin9 == 0) {
    stepper.stop();
  }

/*
  Serial.print(pin9,HEX);
  Serial.print(pin10,HEX);
  Serial.print(pin11,HEX);
  Serial.println();
*/

  if (pin10 == 0) {
    stepper.enable();
    stepper.startMove(10000);
  }

  if (pin11 == 0) {
    stepper.enable();
    stepper.startMove(-10000);
  }
  
  wait_time_micros = stepper.nextAction();
  if (wait_time_micros > 0) {
    //Serial.println(wait_time_micros);
    //Serial.println(stepper.getSteps());
  }
  if (wait_time_micros == 0) {
    stepper.disable();
  }

  if (Serial.available() > 0) {
    command = Serial.readString();
    if (command == "start") {
      Serial.println("enable stepper");
      stepper.enable();
      digitalWrite (Led, HIGH);
    }
    if (command == "stop") {
      Serial.println("disable stepper");
      stepper.stop();
      stepper.disable();
      digitalWrite (Led, LOW);
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