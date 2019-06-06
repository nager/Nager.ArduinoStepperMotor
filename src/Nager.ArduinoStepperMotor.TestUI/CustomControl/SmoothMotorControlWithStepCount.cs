using System;
using System.Threading;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class SmoothMotorControlWithStepCount : UserControl
    {
        public event Action<string> SendCommand;

        public SmoothMotorControlWithStepCount()
        {
            this.InitializeComponent();
            this.textBoxSpeed.Text = "0";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.trackBarSpeed.Value = 0;
            this.trackBarSpeed.Focus();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            var speed = this.trackBarSpeed.Value;
            this.textBoxSpeed.Text = speed.ToString();

            if (speed > 0)
            {
                this.SendCommand?.Invoke("left");
            }
            else
            {
                this.SendCommand?.Invoke("right");
            }

            Thread.Sleep(5);

            this.SendCommand?.Invoke($"speed={speed}");
        }

        private void trackBarSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.trackBarSpeed.Value = 0;
            }
        }
    }
}
