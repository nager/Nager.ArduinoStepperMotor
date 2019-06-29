﻿namespace Nager.ArduinoStepperMotor.TestUI
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
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.simpleMotorControl1 = new Nager.ArduinoStepperMotor.TestUI.CustomControl.SimpleMotorControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.smoothMotorControlWithStepCount1 = new Nager.ArduinoStepperMotor.TestUI.CustomControl.SmoothMotorControlWithStepCount();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rampControl1 = new Nager.ArduinoStepperMotor.TestUI.CustomControl.RampControl();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReceive.Location = new System.Drawing.Point(3, 3);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ReadOnly = true;
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceive.Size = new System.Drawing.Size(347, 402);
            this.textBoxReceive.TabIndex = 1;
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
            this.groupBox3.Size = new System.Drawing.Size(589, 86);
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
            this.tabControl1.Size = new System.Drawing.Size(589, 348);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.simpleMotorControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stepper A4988";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // simpleMotorControl1
            // 
            this.simpleMotorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleMotorControl1.Location = new System.Drawing.Point(3, 3);
            this.simpleMotorControl1.Name = "simpleMotorControl1";
            this.simpleMotorControl1.Size = new System.Drawing.Size(575, 316);
            this.simpleMotorControl1.TabIndex = 0;
            this.simpleMotorControl1.SendCommand += new System.Action<string>(this.simpleMotorControl1_SendCommand);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.smoothMotorControlWithStepCount1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SmoothMotorControlWithStepCount";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // smoothMotorControlWithStepCount1
            // 
            this.smoothMotorControlWithStepCount1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smoothMotorControlWithStepCount1.Location = new System.Drawing.Point(3, 3);
            this.smoothMotorControlWithStepCount1.Name = "smoothMotorControlWithStepCount1";
            this.smoothMotorControlWithStepCount1.Size = new System.Drawing.Size(720, 316);
            this.smoothMotorControlWithStepCount1.TabIndex = 0;
            this.smoothMotorControlWithStepCount1.SendCommand += new System.Action<string>(this.smoothMotorControlWithStepCount1_SendCommand);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rampControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(726, 322);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ramp";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rampControl1
            // 
            this.rampControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rampControl1.Location = new System.Drawing.Point(3, 3);
            this.rampControl1.Margin = new System.Windows.Forms.Padding(2);
            this.rampControl1.Name = "rampControl1";
            this.rampControl1.Size = new System.Drawing.Size(720, 316);
            this.rampControl1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl2.Location = new System.Drawing.Point(589, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(361, 434);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBoxReceive);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(353, 408);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Receive";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBoxSend);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(208, 408);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Send";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBoxSend
            // 
            this.textBoxSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSend.Location = new System.Drawing.Point(3, 3);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.ReadOnly = true;
            this.textBoxSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSend.Size = new System.Drawing.Size(202, 402);
            this.textBoxSend.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl2);
            this.Name = "Main";
            this.Text = "Nager.ArduinoStepperMotor.TestUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonRefresh;
        private CustomControl.SmoothMotorControlWithStepCount smoothMotorControlWithStepCount1;
        private System.Windows.Forms.TabPage tabPage3;
        private CustomControl.RampControl rampControl1;
        private CustomControl.SimpleMotorControl simpleMotorControl1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBoxSend;
    }
}
