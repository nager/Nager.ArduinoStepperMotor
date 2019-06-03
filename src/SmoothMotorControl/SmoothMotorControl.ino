int motorDriverActivePin = 6;
int stepPin = 5;
int directionPin = 4;

int onTime = 0;

String command = "";

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  pinMode(motorDriverActivePin, OUTPUT); // Enable
  pinMode(stepPin, OUTPUT); // Step
  pinMode(directionPin, OUTPUT); // Richtung

  digitalWrite(directionPin, HIGH);
  digitalWrite(motorDriverActivePin, HIGH);

  //https://www.heise.de/developer/artikel/Timer-Counter-und-Interrupts-3273309.html
  noInterrupts();           // Alle Interrupts temporär abschalten
  TCCR1A = 0;               // set entire TCCR1A register to 0
  TCCR1B = 0;               // set entire TCCR1B register to 0

  TCNT1 = 65534;
  //TCNT1 = 0;            // Timer nach obiger Rechnung vorbelegen
  TCCR1B |= (1 << CS11);    // 0.5us
  TIMSK1 |= (1 << TOIE1);   // enable Timer1 overflow interrupt:
  interrupts();             // alle Interrupts scharf schalten

  caculateAccel(2000, 1, 0.7);
}

#define RAMP_STEPS 256
#define TIMERTICKS_PER_US 1

volatile unsigned int ramp[RAMP_STEPS];
volatile byte rampIndex = 0;
volatile unsigned int speed = 0;

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

ISR(TIMER1_OVF_vect)
{
  TCNT1 = 65536;
  //TCNT1 = 34286;             // Zähler erneut vorbelegen

  if (rampIndex > 0)
  {
    onTime = ramp[rampIndex];
    TCNT1 = 65536 - onTime;

    digitalWrite(stepPin, HIGH);
    digitalWrite(stepPin, LOW);
  }
}

void loop() {
  //Serial.print(rampIndex);
  //Serial.print(" ");
  //Serial.print(rampIndex1);
  //Serial.print(" ");
  //onTime = ramp[rampIndex];
  //Serial.print(onTime);
  //Serial.print("\n");
  //Serial.println("Check commands");

  if (Serial.available() > 0) {
    //Serial.println("read data");
    command = Serial.readStringUntil('\n');
    //Serial.println(command);

    if (command.startsWith("speed")) {
      //Serial.println(command.substring(6));
      speed = command.substring(6).toInt();

      if (speed == 0)
      {
        digitalWrite(motorDriverActivePin, HIGH);
      }
      else
      {
        digitalWrite(motorDriverActivePin, LOW);
      }
      return;
    }

    if (speed <= 1)
    {
      if (command.startsWith("left")) {
        digitalWrite(directionPin, LOW);
        return;
      }

      if (command.startsWith("right")) {
        digitalWrite(directionPin, HIGH);
        return;
      }
    }
  }

  if (speed < 255)
  {
    if (speed > rampIndex)
    {
      rampIndex++;
    }
    else if (speed < rampIndex)
    {
      rampIndex--;
    }
  }

  delayMicroseconds(100);
}
