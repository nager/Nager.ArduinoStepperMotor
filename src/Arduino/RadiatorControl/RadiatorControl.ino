#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

Adafruit_BME280 bme; // I2C

unsigned int loopCounter = 0;
unsigned int loopMessageInterval = 500;

void setup() {
  //Serial configuration
  Serial.setTimeout(50);
  Serial.begin(115200);

  humiditySensorSetup();
  motorControlSetup();
}

void loop() {
  commandProcessing();
  checkEndstops();

  float temperature = 0;

  if (loopCounter == loopMessageInterval) {
    temperature = bme.readTemperature();

    //Serial.println(temperature);
    if (temperature < 20) {
      //moveOneStep();
    }

    Serial.println((String)"{ \"availableStepsLeft\":" + checkLeftLimit() +  ", \"availableStepsRight\":" + checkRightLimit() + ", \"motorSpeed\":" + getMotorSpeed() + " }");
    loopCounter = 0;
  }

  delayMicroseconds(50);
  loopCounter++;
}
