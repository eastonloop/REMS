namespace Environment_Monitoring_System_Interface
{
    partial class SettingsPageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.scaleBox = new System.Windows.Forms.ComboBox();
            this.sensor1Button = new System.Windows.Forms.RadioButton();
            this.sensor2Button = new System.Windows.Forms.RadioButton();
            this.sensor3Button = new System.Windows.Forms.RadioButton();
            this.sensor4Button = new System.Windows.Forms.RadioButton();
            this.sensor5Button = new System.Windows.Forms.RadioButton();
            this.sensor6Button = new System.Windows.Forms.RadioButton();
            this.sensor7Button = new System.Windows.Forms.RadioButton();
            this.sensor8Button = new System.Windows.Forms.RadioButton();
            this.tempButton = new System.Windows.Forms.RadioButton();
            this.humButton = new System.Windows.Forms.RadioButton();
            this.minBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.minTypeLabel = new System.Windows.Forms.Label();
            this.maxTypeLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.frequencyBox = new System.Windows.Forms.ComboBox();
            this.emailButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileBox = new System.Windows.Forms.ComboBox();
            this.dailyEmailLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.noButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(415, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // languageBox
            // 
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            "English",
            "Español"});
            this.languageBox.Location = new System.Drawing.Point(12, 100);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(121, 28);
            this.languageBox.TabIndex = 1;
            this.languageBox.Text = "Languages";
            this.languageBox.SelectedIndexChanged += new System.EventHandler(this.languageBox_SelectedIndexChanged);
            // 
            // scaleBox
            // 
            this.scaleBox.FormattingEnabled = true;
            this.scaleBox.Items.AddRange(new object[] {
            "Fahrenheit",
            "Celsius"});
            this.scaleBox.Location = new System.Drawing.Point(139, 100);
            this.scaleBox.Name = "scaleBox";
            this.scaleBox.Size = new System.Drawing.Size(142, 28);
            this.scaleBox.TabIndex = 2;
            this.scaleBox.Text = "Temp Scale";
            this.scaleBox.SelectedIndexChanged += new System.EventHandler(this.scaleBox_SelectedIndexChanged);
            // 
            // sensor1Button
            // 
            this.sensor1Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor1Button.AutoSize = true;
            this.sensor1Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor1Button.Location = new System.Drawing.Point(6, 25);
            this.sensor1Button.Name = "sensor1Button";
            this.sensor1Button.Size = new System.Drawing.Size(83, 30);
            this.sensor1Button.TabIndex = 3;
            this.sensor1Button.TabStop = true;
            this.sensor1Button.Text = "Sensor 1";
            this.sensor1Button.UseVisualStyleBackColor = false;
            this.sensor1Button.CheckedChanged += new System.EventHandler(this.sensor1Button_CheckedChanged);
            // 
            // sensor2Button
            // 
            this.sensor2Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor2Button.AutoSize = true;
            this.sensor2Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor2Button.Location = new System.Drawing.Point(95, 25);
            this.sensor2Button.Name = "sensor2Button";
            this.sensor2Button.Size = new System.Drawing.Size(83, 30);
            this.sensor2Button.TabIndex = 4;
            this.sensor2Button.TabStop = true;
            this.sensor2Button.Text = "Sensor 2";
            this.sensor2Button.UseVisualStyleBackColor = false;
            this.sensor2Button.CheckedChanged += new System.EventHandler(this.sensor2Button_CheckedChanged);
            // 
            // sensor3Button
            // 
            this.sensor3Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor3Button.AutoSize = true;
            this.sensor3Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor3Button.Location = new System.Drawing.Point(184, 25);
            this.sensor3Button.Name = "sensor3Button";
            this.sensor3Button.Size = new System.Drawing.Size(83, 30);
            this.sensor3Button.TabIndex = 5;
            this.sensor3Button.TabStop = true;
            this.sensor3Button.Text = "Sensor 3";
            this.sensor3Button.UseVisualStyleBackColor = false;
            this.sensor3Button.CheckedChanged += new System.EventHandler(this.sensor3Button_CheckedChanged);
            // 
            // sensor4Button
            // 
            this.sensor4Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor4Button.AutoSize = true;
            this.sensor4Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor4Button.Location = new System.Drawing.Point(273, 25);
            this.sensor4Button.Name = "sensor4Button";
            this.sensor4Button.Size = new System.Drawing.Size(83, 30);
            this.sensor4Button.TabIndex = 6;
            this.sensor4Button.TabStop = true;
            this.sensor4Button.Text = "Sensor 4";
            this.sensor4Button.UseVisualStyleBackColor = false;
            this.sensor4Button.CheckedChanged += new System.EventHandler(this.sensor4Button_CheckedChanged);
            // 
            // sensor5Button
            // 
            this.sensor5Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor5Button.AutoSize = true;
            this.sensor5Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor5Button.Location = new System.Drawing.Point(6, 61);
            this.sensor5Button.Name = "sensor5Button";
            this.sensor5Button.Size = new System.Drawing.Size(83, 30);
            this.sensor5Button.TabIndex = 7;
            this.sensor5Button.TabStop = true;
            this.sensor5Button.Text = "Sensor 5";
            this.sensor5Button.UseVisualStyleBackColor = false;
            this.sensor5Button.CheckedChanged += new System.EventHandler(this.sensor5Button_CheckedChanged);
            // 
            // sensor6Button
            // 
            this.sensor6Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor6Button.AutoSize = true;
            this.sensor6Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor6Button.Location = new System.Drawing.Point(95, 61);
            this.sensor6Button.Name = "sensor6Button";
            this.sensor6Button.Size = new System.Drawing.Size(83, 30);
            this.sensor6Button.TabIndex = 8;
            this.sensor6Button.TabStop = true;
            this.sensor6Button.Text = "Sensor 6";
            this.sensor6Button.UseVisualStyleBackColor = false;
            this.sensor6Button.CheckedChanged += new System.EventHandler(this.sensor6Button_CheckedChanged);
            // 
            // sensor7Button
            // 
            this.sensor7Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor7Button.AutoSize = true;
            this.sensor7Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor7Button.Location = new System.Drawing.Point(184, 61);
            this.sensor7Button.Name = "sensor7Button";
            this.sensor7Button.Size = new System.Drawing.Size(83, 30);
            this.sensor7Button.TabIndex = 9;
            this.sensor7Button.TabStop = true;
            this.sensor7Button.Text = "Sensor 7";
            this.sensor7Button.UseVisualStyleBackColor = false;
            this.sensor7Button.CheckedChanged += new System.EventHandler(this.sensor7Button_CheckedChanged);
            // 
            // sensor8Button
            // 
            this.sensor8Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.sensor8Button.AutoSize = true;
            this.sensor8Button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sensor8Button.Location = new System.Drawing.Point(273, 61);
            this.sensor8Button.Name = "sensor8Button";
            this.sensor8Button.Size = new System.Drawing.Size(83, 30);
            this.sensor8Button.TabIndex = 10;
            this.sensor8Button.TabStop = true;
            this.sensor8Button.Text = "Sensor 8";
            this.sensor8Button.UseVisualStyleBackColor = false;
            this.sensor8Button.CheckedChanged += new System.EventHandler(this.sensor8Button_CheckedChanged);
            // 
            // tempButton
            // 
            this.tempButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.tempButton.AutoSize = true;
            this.tempButton.BackColor = System.Drawing.SystemColors.Info;
            this.tempButton.Location = new System.Drawing.Point(6, 19);
            this.tempButton.Name = "tempButton";
            this.tempButton.Size = new System.Drawing.Size(110, 30);
            this.tempButton.TabIndex = 11;
            this.tempButton.TabStop = true;
            this.tempButton.Text = "Temperature";
            this.tempButton.UseVisualStyleBackColor = false;
            this.tempButton.CheckedChanged += new System.EventHandler(this.tempButton_CheckedChanged);
            // 
            // humButton
            // 
            this.humButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.humButton.AutoSize = true;
            this.humButton.BackColor = System.Drawing.SystemColors.Info;
            this.humButton.Location = new System.Drawing.Point(194, 19);
            this.humButton.Name = "humButton";
            this.humButton.Size = new System.Drawing.Size(80, 30);
            this.humButton.TabIndex = 12;
            this.humButton.TabStop = true;
            this.humButton.Text = "Humidity";
            this.humButton.UseVisualStyleBackColor = false;
            this.humButton.CheckedChanged += new System.EventHandler(this.humButton_CheckedChanged);
            // 
            // minBox
            // 
            this.minBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minBox.Location = new System.Drawing.Point(618, 344);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(73, 35);
            this.minBox.TabIndex = 13;
            this.minBox.TextChanged += new System.EventHandler(this.minBox_TextChanged);
            // 
            // maxBox
            // 
            this.maxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBox.Location = new System.Drawing.Point(802, 344);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(73, 35);
            this.maxBox.TabIndex = 14;
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLabel.Location = new System.Drawing.Point(630, 309);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(52, 29);
            this.minLabel.TabIndex = 15;
            this.minLabel.Text = "Min";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxLabel.Location = new System.Drawing.Point(805, 309);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(57, 29);
            this.maxLabel.TabIndex = 16;
            this.maxLabel.Text = "Max";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(688, 398);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(134, 54);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(687, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Thresholds";
            // 
            // minTypeLabel
            // 
            this.minTypeLabel.AutoSize = true;
            this.minTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTypeLabel.Location = new System.Drawing.Point(697, 347);
            this.minTypeLabel.Name = "minTypeLabel";
            this.minTypeLabel.Size = new System.Drawing.Size(36, 29);
            this.minTypeLabel.TabIndex = 19;
            this.minTypeLabel.Text = "°F";
            // 
            // maxTypeLabel
            // 
            this.maxTypeLabel.AutoSize = true;
            this.maxTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTypeLabel.Location = new System.Drawing.Point(881, 347);
            this.maxTypeLabel.Name = "maxTypeLabel";
            this.maxTypeLabel.Size = new System.Drawing.Size(36, 29);
            this.maxTypeLabel.TabIndex = 20;
            this.maxTypeLabel.Text = "°F";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(111, 179);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(195, 29);
            this.emailLabel.TabIndex = 21;
            this.emailLabel.Text = "Enter your Email:";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frequencyLabel.Location = new System.Drawing.Point(12, 354);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(306, 58);
            this.frequencyLabel.TabIndex = 22;
            this.frequencyLabel.Text = "How often would you like to\r\n receive email alerts?";
            this.frequencyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(58, 240);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(301, 35);
            this.textBox3.TabIndex = 23;
            // 
            // frequencyBox
            // 
            this.frequencyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frequencyBox.FormattingEnabled = true;
            this.frequencyBox.Items.AddRange(new object[] {
            "2 hrs",
            "4 hrs",
            "6 hrs",
            "12 hrs",
            "No Alerts"});
            this.frequencyBox.Location = new System.Drawing.Point(134, 427);
            this.frequencyBox.Name = "frequencyBox";
            this.frequencyBox.Size = new System.Drawing.Size(141, 37);
            this.frequencyBox.TabIndex = 24;
            this.frequencyBox.Text = "Select...";
            this.frequencyBox.SelectedIndexChanged += new System.EventHandler(this.frequencyBox_SelectedIndexChanged);
            // 
            // emailButton
            // 
            this.emailButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.emailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailButton.Location = new System.Drawing.Point(154, 296);
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(99, 46);
            this.emailButton.TabIndex = 25;
            this.emailButton.Text = "Submit";
            this.emailButton.UseVisualStyleBackColor = false;
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sensor1Button);
            this.groupBox1.Controls.Add(this.sensor2Button);
            this.groupBox1.Controls.Add(this.sensor3Button);
            this.groupBox1.Controls.Add(this.sensor4Button);
            this.groupBox1.Controls.Add(this.sensor5Button);
            this.groupBox1.Controls.Add(this.sensor6Button);
            this.groupBox1.Controls.Add(this.sensor7Button);
            this.groupBox1.Controls.Add(this.sensor8Button);
            this.groupBox1.Location = new System.Drawing.Point(571, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 107);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tempButton);
            this.groupBox2.Controls.Add(this.humButton);
            this.groupBox2.Location = new System.Drawing.Point(616, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 59);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // fileBox
            // 
            this.fileBox.FormattingEnabled = true;
            this.fileBox.Items.AddRange(new object[] {
            ".csv",
            ".xlsx"});
            this.fileBox.Location = new System.Drawing.Point(287, 100);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(121, 28);
            this.fileBox.TabIndex = 28;
            this.fileBox.Text = "File Type";
            this.fileBox.SelectedIndexChanged += new System.EventHandler(this.fileBox_SelectedIndexChanged);
            // 
            // dailyEmailLabel
            // 
            this.dailyEmailLabel.AutoSize = true;
            this.dailyEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyEmailLabel.Location = new System.Drawing.Point(331, 354);
            this.dailyEmailLabel.Name = "dailyEmailLabel";
            this.dailyEmailLabel.Size = new System.Drawing.Size(281, 58);
            this.dailyEmailLabel.TabIndex = 29;
            this.dailyEmailLabel.Text = "Would you like to receive\r\ndaily reports?";
            this.dailyEmailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dailyEmailLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // yesButton
            // 
            this.yesButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.yesButton.AutoSize = true;
            this.yesButton.Location = new System.Drawing.Point(6, 21);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(47, 30);
            this.yesButton.TabIndex = 30;
            this.yesButton.TabStop = true;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.CheckedChanged += new System.EventHandler(this.yesButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noButton);
            this.groupBox3.Controls.Add(this.yesButton);
            this.groupBox3.Location = new System.Drawing.Point(401, 418);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(137, 57);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // noButton
            // 
            this.noButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.noButton.AutoSize = true;
            this.noButton.Location = new System.Drawing.Point(92, 21);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(39, 30);
            this.noButton.TabIndex = 31;
            this.noButton.TabStop = true;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.CheckedChanged += new System.EventHandler(this.noButton_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clearButton.Location = new System.Drawing.Point(705, 463);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 41);
            this.clearButton.TabIndex = 32;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // SettingsPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 541);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dailyEmailLabel);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.emailButton);
            this.Controls.Add(this.frequencyBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.maxTypeLabel);
            this.Controls.Add(this.minTypeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.scaleBox);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.label1);
            this.Name = "SettingsPageForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsPageForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.ComboBox scaleBox;
        private System.Windows.Forms.RadioButton sensor1Button;
        private System.Windows.Forms.RadioButton sensor2Button;
        private System.Windows.Forms.RadioButton sensor3Button;
        private System.Windows.Forms.RadioButton sensor4Button;
        private System.Windows.Forms.RadioButton sensor5Button;
        private System.Windows.Forms.RadioButton sensor6Button;
        private System.Windows.Forms.RadioButton sensor7Button;
        private System.Windows.Forms.RadioButton sensor8Button;
        private System.Windows.Forms.RadioButton tempButton;
        private System.Windows.Forms.RadioButton humButton;
        private System.Windows.Forms.TextBox minBox;
        private System.Windows.Forms.TextBox maxBox;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minTypeLabel;
        private System.Windows.Forms.Label maxTypeLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox frequencyBox;
        private System.Windows.Forms.Button emailButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox fileBox;
        private System.Windows.Forms.Label dailyEmailLabel;
        private System.Windows.Forms.RadioButton yesButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton noButton;
        private System.Windows.Forms.Button clearButton;
    }
}