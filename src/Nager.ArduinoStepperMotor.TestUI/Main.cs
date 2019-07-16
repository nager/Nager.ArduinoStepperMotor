using log4net;
using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nager.ArduinoStepperMotor.TestUI
{
    public partial class Main : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Main));

        private SerialPort _serialPort;
        private ConcurrentQueue<string> _queueReceive = new ConcurrentQueue<string>();
        private ConcurrentQueue<string> _queueSend = new ConcurrentQueue<string>();
        private bool _stopUiUpdate = false;

        public Main()
        {
            this.InitializeComponent();
            this.RefreshSerialPorts();

            new Thread(this.RefreshReceive).Start();
            new Thread(this.RefreshSend).Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._stopUiUpdate = true;
        }

        private void RefreshReceive()
        {
            var sb = new StringBuilder();

            while (!this._stopUiUpdate)
            {
                sb.Clear();

                try
                {
                    foreach (var item in this._queueReceive)
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

        private void RefreshSend()
        {
            var sb = new StringBuilder();

            while (!this._stopUiUpdate)
            {
                sb.Clear();

                try
                {
                    foreach (var item in this._queueSend)
                    {
                        sb.AppendLine(item);
                    }

                    if (this.textBoxSend.InvokeRequired)
                    {
                        this.textBoxSend.Invoke(new Action(() =>
                        {
                            this.textBoxSend.Text = sb.ToString();
                        }));
                    }
                    else
                    {
                        this.textBoxSend.Text = sb.ToString();
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
            try
            {
                while (this._serialPort.BytesToRead > 0)
                {
                    var data = this._serialPort.ReadLine();
                    Log.Debug($"{nameof(SerialPortDataReceived)} - {data.Trim()}");
                    this.smoothMotorControlWithStepCount1.DataReceived(data);
  
                    this._queueReceive.Enqueue($"{DateTime.Now:mm:ss.fff} - {data.Trim()}");

                    if (this._queueReceive.Count > 20)
                    {
                        this._queueReceive.TryDequeue(out var temp);
                        this._queueReceive.TryDequeue(out temp);
                    }
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void WriteSerialData(string data)
        {
            if (this._serialPort == null)
            {
                return;
            }

            if (!this._serialPort.IsOpen)
            {
                return;
            }

            //var sw = new Stopwatch();
            //sw.Start();
            this._serialPort.WriteLine(data);
            Log.Debug($"{nameof(WriteSerialData)} - {data}");
            //sw.Stop();
            //this._queue.Enqueue($"{DateTime.Now:mm:ss.fff} Send - {data} {sw.Elapsed.TotalMilliseconds}ms");

            this._queueSend.Enqueue(data.Trim());


            if (this._queueSend.Count > 20)
            {
                this._queueSend.TryDequeue(out var temp);
                this._queueSend.TryDequeue(out temp);
            }
        }

        private void RefreshSerialPorts()
        {
            this.comboBoxSerialPort.DataSource = SerialPort.GetPortNames();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this._serialPort != null && this._serialPort.IsOpen)
            {
                return;
            }

            var serialPort = this.comboBoxSerialPort.SelectedItem as string;

            this._serialPort = new SerialPort(serialPort, 115200, Parity.None, 8, StopBits.One);
            //this._serialPort.Handshake = Handshake.None;
            this._serialPort.DataReceived += this.SerialPortDataReceived;
            this._serialPort.RtsEnable = true;
            //this._serialPort.ReadTimeout = 10000;
            this._serialPort.Open();

            this.buttonConnect.Enabled = false;
            this.buttonDisconnect.Enabled = true;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (this._serialPort == null)
            {
                return;
            }

            this._serialPort.DataReceived -= this.SerialPortDataReceived;
            this._serialPort.Close();

            this.buttonConnect.Enabled = true;
            this.buttonDisconnect.Enabled = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshSerialPorts();
        }

        private void smoothMotorControlWithStepCount1_SendCommand(string data)
        {
            this.WriteSerialData(data);
        }

        private void simpleMotorControl1_SendCommand(string data)
        {
            this.WriteSerialData(data);
        }

        private void textBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.textBoxSend.Text = string.Empty;
            }
        }
    }
}
