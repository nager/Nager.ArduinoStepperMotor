using Nager.ArduinoStepperMotor.TestUI.Model;
using Newtonsoft.Json;
using System;
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
            var motorInfo = JsonConvert.DeserializeObject<ArduinoMotorInfo>(data);

            if (motorInfo.LimitLeft == -1 || motorInfo.LimitRight == -1)
            {
                this.SwitchLimitButtons(false);
            }
            else
            {
                this.SwitchLimitButtons(true);
            }

            if (motorInfo.MotorSpeed == 0)
            {
                this.SetSpeed(0);
            }
        }

        private void SwitchLimitButtons(bool limitActive)
        {
            this.buttonLimitDisable.Invoke((MethodInvoker)delegate
            {
                this.buttonLimitDisable.Enabled = limitActive;
            });

            this.buttonLimitEnable.Invoke((MethodInvoker)delegate
            {
                this.buttonLimitEnable.Enabled = !limitActive;
            });

            this.buttonSetLimitLeft.Invoke((MethodInvoker)delegate
            {
                this.buttonSetLimitLeft.Enabled = !limitActive;
            });

            this.buttonSetLimitRight.Invoke((MethodInvoker)delegate
            {
                this.buttonSetLimitRight.Enabled = !limitActive;
            });
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.SetSpeed(0);
            this.SendSpeed(0);
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            var speed = this.trackBarSpeed.Value;
            this.SendSpeed(speed);
        }

        private void SendSpeed(int speed)
        {
            this._speed = speed;
            this.SendCommand?.Invoke($"speed={speed}");
        }

        private void SetSpeed(int speed)
        {
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
            var speed = -255;
            this.SetSpeed(speed);
            this.SendSpeed(speed);
        }

        private void buttonMaxRight_Click(object sender, EventArgs e)
        {
            var speed = 255;
            this.SetSpeed(speed);
            this.SendSpeed(speed);
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
