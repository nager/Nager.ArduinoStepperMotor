namespace Nager.ArduinoStepperMotor.TestUI
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 100;
            this.trackBar1.Location = new System.Drawing.Point(66, 87);
            this.trackBar1.Maximum = 5000;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(393, 45);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 200;
            this.trackBar1.Value = 50;
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxReceive.Location = new System.Drawing.Point(471, 0);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ReadOnly = true;
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceive.Size = new System.Drawing.Size(367, 338);
            this.textBoxReceive.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 32);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(87, 32);
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
            this.trackBarSpeed.Location = new System.Drawing.Point(66, 25);
            this.trackBarSpeed.Maximum = 5000;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(393, 45);
            this.trackBarSpeed.SmallChange = 50;
            this.trackBarSpeed.TabIndex = 6;
            this.trackBarSpeed.TickFrequency = 200;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Speed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Steps:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Location = new System.Drawing.Point(22, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 73);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor Shield";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonMoveLeft);
            this.groupBox2.Controls.Add(this.buttonMoveRight);
            this.groupBox2.Location = new System.Drawing.Point(22, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 82);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Move";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 338);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.textBoxReceive);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Nager.ArduinoStepperMotor.TestUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
    }
}

