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
            this.buttonSetLimitRight = new System.Windows.Forms.Button();
            this.buttonSetLimitLeft = new System.Windows.Forms.Button();
            this.buttonLimitDisable = new System.Windows.Forms.Button();
            this.buttonLimitEnable = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStop.Location = new System.Drawing.Point(3, 172);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(508, 34);
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
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
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
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonRandom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 211);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 81);
            this.panel1.TabIndex = 19;
            // 
            // buttonSetLimitRight
            // 
            this.buttonSetLimitRight.Location = new System.Drawing.Point(176, 19);
            this.buttonSetLimitRight.Name = "buttonSetLimitRight";
            this.buttonSetLimitRight.Size = new System.Drawing.Size(81, 23);
            this.buttonSetLimitRight.TabIndex = 22;
            this.buttonSetLimitRight.Text = "Set right limit";
            this.buttonSetLimitRight.UseVisualStyleBackColor = true;
            this.buttonSetLimitRight.Click += new System.EventHandler(this.buttonSetLimitRight_Click);
            // 
            // buttonSetLimitLeft
            // 
            this.buttonSetLimitLeft.Location = new System.Drawing.Point(97, 19);
            this.buttonSetLimitLeft.Name = "buttonSetLimitLeft";
            this.buttonSetLimitLeft.Size = new System.Drawing.Size(73, 23);
            this.buttonSetLimitLeft.TabIndex = 21;
            this.buttonSetLimitLeft.Text = "Set left limit";
            this.buttonSetLimitLeft.UseVisualStyleBackColor = true;
            this.buttonSetLimitLeft.Click += new System.EventHandler(this.buttonSetLimitLeft_Click);
            // 
            // buttonLimitDisable
            // 
            this.buttonLimitDisable.Location = new System.Drawing.Point(8, 19);
            this.buttonLimitDisable.Name = "buttonLimitDisable";
            this.buttonLimitDisable.Size = new System.Drawing.Size(83, 23);
            this.buttonLimitDisable.TabIndex = 20;
            this.buttonLimitDisable.Text = "Disable Limit";
            this.buttonLimitDisable.UseVisualStyleBackColor = true;
            this.buttonLimitDisable.Click += new System.EventHandler(this.buttonLimitDisable_Click);
            // 
            // buttonLimitEnable
            // 
            this.buttonLimitEnable.Location = new System.Drawing.Point(8, 46);
            this.buttonLimitEnable.Name = "buttonLimitEnable";
            this.buttonLimitEnable.Size = new System.Drawing.Size(83, 23);
            this.buttonLimitEnable.TabIndex = 19;
            this.buttonLimitEnable.Text = "Enable Limit";
            this.buttonLimitEnable.UseVisualStyleBackColor = true;
            this.buttonLimitEnable.Click += new System.EventHandler(this.buttonLimitEnable_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(3, 3);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(111, 23);
            this.buttonRandom.TabIndex = 18;
            this.buttonRandom.Text = "Random drive";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonSetLimitRight);
            this.groupBox1.Controls.Add(this.buttonLimitEnable);
            this.groupBox1.Controls.Add(this.buttonLimitDisable);
            this.groupBox1.Controls.Add(this.buttonSetLimitLeft);
            this.groupBox1.Location = new System.Drawing.Point(244, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 75);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limits";
            // 
            // SmoothMotorControlWithStepCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SmoothMotorControlWithStepCount";
            this.Size = new System.Drawing.Size(514, 294);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLimitDisable;
        private System.Windows.Forms.Button buttonLimitEnable;
        private System.Windows.Forms.Button buttonSetLimitLeft;
        private System.Windows.Forms.Button buttonSetLimitRight;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
