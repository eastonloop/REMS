namespace Environment_Monitoring_System_Interface
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.welcomeMessageBox = new System.Windows.Forms.TextBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeMessageBox
            // 
            this.welcomeMessageBox.Location = new System.Drawing.Point(246, 85);
            this.welcomeMessageBox.Multiline = true;
            this.welcomeMessageBox.Name = "welcomeMessageBox";
            this.welcomeMessageBox.Size = new System.Drawing.Size(311, 72);
            this.welcomeMessageBox.TabIndex = 2;
            this.welcomeMessageBox.Text = "Please ensure that the CPU is connected before continuing.";
            this.welcomeMessageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(320, 187);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(164, 64);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.welcomeMessageBox);
            this.Name = "Form1";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox welcomeMessageBox;
        private System.Windows.Forms.Button continueButton;
    }
}

