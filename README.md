# Nager.ArduinoStepperMotor
Control a stepper motor over C#



![Fritzing](doc/ConnectionDiagram.png)

## Serial Commands (Baudrate 115200)

Command | Description | 
--- | --- | 
`start` | Enable the motor driver, the motor has voltage
`stop` | Disable the motor driver, the motor has no voltage
`move=500` | Move the motor for 500 steps
`speed=200` | Change the rpm (rotation per minute) to the new value

## Required Hardware

Quantity | Product | 
--- | --- | 
1x | [Akozon Automatische Kugelumlaufspindel Linearer CNC-Schlitten](https://amzn.to/2uOP0eR) |
1x | [PChero Mechanische Endschalter mit LED Indikator](https://amzn.to/2UIAZh4) |
1x | [Quimat Arduino CNC Steuerung Kit mit Schrittmotor](https://amzn.to/2I4SG4M) |
