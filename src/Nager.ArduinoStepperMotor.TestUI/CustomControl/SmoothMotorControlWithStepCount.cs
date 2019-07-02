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
            this.comboBoxRepeat.SelectedIndex = 0;
            this.comboBoxProgram.SelectedIndex = 0;
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


            this.trackBarSpeed.Invoke((MethodInvoker)delegate
            {
                this.trackBarSpeed.ValueChanged -= trackBarSpeed_ValueChanged;
                this.trackBarSpeed.Value = speed;
                this.trackBarSpeed.ValueChanged += trackBarSpeed_ValueChanged;
            });
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

        #region Program

        private async void buttonStartProgram_Click(object sender, EventArgs e)
        {
            var program = this.comboBoxProgram.Text;
            switch (program)
            {
                case "Program1":
                    await this.Program1Async();
                    break;
                case "Program2":
                    await this.Program2Async();
                    break;
                case "Program3":
                    await this.Program3Async();
                    break;
                case "Program4":
                    await this.Program4Async();
                    break;
                case "Program5":
                    await this.Program5Async();
                    break;
                case "Program6":
                    await this.Program6Async();
                    break;
            }
        }

        private async Task Program1Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                //Start Position
                this.SetSpeed(255);
                this.SendSpeed();
                for (var j = 0; j < 50; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

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

        private async Task Program2Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                //Start Position
                this.SetSpeed(255);
                this.SendSpeed();
                for (var j = 0; j < 50; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

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

        private async Task Program3Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                //Start Position
                this.SetSpeed(255);
                this.SendSpeed();
                for (var j = 0; j < 50; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(2000);

                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        private async Task Program4Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                //Start Position
                this.SetSpeed(255);
                this.SendSpeed();
                for (var j = 0; j < 50; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(40);

                this.SetSpeed(100);
                this.SendSpeed();
                await Task.Delay(20);

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(40);

                this.SetSpeed(100);
                this.SendSpeed();
                await Task.Delay(20);

                this.SetSpeed(-255);
                this.SendSpeed();
                await Task.Delay(500);

                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        private async Task Program5Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                for (var k = -1; k >= -255; k--)
                {

                    //Start Position
                    this.SetSpeed(255);
                    this.SendSpeed();
                    for (var j = 0; j < 50; j++)
                    {
                        if (this._motorInfo.LimitRight == 0)
                        {
                            break;
                        }

                        await Task.Delay(50);
                    }

                    this.SetSpeed(k);
                    this.SendSpeed();

                    //Wait for End Position
                    for (var j = 0; j < 100; j++)
                    {
                        if (this._motorInfo.LimitLeft == 0)
                        {
                            break;
                        }

                        await Task.Delay(50);
                    }

                    this.SetSpeed(0);
                    this.SendSpeed();
                }
            }
        }

        private async Task Program6Async()
        {
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);

            for (var i = 0; i < repeats; i++)
            {
                //Start Position
                this.SetSpeed(255);
                this.SendSpeed();
                for (var j = 0; j < 50; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

                this.SetSpeed(-51);
                this.SendSpeed();
                this.SendSpeed();


                await Task.Delay(2000);

                this.SetSpeed(0);
                this.SendSpeed();
            }
        }

        #endregion

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
