using Nager.ArduinoStepperMotor.TestUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            var microstepInfos = new List<MicrostepInfo>
            {
                new MicrostepInfo { Name = "1/2", Multiplier = 2 },
                new MicrostepInfo { Name = "1/4", Multiplier = 4 },
                new MicrostepInfo { Name = "1/8", Multiplier = 8 },
                new MicrostepInfo { Name = "1/16", Multiplier = 16 },
                new MicrostepInfo { Name = "1/32", Multiplier = 32 },
                new MicrostepInfo { Name = "1/64", Multiplier = 64 },
                new MicrostepInfo { Name = "1/128", Multiplier = 128 },
                new MicrostepInfo { Name = "1/256", Multiplier = 256 },
            };

            this.comboBoxMicrostep.DisplayMember = "Name";
            this.comboBoxMicrostep.ValueMember = "Multiplier";
            this.comboBoxMicrostep.DataSource = microstepInfos;
            this.comboBoxMicrostep.SelectedIndex = 0;
        }

        private void SmoothMotorControlWithStepCount_Load(object sender, EventArgs e)
        {
            this.SetSpeed(0);
        }

        public void DataReceived(string data)
        {
            var motorInfo = JsonConvert.DeserializeObject<ArduinoMotorInfo>(data);
            if (motorInfo == null)
            {
                return;
            }

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
                //this.SetSpeed(0);
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
            this.SetSpeed(this.trackBarSpeed.Value, this.trackBarSpeed);
            this.SendSpeed();
        }

        private void SendSpeed()
        {
            this.SendCommand?.Invoke($"speed={this._speed}");
        }

        private void SetSpeed(double speed, object sender = null)
        {
            this._speed = (int)speed;

            if (sender != this.textBoxSpeed)
            {
                this.textBoxSpeed.Invoke((MethodInvoker)delegate
                {
                    this.textBoxSpeed.Text = $"Current Speed: {speed}";
                });
            }

            if (sender != this.trackBarSpeed)
            {
                this.trackBarSpeed.Invoke((MethodInvoker)delegate
                {
                    this.trackBarSpeed.ValueChanged -= trackBarSpeed_ValueChanged;
                    this.trackBarSpeed.Value = (int)speed;
                    this.trackBarSpeed.ValueChanged += trackBarSpeed_ValueChanged;
                });
            }
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
            var repeats = Convert.ToInt32(this.comboBoxRepeat.Text);
            var program = this.comboBoxProgram.Text;

            for (var i = 0; i < repeats; i++)
            {
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
        }

        private async Task Program1Async()
        {
            //Start Position
            this.SetSpeed(100);
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

            this.SetSpeed(-25);
            this.SendSpeed();
            await Task.Delay(200);

            this.SetSpeed(-50);
            this.SendSpeed();
            await Task.Delay(100);

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(100);

            this.SetSpeed(0);
            this.SendSpeed();
        }

        private async Task Program2Async()
        {
            //Start Position
            this.SetSpeed(100);
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

            this.SetSpeed(-25);
            this.SendSpeed();
            await Task.Delay(500);

            this.SetSpeed(-50);
            this.SendSpeed();
            await Task.Delay(500);

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(500);

            this.SetSpeed(0);
            this.SendSpeed();
        }

        private async Task Program3Async()
        {
            //Start Position
            this.SetSpeed(100);
            this.SendSpeed();
            for (var j = 0; j < 50; j++)
            {
                if (this._motorInfo.LimitRight == 0)
                {
                    break;
                }

                await Task.Delay(50);
            }

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(2000);

            this.SetSpeed(0);
            this.SendSpeed();
        }

        private async Task Program4Async()
        {
            //Start Position
            this.SetSpeed(100);
            this.SendSpeed();
            for (var j = 0; j < 50; j++)
            {
                if (this._motorInfo.LimitRight == 0)
                {
                    break;
                }

                await Task.Delay(50);
            }

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(40);

            this.SetSpeed(100);
            this.SendSpeed();
            await Task.Delay(20);

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(40);

            this.SetSpeed(100);
            this.SendSpeed();
            await Task.Delay(20);

            this.SetSpeed(-100);
            this.SendSpeed();
            await Task.Delay(500);

            this.SetSpeed(0);
            this.SendSpeed();
        }

        private async Task Program5Async()
        {
            for (var speed = 0.0; speed <= 100; speed += 0.5)
            {
                //Start Position
                this.SetSpeed(100);
                this.SendSpeed();
                for (var j = 0; j < 100; j++)
                {
                    if (this._motorInfo.LimitRight == 0)
                    {
                        break;
                    }

                    await Task.Delay(50);
                }

                this.SetSpeed(-speed);
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

                await Task.Delay(100);
            }
        }

        private async Task Program6Async()
        {
            //Start Position
            this.SetSpeed(100);
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

        #endregion

        private void buttonLimitSwitch_Click(object sender, EventArgs e)
        {
            if (this._motorInfo.LimitLeft == -1)
            {
                this.SendCommand?.Invoke("limitenable");
                return;
            }

            this.SendCommand?.Invoke("limitdisable");
            return;
        }

        private void buttonSetLimitLeft_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("setlimitleft");
        }

        private void buttonSetLimitRight_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("setlimitright");
        }

        private void buttonMaxLeft_Click(object sender, EventArgs e)
        {
            this.SetSpeed(-255);
            this.SendSpeed();
        }

        private void buttonMaxRight_Click(object sender, EventArgs e)
        {
            this.SetSpeed(255);
            this.SendSpeed();
        }

        private void buttonEnableMotorDriver_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("enablemotordriver");
        }

        private void buttonDisableMotorDriver_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("disablemotordriver");
        }

        private void buttonSpeed_Click(object sender, EventArgs e)
        {
            int.TryParse(this.textBoxSpeed2.Text, out var speed);
            this.SetSpeed(speed);
            this.SendCommand?.Invoke($"speed={this._speed}");
        }

        private void buttonDriveFullTurn_Click(object sender, EventArgs e)
        {
            var stepCount = 200;
            var microstepInfo = this.comboBoxMicrostep.SelectedItem as MicrostepInfo;

            stepCount *= microstepInfo.Multiplier;

            for (var i = 0; i < stepCount; i++)
            {
                this.SendCommand?.Invoke("step");
            }
        }
    }
}
