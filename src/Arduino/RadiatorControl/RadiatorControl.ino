#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

Adafruit_BME280 bme; // I2C

unsigned int loopCounter = 0;
unsigned int loopMessageInterval = 500;

float desiredTemperature = 23;
float currentTemperature = 0;

void setup() {
  //Serial configuration
  Serial.setTimeout(50);
  Serial.begin(115200);

  humiditySensorSetup();
  motorControlSetup();

  //Set limit for the other direction
  unsigned long currentPosition = getCurrentPosition();
  setLimitLeft(currentPosition - 2000);
}

void loop() {
  commandProcessing();
  checkEndstops();


  if (loopCounter == loopMessageInterval) {
    currentTemperature = bme.readTemperature();

    //Serial.println(temperature);
    if (currentTemperature < desiredTemperature) {
      //Open radiator
      setMotorSpeed(-255);
    } else {
      setMotorSpeed(255);
    }

    Serial.println((String)"{ \"availableStepsLeft\":" + checkLeftLimit() +  ", \"availableStepsRight\":" + checkRightLimit() + ", \"motorSpeed\":" + getMotorSpeed() + " }");
    loopCounter = 0;
  }

  delayMicroseconds(50);
  loopCounter++;
}
