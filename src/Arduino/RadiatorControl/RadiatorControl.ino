#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

Adafruit_BME280 bme; // I2C

unsigned int loopCounter = 0;
unsigned int loopMessageInterval = 500;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  humiditySensorSetup();
  motorControlSetup();
}

void loop() {
  commandProcessing();
  checkEndstops();

  if (bme.readHumidity() > 65) {
    moveOneStep();
  }

  if (loopCounter == loopMessageInterval) {
    Serial.println((String)"{ \"limitLeft\":" + checkLeftLimit() +  ", \"limitRight\":" + checkRightLimit() + ", \"motorSpeed\":" + getMotorSpeed() + " }");
    loopCounter = 0;
  }

  delayMicroseconds(50);
  loopCounter++;
}
