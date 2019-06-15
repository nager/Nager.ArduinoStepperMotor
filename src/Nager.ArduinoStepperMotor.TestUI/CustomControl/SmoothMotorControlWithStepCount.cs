using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class SmoothMotorControlWithStepCount : UserControl
    {
        private Random _random = new Random();
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

            //if (speed > 0)
            //{
            //    this.SendCommand?.Invoke("left");
            //}
            //else
            //{
            //    this.SendCommand?.Invoke("right");
            //}

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

        private async void buttonRandom_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                var randomSpeed = this._random.Next(-255, 255);
                var delay = this._random.Next(10, 400);

                this.trackBarSpeed.Value = randomSpeed;
                await Task.Delay(delay);
            }

            this.trackBarSpeed.Value = -255;
            await Task.Delay(2000);
            this.trackBarSpeed.Value = 0;
        }

        private void buttonLimitEnable_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"limitenable");
        }

        private void buttonLimitDisable_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"limitdisable");
        }

        private void buttonSetLimitLeft_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"setlimitleft");
        }

        private void buttonSetLimitRight_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"setlimitright");
        }
    }
}
