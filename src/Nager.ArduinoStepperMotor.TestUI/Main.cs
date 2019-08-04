using log4net;
using Nager.ArduinoStepperMotor.TestUI.Model;
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
        private readonly ConcurrentQueue<SerialReceiveMessage> _queueReceive = new ConcurrentQueue<SerialReceiveMessage>();
        private readonly ConcurrentQueue<string> _queueSend = new ConcurrentQueue<string>();
        private bool _stopUiUpdate = false;

        public Main()
        {
            this.InitializeComponent();
            this.RefreshSerialPorts();

            new Thread(this.RefreshReceive).Start();
            new Thread(this.RefreshSend).Start();
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            this._stopUiUpdate = true;
            this.CloseSerialPort();
        }

        private void RefreshReceive()
        {
            var sb = new StringBuilder();

            while (!this._stopUiUpdate)
            {
                try
                {
                    if (!this._queueReceive.TryDequeue(out var receive))
                    {
                        Thread.Sleep(50);
                        continue;
                    }

                    this.smoothMotorControlWithStepCount1.DataReceived(receive.Data);
                    this.rampControl1.DataReceived(receive.Data);

                    sb.AppendLine($"{receive.ReceiveDate:mm:ss.fff} - {receive.Data}");

                    var text = sb.ToString();
                    if (text.Length > 1000)
                    {
                        var index = text.IndexOf('\n');
                        sb.Remove(0, index + 1);
                    }

                    if (this.textBoxReceive.InvokeRequired)
                    {
                        this.textBoxReceive.Invoke(new Action(() =>
                        {
                            this.textBoxReceive.Text = text;
                        }));
                    }
                    else
                    {
                        this.textBoxReceive.Text = text;
                    }
                }
                catch (Exception exception)
                {

                }
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
                while (this._serialPort.IsOpen && this._serialPort.BytesToRead > 0)
                {
                    var data = this._serialPort.ReadLine().Trim();
                    Log.Debug($"{nameof(SerialPortDataReceived)} - {data}");

                    this._queueReceive.Enqueue(new SerialReceiveMessage { ReceiveDate = DateTime.Now, Data = data });
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void SerialPortDataWrite(string data)
        {
            if (this._serialPort == null)
            {
                return;
            }

            if (!this._serialPort.IsOpen)
            {
                return;
            }

            this._serialPort.WriteLine(data);
            Log.Debug($"{nameof(SerialPortDataWrite)} - {data}");

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

        private bool OpenSerialPort()
        {
            var serialPort = this.comboBoxSerialPort.SelectedItem as string;

            this._serialPort = new SerialPort(serialPort, 115200, Parity.None, 8, StopBits.One);
            //this._serialPort.Handshake = Handshake.None;
            this._serialPort.DataReceived += this.SerialPortDataReceived;
            this._serialPort.RtsEnable = true;

            try
            {
                this._serialPort.Open();
                return true;
            }
            catch
            {
            }

            return false;
        }

        private void CloseSerialPort()
        {
            if (this._serialPort == null)
            {
                return;
            }

            this._serialPort.DataReceived -= this.SerialPortDataReceived;

            Log.Debug($"{nameof(CloseSerialPort)}");
            if (this._serialPort.IsOpen)
            {
                this._serialPort.Close();
            }
            this._serialPort.Dispose();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this._serialPort != null && this._serialPort.IsOpen)
            {
                return;
            }

            if (!this.OpenSerialPort())
            {
                MessageBox.Show("Cannot connect");
                return;
            }

            this.buttonConnect.Enabled = false;
            this.buttonDisconnect.Enabled = true;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            this.CloseSerialPort();

            this.buttonConnect.Enabled = true;
            this.buttonDisconnect.Enabled = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshSerialPorts();
        }

        private void smoothMotorControlWithStepCount1_SendCommand(string data)
        {
            this.SerialPortDataWrite(data);
        }

        private void simpleMotorControl1_SendCommand(string data)
        {
            this.SerialPortDataWrite(data);
        }

        private void rampControl1_SendCommand(string data)
        {
            this.SerialPortDataWrite(data);
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
