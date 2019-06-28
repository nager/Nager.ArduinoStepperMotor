namespace Nager.ArduinoStepperMotor.TestUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.smoothMotorControlWithStepCount1 = new Nager.ArduinoStepperMotor.TestUI.CustomControl.SmoothMotorControlWithStepCount();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rampControl1 = new Nager.ArduinoStepperMotor.TestUI.CustomControl.RampControl();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 100;
            this.trackBar1.Location = new System.Drawing.Point(64, 140);
            this.trackBar1.Maximum = 20000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(393, 45);
            this.trackBar1.SmallChange = 100;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 500;
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxReceive.Location = new System.Drawing.Point(583, 0);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ReadOnly = true;
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceive.Size = new System.Drawing.Size(367, 434);
            this.textBoxReceive.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(87, 19);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonMoveLeft
            // 
            this.buttonMoveLeft.Location = new System.Drawing.Point(6, 36);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveLeft.TabIndex = 4;
            this.buttonMoveLeft.Text = "Left";
            this.buttonMoveLeft.UseVisualStyleBackColor = true;
            this.buttonMoveLeft.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.Location = new System.Drawing.Point(87, 36);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveRight.TabIndex = 5;
            this.buttonMoveRight.Text = "Right";
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 100;
            this.trackBarSpeed.Location = new System.Drawing.Point(64, 89);
            this.trackBarSpeed.Maximum = 1000;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(393, 45);
            this.trackBarSpeed.TabIndex = 6;
            this.trackBarSpeed.TickFrequency = 50;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            this.trackBarSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSpeed_MouseDown);
            this.trackBarSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarSpeed_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Speed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Steps:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 52);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor Shield";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSteps);
            this.groupBox2.Controls.Add(this.textBoxSpeed);
            this.groupBox2.Controls.Add(this.buttonMoveLeft);
            this.groupBox2.Controls.Add(this.buttonMoveRight);
            this.groupBox2.Controls.Add(this.trackBarSpeed);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 202);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Move";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(463, 140);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.ReadOnly = true;
            this.textBoxSteps.Size = new System.Drawing.Size(67, 20);
            this.textBoxSteps.TabIndex = 10;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(463, 89);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(67, 20);
            this.textBoxSpeed.TabIndex = 9;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 47);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(87, 47);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 12;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonRefresh);
            this.groupBox3.Controls.Add(this.comboBoxSerialPort);
            this.groupBox3.Controls.Add(this.buttonConnect);
            this.groupBox3.Controls.Add(this.buttonDisconnect);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 86);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(168, 17);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 14;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(156, 21);
            this.comboBoxSerialPort.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 348);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stepper A4988";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.smoothMotorControlWithStepCount1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SmoothMotorControlWithStepCount";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // smoothMotorControlWithStepCount1
            // 
            this.smoothMotorControlWithStepCount1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smoothMotorControlWithStepCount1.Location = new System.Drawing.Point(3, 3);
            this.smoothMotorControlWithStepCount1.Name = "smoothMotorControlWithStepCount1";
            this.smoothMotorControlWithStepCount1.Size = new System.Drawing.Size(542, 286);
            this.smoothMotorControlWithStepCount1.TabIndex = 0;
            this.smoothMotorControlWithStepCount1.SendCommand += new System.Action<string>(this.smoothMotorControlWithStepCount1_SendCommand);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rampControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(575, 322);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ramp";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rampControl1
            // 
            this.rampControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rampControl1.Location = new System.Drawing.Point(3, 3);
            this.rampControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rampControl1.Name = "rampControl1";
            this.rampControl1.Size = new System.Drawing.Size(569, 316);
            this.rampControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxReceive);
            this.Name = "Form1";
            this.Text = "Nager.ArduinoStepperMotor.TestUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonRefresh;
        private CustomControl.SmoothMotorControlWithStepCount smoothMotorControlWithStepCount1;
        private System.Windows.Forms.TabPage tabPage3;
        private CustomControl.RampControl rampControl1;
    }
}

