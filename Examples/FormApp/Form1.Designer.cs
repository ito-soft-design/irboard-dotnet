namespace FormApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            startButton = new Button();
            stopButton = new Button();
            label1 = new Label();
            countLabel = new Label();
            resetButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            ipAddressListBox = new ListBox();
            label3 = new Label();
            monitorTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startButton.Location = new Point(590, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(198, 91);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stopButton.Location = new Point(590, 120);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(198, 91);
            stopButton.TabIndex = 1;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 340);
            label1.Name = "label1";
            label1.Size = new Size(79, 32);
            label1.TabIndex = 2;
            label1.Text = "Count";
            // 
            // countLabel
            // 
            countLabel.Location = new Point(178, 340);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(201, 38);
            countLabel.TabIndex = 3;
            countLabel.Text = "0";
            countLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resetButton.Location = new Point(590, 229);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(198, 91);
            resetButton.TabIndex = 4;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // ipAddressListBox
            // 
            ipAddressListBox.FormattingEnabled = true;
            ipAddressListBox.ItemHeight = 32;
            ipAddressListBox.Location = new Point(58, 61);
            ipAddressListBox.Name = "ipAddressListBox";
            ipAddressListBox.Size = new Size(490, 132);
            ipAddressListBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 25);
            label3.Name = "label3";
            label3.Size = new Size(255, 32);
            label3.TabIndex = 6;
            label3.Text = "Listening IP Addresses:";
            // 
            // monitorTimer
            // 
            monitorTimer.Enabled = true;
            monitorTimer.Tick += monitorTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(ipAddressListBox);
            Controls.Add(resetButton);
            Controls.Add(countLabel);
            Controls.Add(label1);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Label label1;
        private Label countLabel;
        private Button resetButton;
        private System.Windows.Forms.Timer timer;
        private ListBox ipAddressListBox;
        private Label label3;
        private System.Windows.Forms.Timer monitorTimer;
    }
}