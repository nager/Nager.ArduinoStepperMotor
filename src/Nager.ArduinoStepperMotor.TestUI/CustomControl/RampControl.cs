using Nager.ArduinoStepperMotor.TestUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class RampControl : UserControl
    {
        public event Action<string> SendCommand;
        private List<MotorSpeedRamp> _motorSpeedRamp;

        public RampControl()
        {
            this.InitializeComponent();

            this.textBoxStartDelay.Text = "1500";
            this.textBoxAcceleration.Text = "0.6";
            this.textBoxAngle.Text = "1";
            this.textBox1.Text = "0.67703";

            this.DrawChart();
        }

        public void DataReceived(string data)
        {
            var rampInfo = JsonConvert.DeserializeObject<RampInfo>(data);
            if (rampInfo == null)
            {
                return;
            }

            if (rampInfo.Ramp == null)
            {
                return;
            }

            this.chart1.Invoke((MethodInvoker) delegate {
                this.chart1.Series[0].Points.Clear();
                this.chart1.Series[0].Points.DataBindY(rampInfo.Ramp);
            });

            this.dataGridView1.Invoke((MethodInvoker)delegate
            {
                var items = rampInfo.Ramp.Select((value, index) => new MotorSpeedRamp(index, value)).ToList();
                this.dataGridView1.DataSource = items;
            });
        }

        private void DrawChart()
        {
            try
            {
                int.TryParse(this.textBoxStartDelay.Text, out var startDelay);
                double.TryParse(this.textBoxAngle.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var angle);
                double.TryParse(this.textBoxAcceleration.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var acceleration);

                double.TryParse(this.textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var acceleration1);

                if (acceleration == 0 || angle == 0)
                {
                    return;
                }

                var items = this.CalculateRamp(startDelay, angle, acceleration, acceleration1);
                this._motorSpeedRamp = items;

                this.chart1.Series[0].Points.Clear();
                this.chart1.Series[0].Points.DataBindY(items.Select(o => o.Sleep).Where(o => !double.IsNaN(o)).ToList());

                this.dataGridView1.DataSource = items;
            }
            catch (Exception exception)
            {

            }
        }

        private List<MotorSpeedRamp> CalculateRamp(int startDelay, double angle, double acceleration, double acceleration1)
        {
            var items = new List<MotorSpeedRamp>();

            double c0 = startDelay * Math.Sqrt(2 * angle / acceleration) * acceleration1; // in us
            items.Add(new MotorSpeedRamp(0, c0));
            double lastDelay = c0;

            for (int i = 1; i < 255; i++)
            {
                var d = lastDelay - (2 * lastDelay) / (4 * i + 1);
                items.Add(new MotorSpeedRamp(i, d));
                lastDelay = d;
            }

            return items;
        }

        private void textBoxStartDelay_TextChanged(object sender, EventArgs e)
        {
            this.DrawChart();
        }

        private void textBoxAngle_TextChanged(object sender, EventArgs e)
        {
            this.DrawChart();
        }

        private void textBoxAcceleration_TextChanged(object sender, EventArgs e)
        {
            this.DrawChart();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.DrawChart();
        }

        private void buttonSetRamp_Click(object sender, EventArgs e)
        {
            var items = this.dataGridView1.DataSource as List<MotorSpeedRamp>;

            foreach (var item in items)
            {
                this.SendCommand?.Invoke($"setramp={item.Index:000}{item.Sleep:0000}");
            }
        }

        private void buttonGetRamp_Click(object sender, EventArgs e)
        {
            this.SendCommand?.Invoke("ramp");
        }
    }
}
