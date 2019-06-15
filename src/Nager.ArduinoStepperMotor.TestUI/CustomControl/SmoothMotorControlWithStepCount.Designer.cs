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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSpeed.Location = new System.Drawing.Point(4, 4);
            this.textBoxSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(677, 22);
            this.textBoxSpeed.TabIndex = 17;
            this.textBoxSpeed.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStop.Location = new System.Drawing.Point(4, 127);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(677, 182);
            this.buttonStop.TabIndex = 16;
            this.buttonStop.TabStop = false;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSpeed.Location = new System.Drawing.Point(4, 53);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarSpeed.Maximum = 255;
            this.trackBarSpeed.Minimum = -255;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(677, 66);
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 362);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSetLimitRight);
            this.panel1.Controls.Add(this.buttonSetLimitLeft);
            this.panel1.Controls.Add(this.buttonLimitDisable);
            this.panel1.Controls.Add(this.buttonLimitEnable);
            this.panel1.Controls.Add(this.buttonRandom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 43);
            this.panel1.TabIndex = 19;
            // 
            // buttonSetLimitRight
            // 
            this.buttonSetLimitRight.Location = new System.Drawing.Point(498, 4);
            this.buttonSetLimitRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetLimitRight.Name = "buttonSetLimitRight";
            this.buttonSetLimitRight.Size = new System.Drawing.Size(108, 28);
            this.buttonSetLimitRight.TabIndex = 22;
            this.buttonSetLimitRight.Text = "Limit Right";
            this.buttonSetLimitRight.UseVisualStyleBackColor = true;
            this.buttonSetLimitRight.Click += new System.EventHandler(this.buttonSetLimitRight_Click);
            // 
            // buttonSetLimitLeft
            // 
            this.buttonSetLimitLeft.Location = new System.Drawing.Point(398, 4);
            this.buttonSetLimitLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetLimitLeft.Name = "buttonSetLimitLeft";
            this.buttonSetLimitLeft.Size = new System.Drawing.Size(92, 28);
            this.buttonSetLimitLeft.TabIndex = 21;
            this.buttonSetLimitLeft.Text = "Limit Left";
            this.buttonSetLimitLeft.UseVisualStyleBackColor = true;
            this.buttonSetLimitLeft.Click += new System.EventHandler(this.buttonSetLimitLeft_Click);
            // 
            // buttonLimitDisable
            // 
            this.buttonLimitDisable.Location = new System.Drawing.Point(279, 4);
            this.buttonLimitDisable.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLimitDisable.Name = "buttonLimitDisable";
            this.buttonLimitDisable.Size = new System.Drawing.Size(111, 28);
            this.buttonLimitDisable.TabIndex = 20;
            this.buttonLimitDisable.Text = "Limit Disable";
            this.buttonLimitDisable.UseVisualStyleBackColor = true;
            this.buttonLimitDisable.Click += new System.EventHandler(this.buttonLimitDisable_Click);
            // 
            // buttonLimitEnable
            // 
            this.buttonLimitEnable.Location = new System.Drawing.Point(160, 4);
            this.buttonLimitEnable.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLimitEnable.Name = "buttonLimitEnable";
            this.buttonLimitEnable.Size = new System.Drawing.Size(111, 28);
            this.buttonLimitEnable.TabIndex = 19;
            this.buttonLimitEnable.Text = "Limit Enable";
            this.buttonLimitEnable.UseVisualStyleBackColor = true;
            this.buttonLimitEnable.Click += new System.EventHandler(this.buttonLimitEnable_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(4, 4);
            this.buttonRandom.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(148, 28);
            this.buttonRandom.TabIndex = 18;
            this.buttonRandom.Text = "Random drive";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // SmoothMotorControlWithStepCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SmoothMotorControlWithStepCount";
            this.Size = new System.Drawing.Size(685, 362);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
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
    }
}
