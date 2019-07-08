namespace Nager.ArduinoStepperMotor.TestUI.CustomControl
{
    partial class SmoothMotorControlWithStepCount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRampInfo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxProgram = new System.Windows.Forms.ComboBox();
            this.buttonStartProgram = new System.Windows.Forms.Button();
            this.comboBoxRepeat = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDisableMotorDriver = new System.Windows.Forms.Button();
            this.buttonEnableMotorDriver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSetLimitRight = new System.Windows.Forms.Button();
            this.buttonLimitSwitch = new System.Windows.Forms.Button();
            this.buttonSetLimitLeft = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSpeed = new System.Windows.Forms.Button();
            this.textBoxSpeed2 = new System.Windows.Forms.TextBox();
            this.buttonMaxRight = new System.Windows.Forms.Button();
            this.buttonMaxLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSpeed.Location = new System.Drawing.Point(3, 3);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(508, 20);
            this.textBoxSpeed.TabIndex = 17;
            this.textBoxSpeed.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(3, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(110, 28);
            this.buttonStop.TabIndex = 16;
            this.buttonStop.TabStop = false;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSpeed.Location = new System.Drawing.Point(3, 43);
            this.trackBarSpeed.Maximum = 255;
            this.trackBarSpeed.Minimum = -255;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(508, 123);
            this.trackBarSpeed.TabIndex = 15;
            this.trackBarSpeed.TickFrequency = 10;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            this.trackBarSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBarSpeed_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 294);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRampInfo);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonRandom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 211);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 81);
            this.panel1.TabIndex = 19;
            // 
            // buttonRampInfo
            // 
            this.buttonRampInfo.Location = new System.Drawing.Point(95, 3);
            this.buttonRampInfo.Name = "buttonRampInfo";
            this.buttonRampInfo.Size = new System.Drawing.Size(86, 23);
            this.buttonRampInfo.TabIndex = 32;
            this.buttonRampInfo.Text = "Ramp Info";
            this.buttonRampInfo.UseVisualStyleBackColor = true;
            this.buttonRampInfo.Click += new System.EventHandler(this.buttonRampInfo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxProgram);
            this.groupBox3.Controls.Add(this.buttonStartProgram);
            this.groupBox3.Controls.Add(this.comboBoxRepeat);
            this.groupBox3.Location = new System.Drawing.Point(4, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 42);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Program";
            // 
            // comboBoxProgram
            // 
            this.comboBoxProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProgram.FormattingEnabled = true;
            this.comboBoxProgram.Items.AddRange(new object[] {
            "Program1",
            "Program2",
            "Program3",
            "Program4",
            "Program5",
            "Program6"});
            this.comboBoxProgram.Location = new System.Drawing.Point(6, 15);
            this.comboBoxProgram.Name = "comboBoxProgram";
            this.comboBoxProgram.Size = new System.Drawing.Size(100, 21);
            this.comboBoxProgram.TabIndex = 30;
            // 
            // buttonStartProgram
            // 
            this.buttonStartProgram.Location = new System.Drawing.Point(156, 13);
            this.buttonStartProgram.Name = "buttonStartProgram";
            this.buttonStartProgram.Size = new System.Drawing.Size(61, 23);
            this.buttonStartProgram.TabIndex = 26;
            this.buttonStartProgram.Text = "Start";
            this.buttonStartProgram.UseVisualStyleBackColor = true;
            this.buttonStartProgram.Click += new System.EventHandler(this.buttonStartProgram_Click);
            // 
            // comboBoxRepeat
            // 
            this.comboBoxRepeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRepeat.FormattingEnabled = true;
            this.comboBoxRepeat.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30"});
            this.comboBoxRepeat.Location = new System.Drawing.Point(112, 15);
            this.comboBoxRepeat.Name = "comboBoxRepeat";
            this.comboBoxRepeat.Size = new System.Drawing.Size(38, 21);
            this.comboBoxRepeat.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDisableMotorDriver);
            this.groupBox2.Controls.Add(this.buttonEnableMotorDriver);
            this.groupBox2.Location = new System.Drawing.Point(231, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 75);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MotorDriver";
            // 
            // buttonDisableMotorDriver
            // 
            this.buttonDisableMotorDriver.Location = new System.Drawing.Point(6, 17);
            this.buttonDisableMotorDriver.Name = "buttonDisableMotorDriver";
            this.buttonDisableMotorDriver.Size = new System.Drawing.Size(86, 23);
            this.buttonDisableMotorDriver.TabIndex = 25;
            this.buttonDisableMotorDriver.Text = "Disable";
            this.buttonDisableMotorDriver.UseVisualStyleBackColor = true;
            this.buttonDisableMotorDriver.Click += new System.EventHandler(this.buttonDisableMotorDriver_Click);
            // 
            // buttonEnableMotorDriver
            // 
            this.buttonEnableMotorDriver.Location = new System.Drawing.Point(6, 46);
            this.buttonEnableMotorDriver.Name = "buttonEnableMotorDriver";
            this.buttonEnableMotorDriver.Size = new System.Drawing.Size(86, 23);
            this.buttonEnableMotorDriver.TabIndex = 24;
            this.buttonEnableMotorDriver.Text = "Enable";
            this.buttonEnableMotorDriver.UseVisualStyleBackColor = true;
            this.buttonEnableMotorDriver.Click += new System.EventHandler(this.buttonEnableMotorDriver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonSetLimitRight);
            this.groupBox1.Controls.Add(this.buttonLimitSwitch);
            this.groupBox1.Controls.Add(this.buttonSetLimitLeft);
            this.groupBox1.Location = new System.Drawing.Point(335, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 75);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limits";
            // 
            // buttonSetLimitRight
            // 
            this.buttonSetLimitRight.Location = new System.Drawing.Point(85, 46);
            this.buttonSetLimitRight.Name = "buttonSetLimitRight";
            this.buttonSetLimitRight.Size = new System.Drawing.Size(81, 23);
            this.buttonSetLimitRight.TabIndex = 22;
            this.buttonSetLimitRight.Text = "Set right limit";
            this.buttonSetLimitRight.UseVisualStyleBackColor = true;
            this.buttonSetLimitRight.Click += new System.EventHandler(this.buttonSetLimitRight_Click);
            // 
            // buttonLimitSwitch
            // 
            this.buttonLimitSwitch.Location = new System.Drawing.Point(6, 19);
            this.buttonLimitSwitch.Name = "buttonLimitSwitch";
            this.buttonLimitSwitch.Size = new System.Drawing.Size(160, 23);
            this.buttonLimitSwitch.TabIndex = 20;
            this.buttonLimitSwitch.Text = "Limit State";
            this.buttonLimitSwitch.UseVisualStyleBackColor = true;
            this.buttonLimitSwitch.Click += new System.EventHandler(this.buttonLimitSwitch_Click);
            // 
            // buttonSetLimitLeft
            // 
            this.buttonSetLimitLeft.Location = new System.Drawing.Point(6, 46);
            this.buttonSetLimitLeft.Name = "buttonSetLimitLeft";
            this.buttonSetLimitLeft.Size = new System.Drawing.Size(73, 23);
            this.buttonSetLimitLeft.TabIndex = 21;
            this.buttonSetLimitLeft.Text = "Set left limit";
            this.buttonSetLimitLeft.UseVisualStyleBackColor = true;
            this.buttonSetLimitLeft.Click += new System.EventHandler(this.buttonSetLimitLeft_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(3, 3);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(86, 23);
            this.buttonRandom.TabIndex = 18;
            this.buttonRandom.Text = "Random drive";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSpeed);
            this.panel2.Controls.Add(this.textBoxSpeed2);
            this.panel2.Controls.Add(this.buttonMaxRight);
            this.panel2.Controls.Add(this.buttonMaxLeft);
            this.panel2.Controls.Add(this.buttonStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 34);
            this.panel2.TabIndex = 20;
            // 
            // buttonSpeed
            // 
            this.buttonSpeed.Location = new System.Drawing.Point(447, 3);
            this.buttonSpeed.Name = "buttonSpeed";
            this.buttonSpeed.Size = new System.Drawing.Size(53, 28);
            this.buttonSpeed.TabIndex = 20;
            this.buttonSpeed.TabStop = false;
            this.buttonSpeed.Text = "Speed";
            this.buttonSpeed.UseVisualStyleBackColor = true;
            this.buttonSpeed.Click += new System.EventHandler(this.buttonSpeed_Click);
            // 
            // textBoxSpeed2
            // 
            this.textBoxSpeed2.Location = new System.Drawing.Point(378, 4);
            this.textBoxSpeed2.Name = "textBoxSpeed2";
            this.textBoxSpeed2.Size = new System.Drawing.Size(63, 20);
            this.textBoxSpeed2.TabIndex = 19;
            // 
            // buttonMaxRight
            // 
            this.buttonMaxRight.Location = new System.Drawing.Point(235, 3);
            this.buttonMaxRight.Name = "buttonMaxRight";
            this.buttonMaxRight.Size = new System.Drawing.Size(110, 28);
            this.buttonMaxRight.TabIndex = 18;
            this.buttonMaxRight.TabStop = false;
            this.buttonMaxRight.Text = "Max Right";
            this.buttonMaxRight.UseVisualStyleBackColor = true;
            this.buttonMaxRight.Click += new System.EventHandler(this.buttonMaxRight_Click);
            // 
            // buttonMaxLeft
            // 
            this.buttonMaxLeft.Location = new System.Drawing.Point(119, 3);
            this.buttonMaxLeft.Name = "buttonMaxLeft";
            this.buttonMaxLeft.Size = new System.Drawing.Size(110, 28);
            this.buttonMaxLeft.TabIndex = 17;
            this.buttonMaxLeft.TabStop = false;
            this.buttonMaxLeft.Text = "Max Left";
            this.buttonMaxLeft.UseVisualStyleBackColor = true;
            this.buttonMaxLeft.Click += new System.EventHandler(this.buttonMaxLeft_Click);
            // 
            // SmoothMotorControlWithStepCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SmoothMotorControlWithStepCount";
            this.Size = new System.Drawing.Size(514, 294);
            this.Load += new System.EventHandler(this.SmoothMotorControlWithStepCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLimitSwitch;
        private System.Windows.Forms.Button buttonSetLimitLeft;
        private System.Windows.Forms.Button buttonSetLimitRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMaxRight;
        private System.Windows.Forms.Button buttonMaxLeft;
        private System.Windows.Forms.Button buttonDisableMotorDriver;
        private System.Windows.Forms.Button buttonEnableMotorDriver;
        private System.Windows.Forms.Button buttonStartProgram;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRepeat;
        private System.Windows.Forms.ComboBox comboBoxProgram;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonRampInfo;
        private System.Windows.Forms.Button buttonSpeed;
        private System.Windows.Forms.TextBox textBoxSpeed2;
    }
}
