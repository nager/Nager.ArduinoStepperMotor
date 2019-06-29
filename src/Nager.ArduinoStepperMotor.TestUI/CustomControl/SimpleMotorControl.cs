using System;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class SimpleMotorControl : UserControl
    {
        private bool _updateSpeed = false;

        public event Action<string> SendCommand;

        public SimpleMotorControl()
        {
            this.InitializeComponent();
        }

        private void UpdateSpeed()
        {
            if (!this._updateSpeed)
            {
                return;
            }

            var speed = this.trackBarSpeed.Value;
            this.textBoxSpeed.Text = speed.ToString();
            this.SendCommand?.Invoke($"speed={speed}");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("start");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("stop");
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            var rotate = this.trackBar1.Value;
            this.SendCommand?.Invoke($"move=-{rotate}");
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            var rotate = this.trackBar1.Value;
            this.SendCommand?.Invoke($"move={rotate}");
        }

        private void trackBarSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            this._updateSpeed = true;
            this.UpdateSpeed();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateSpeed();
        }

        private void trackBarSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            this._updateSpeed = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            var rotate = this.trackBar1.Value;
            this.textBoxSteps.Text = rotate.ToString();
        }
    }
}
