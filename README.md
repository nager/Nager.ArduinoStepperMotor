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

### Project 1

Quantity | Product | 
--- | --- | 
1x | [Akozon Automatische Kugelumlaufspindel Linearer CNC-Schlitten](https://amzn.to/2uOP0eR) |
1x | [PChero Mechanische Endschalter mit LED Indikator](https://amzn.to/2UIAZh4) |
1x | [Quimat Arduino CNC Steuerung Kit mit Schrittmotor](https://amzn.to/2I4SG4M) |

### Project 2

Quantity | Product | 
--- | --- | 
1x | [A4988 Schrittmotor Treiber Control Expansion Board](https://amzn.to/2X9j6cO) |
1x | [UEETEK 4 Stück 1M Schrittmotor Kabel Bleidraht HX2.54 4-polig bis 6-polig](https://amzn.to/31w3uz7) |
1x | [Usongshine Schrittmotor Nema 17 1.5A 17HS4401S](https://amzn.to/2KO4jO8) |

![Fritzing](doc/TestUI.png)
