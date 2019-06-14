int motorDriverActivePin = 7;
int stepPin = 5;
int directionPin = 6;

int onTime = 0;

String command = "";

#define RAMP_STEPS 256
#define TIMERTICKS_PER_US 1

volatile unsigned int ramp[RAMP_STEPS];
volatile byte rampIndex = 0;
volatile int speed = 0;
volatile unsigned int steps = 0;
volatile byte direction = 0;

void setup() {
  Serial.setTimeout(50);
  Serial.begin(115200);

  pinMode(motorDriverActivePin, OUTPUT); // Enable
  pinMode(stepPin, OUTPUT); // Step
  pinMode(directionPin, OUTPUT); // Richtung

  digitalWrite(directionPin, LOW);
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

  caculateAccel(3000, 1, 0.6);
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

ISR(TIMER1_OVF_vect)
{
  TCNT1 = 65536; // Zähler erneut vorbelegen

  if (rampIndex > 0)
  {
    onTime = ramp[rampIndex];
    TCNT1 = 65536 - onTime;

    //http://profhof.com/arduino-port-manipulation/
    //https://www.peterbeard.co/blog/post/why-is-arduino-digitalwrite-so-slow/
    digitalWrite(stepPin, HIGH);
    digitalWrite(stepPin, LOW);

    //stepPin = 5
    //PORTD |= B00001000;
    //PORTD &= B11110111;
    //PORTD = B00001000;
    //PORTD = B00000000;

    if (direction == 1)
    {
      steps++;
    }
    else {
      steps--;
    }

  }
  
  int index = abs(speed);
  if (index > rampIndex)
  {
    rampIndex++;
  }
  else if (index < rampIndex)
  {
    rampIndex--;
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

  //Serial.println(steps);
  //Serial.println(rampIndex);

  if (Serial.available() > 0) {
    //Serial.println("read data");
    command = Serial.readStringUntil('\n');
    //Serial.println(command);

    if (command.startsWith("speed")) {
      //Serial.println(command.substring(6));
      speed = command.substring(6).toInt();
      if (speed < -255 || speed > 255 )
      {
        speed = 0;
      }
    }
  }

  if (speed == 0)
  {
    //Disable stepper driver
    digitalWrite(motorDriverActivePin, HIGH);
  }
  else
  {
    //Enable stepper driver
    digitalWrite(motorDriverActivePin, LOW);
  }

  if (rampIndex < 5)
  {
    if (speed > 0 && direction == 0)
    {
      Serial.println("Change direction 1");
      direction = 1;
      digitalWrite(directionPin, HIGH);
      //digitalWrite(directionPin, LOW);
    }
    else if (speed < 0 && direction == 1)
    {
      Serial.println("Change direction 0");
      direction = 0;
      digitalWrite(directionPin, LOW);
      //digitalWrite(directionPin, HIGH);
    }
  }

  if (steps > 8900 && direction == 1)
  {
    rampIndex = 0;
    speed = 0;
    return;

    //digitalWrite(motorDriverActivePin, HIGH);
  }

  if (steps < 100 && direction == 0)
  {
    rampIndex = 0;
    speed = 0;
    return;

    //digitalWrite(motorDriverActivePin, HIGH);
  }


  delayMicroseconds(50);
}

bool leftLimitReached() {
  if (steps > 40000 && direction == 1)
  {
    return true;
  }

  return false;
}
