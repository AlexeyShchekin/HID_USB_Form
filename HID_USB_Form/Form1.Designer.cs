namespace HID_USB_Form
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.TextBox();
            this.channelBox = new System.Windows.Forms.TextBox();
            this.pwmBox = new System.Windows.Forms.TextBox();
            this.buttonUSBcmd = new System.Windows.Forms.Button();
            this.USBcmdTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(11, 119);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(82, 29);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(198, 12);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(410, 481);
            this.logBox.TabIndex = 6;
            // 
            // channelBox
            // 
            this.channelBox.Location = new System.Drawing.Point(10, 197);
            this.channelBox.Name = "channelBox";
            this.channelBox.Size = new System.Drawing.Size(100, 20);
            this.channelBox.TabIndex = 7;
            this.channelBox.Text = "2";
            // 
            // pwmBox
            // 
            this.pwmBox.Location = new System.Drawing.Point(10, 229);
            this.pwmBox.Name = "pwmBox";
            this.pwmBox.Size = new System.Drawing.Size(100, 20);
            this.pwmBox.TabIndex = 8;
            this.pwmBox.Text = "139";
            // 
            // buttonUSBcmd
            // 
            this.buttonUSBcmd.Location = new System.Drawing.Point(115, 197);
            this.buttonUSBcmd.Name = "buttonUSBcmd";
            this.buttonUSBcmd.Size = new System.Drawing.Size(65, 52);
            this.buttonUSBcmd.TabIndex = 9;
            this.buttonUSBcmd.Text = "USB cmd";
            this.buttonUSBcmd.UseVisualStyleBackColor = true;
            this.buttonUSBcmd.Click += new System.EventHandler(this.buttonUSBcmd_Click);
            // 
            // USBcmdTimer
            // 
            this.USBcmdTimer.Enabled = true;
            this.USBcmdTimer.Interval = 10;
            this.USBcmdTimer.Tick += new System.EventHandler(this.USBcmdTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 505);
            this.Controls.Add(this.buttonUSBcmd);
            this.Controls.Add(this.pwmBox);
            this.Controls.Add(this.channelBox);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.TextBox channelBox;
        private System.Windows.Forms.TextBox pwmBox;
        private System.Windows.Forms.Button buttonUSBcmd;
        private System.Windows.Forms.Timer USBcmdTimer;
    }
}

