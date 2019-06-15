using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    public partial class RampControl : UserControl
    {
        public RampControl()
        {
            this.InitializeComponent();

            this.textBoxStartDelay.Text = "1500";
            this.textBoxAcceleration.Text = "0.6";
            this.textBoxAngle.Text = "1";

            this.DrawChart();
        }

        private void DrawChart()
        {
            try
            {
                int.TryParse(this.textBoxStartDelay.Text, out var startDelay);
                double.TryParse(this.textBoxAngle.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var angle);
                double.TryParse(this.textBoxAcceleration.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var acceleration);

                if (acceleration == 0 || angle == 0)
                {
                    return;
                }

                this.chart1.Series[0].Points.Clear();
                var items = this.CalculateRamp(startDelay, angle, acceleration);
                this.chart1.Series[0].Points.DataBindY(items.Where(o => !double.IsNaN(o)).ToList());
            }
            catch (Exception exception)
            {

            }
        }

        private List<double> CalculateRamp(int startDelay, double angle, double acceleration)
        {
            var items = new List<double>();

            double c0 = startDelay * Math.Sqrt(2 * angle / acceleration) * 0.67703; // in us
            items.Add(c0);
            double lastDelay = c0;

            for (int i = 1; i < 255; i++)
            {
                var d = lastDelay - (2 * lastDelay) / (4 * i + 1);
                items.Add(d);
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
    }
}
