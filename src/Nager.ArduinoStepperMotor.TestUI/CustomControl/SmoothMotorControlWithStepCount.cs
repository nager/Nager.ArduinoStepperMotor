using Nager.ArduinoStepperMotor.TestUI.Model;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class SmoothMotorControlWithStepCount : UserControl
    {
        private Random _random = new Random();
        private int _speed = 0;

        public event Action<string> SendCommand;

        public SmoothMotorControlWithStepCount()
        {
            this.InitializeComponent();
            this.textBoxSpeed.Text = "0";
        }

        public void DataReceived(string data)
        {
            var limits = JsonConvert.DeserializeObject<LimitInfo>(data);
            return;
            if (limits.LimitLeft == -1|| limits.LimitRight == -1)
            {
                return;
            }

            if (limits.LimitLeft < 1200 && this._speed < 0)
            {
                var reduceSpeed = Math.Ceiling(Math.Abs(this._speed) / 2.0);
                this.SendSpeed(this._speed + (int)reduceSpeed);
            }

            if (limits.LimitRight < 1200 && this._speed > 0)
            {
                var reduceSpeed = Math.Ceiling(this._speed / 2.0);
                this.SendSpeed(this._speed - (int)reduceSpeed);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.trackBarSpeed.Value = 0;
            this.trackBarSpeed.Focus();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            var speed = this.trackBarSpeed.Value;
            this.SendSpeed(speed);
        }

        private void SendSpeed(int speed)
        {
            this._speed = speed;
            this.textBoxSpeed.Invoke((MethodInvoker)delegate
            {
                this.textBoxSpeed.Text = speed.ToString();
            });

            this.trackBarSpeed.ValueChanged -= trackBarSpeed_ValueChanged;
            this.trackBarSpeed.Invoke((MethodInvoker)delegate
            {
                this.trackBarSpeed.Value = speed;
            });
            this.trackBarSpeed.ValueChanged += trackBarSpeed_ValueChanged;

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

        private void buttonMaxLeft_Click(object sender, EventArgs e)
        {
            this.SendSpeed(-255);
        }

        private void buttonMaxRight_Click(object sender, EventArgs e)
        {
            this.SendSpeed(255);
        }

        private void buttonEnableMotorDriver_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"enablemotordriver");
        }

        private void buttonDisableMotorDriver_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke($"disablemotordriver");
        }
    }
}
