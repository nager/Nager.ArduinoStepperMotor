namespace Nager.ArduinoStepperMotor.TestUI.Model
{
    public class MotorSpeedRamp
    {
        public int Index { get; set; }
        public double Sleep { get; set; }

        public MotorSpeedRamp(int index, double sleep)
        {
            this.Index = index;
            this.Sleep = sleep;
        }
    }
}
