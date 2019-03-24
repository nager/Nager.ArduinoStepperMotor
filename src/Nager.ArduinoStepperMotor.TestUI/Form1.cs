using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
        private ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        private bool _stopUiUpdate = false;

        public Form1()
        {
            this.InitializeComponent();

            this._serialPort.Handshake = Handshake.None;
            this._serialPort.DataReceived += this.SerialPortDataReceived;
            this._serialPort.ReadTimeout = 1000;
            this._serialPort.Open();

            new Thread(this.RefreshUi).Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._stopUiUpdate = true;
        }

        private void RefreshUi()
        {
            var sb = new StringBuilder();

            while (!this._stopUiUpdate)
            {
                sb.Clear();

                try
                {
                    foreach (var item in this._queue)
                    {
                        sb.AppendLine(item);
                    }

                    if (this.textBoxReceive.InvokeRequired)
                    {
                        this.textBoxReceive.Invoke(new Action(() =>
                        {
                            this.textBoxReceive.Text = sb.ToString();
                        }));
                    }
                    else
                    {
                        this.textBoxReceive.Text = sb.ToString();
                    }
                }
                catch (Exception exception)
                {

                }

                Thread.Sleep(50);
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (this._serialPort.BytesToRead > 0)
            {
                var data = this._serialPort.ReadExisting();
                this._queue.Enqueue(data.Trim());

                if (this._queue.Count > 20)
                {
                    this._queue.TryDequeue(out var temp);
                }
            }
        }

        private void buttonStart_Click(object sender, System.EventArgs e)
        {
            this._serialPort.Write("start");
        }

        private void buttonStop_Click(object sender, System.EventArgs e)
        {
            this._serialPort.Write("stop");
        }

        private void buttonMoveLeft_Click(object sender, System.EventArgs e)
        {
            var rotate = this.trackBar1.Value;
            this._serialPort.Write($"move=-{rotate}");
        }

        private void buttonMoveRight_Click(object sender, System.EventArgs e)
        {
            var rotate = this.trackBar1.Value;
            this._serialPort.Write($"move={rotate}");
        }

        private void trackBarSpeed_ValueChanged(object sender, System.EventArgs e)
        {
            var speed = this.trackBarSpeed.Value;
            this._serialPort.Write($"speed={speed}");
        }
    }
}
