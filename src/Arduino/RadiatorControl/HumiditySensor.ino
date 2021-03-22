#define BME_SCK 13
#define BME_MISO 12
#define BME_MOSI 11
#define BME_CS 10

void humiditySensorSetup() {
  bool status;

  // default settings
  // (you can also pass in a Wire library object like &Wire2)
  status = bme.begin(0x76);
  if (!status) {
    Serial.println("Could not find a valid BME280 sensor, check wiring!");
    while (1);
  }
}
