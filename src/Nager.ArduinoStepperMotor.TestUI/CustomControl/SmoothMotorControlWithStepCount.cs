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
        private ArduinoMotorInfo _motorInfo;

        public event Action<string> SendCommand;

        public SmoothMotorControlWithStepCount()
        {
            this.InitializeComponent();
        }

        private void SmoothMotorControlWithStepCount_Load(object sender, EventArgs e)
        {
            this.SetSpeed(0);
        }

        public void DataReceived(string data)
        {
            var motorInfo = JsonConvert.DeserializeObject<ArduinoMotorInfo>(data);
            this._motorInfo = motorInfo;

            if (motorInfo.LimitLeft == -1 || motorInfo.LimitRight == -1)
            {
                this.SwitchLimitButtons(false);
            }
            else
            {
                this.SwitchLimitButtons(true);
            }

            if (motorInfo.MotorSpeed == 0 && this._speed != 0)
            {
                this.SetSpeed(0);
            }
        }

        private void SwitchLimitButtons(bool limitActive)
        {
            this.buttonLimitSwitch.Invoke((MethodInvoker)delegate
            {
                if (limitActive)
                {
                    this.buttonLimitSwitch.Text = "Disable";
                }
                else
                {
                    this.buttonLimitSwitch.Text = "Enable";
                }
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
            this.SendSpeed();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            this._speed = this.trackBarSpeed.Value;
            this.SendSpeed();
        }

        private void SendSpeed()
        {
            this.SendCommand?.Invoke($"speed={this._speed}");
        }

        private void SetSpeed(int speed)
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
        }

        private void trackBarSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        private async void buttonRandom_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                var minValue = -255;
                var maxValue = 255;

                if (this._motorInfo.LimitLeft < 100)
                {
                    minValue = 0;
                }

                if (this._motorInfo.LimitRight < 100)
                {
                    maxValue = 0;
                }

                var randomSpeed = this._random.Next(minValue, maxValue);
                var delay = this._random.Next(10, 400);

                this.SetSpeed(randomSpeed);
                this.SendSpeed();
                await Task.Delay(delay);
            }

            this.SetSpeed(0);
            this.SendSpeed();
            await Task.Delay(2000);
        }

        private async void buttonProgram1_Click(object sender, EventArgs e)
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                this.SetSpeed(255);
                this.SendSpeed();
                await Task.Delay(2000);

                this.SetSpeed(-2);
                this.SendSpeed();
                await Task.Delay(100);

                this.SetSpeed(-50);
                this.SendSpeed();
                await Task.Delay(200);

                this.SetSpeed(-100);
                this.SendSpeed();
                await Task.Delay(100);

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(100);

                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        private async void buttonProgram2_Click(object sender, EventArgs e)
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                this.SetSpeed(255);
                this.SendSpeed();
                await Task.Delay(2000);

                this.SetSpeed(-2);
                this.SendSpeed();
                await Task.Delay(400);

                this.SetSpeed(-50);
                this.SendSpeed();
                await Task.Delay(500);

                this.SetSpeed(-100);
                this.SendSpeed();
                await Task.Delay(500);

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(500);

                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        private void buttonLimitSwitch_Click(object sender, EventArgs e)
        {
            if (this._motorInfo.LimitLeft == -1)
            {
                this.SendCommand?.Invoke($"limitenable");
                return;
            }

            this.SendCommand?.Invoke($"limitdisable");
            return;
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
            this.SendSpeed();
        }

        private void buttonMaxRight_Click(object sender, EventArgs e)
        {
            var speed = 255;
            this.SetSpeed(speed);
            this.SendSpeed();
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
