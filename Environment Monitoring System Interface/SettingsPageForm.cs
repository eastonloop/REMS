using System;
using System.Windows.Forms;

namespace Environment_Monitoring_System_Interface
{
    public partial class SettingsPageForm : Form
    {
        public bool language = false;
        public bool scale = false;
        double minValue;
        double maxValue;
        double maxMax = 85;
        double minMin = 25;

        int selectSens;
        bool tempHum = false;
        public bool file = false;
        public int freq;
        public string emailAddress;
        public bool noAlert = true;

        public Sensor sensor1 { get; set; }
        public Sensor sensor2 { get; set; }
        public Sensor sensor3 { get; set; }
        public Sensor sensor4 { get; set; }
        public Sensor sensor5 { get; set; }
        public Sensor sensor6 { get; set; }
        public Sensor sensor7 { get; set; }
        public Sensor sensor8 { get; set; }

        public SettingsPageForm()
        {
            InitializeComponent();
        }

        private void languageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex == 1)
            {
                language = true;

                label1.Text = "Ajustes";
                if (scaleBox.Text == "Temp Scale")
                    scaleBox.Text = "Escala de temperatura";
                if (fileBox.Text == "File Type")
                    fileBox.Text = "Tipo de Archivo";
                label2.Text = "Límites";
                tempButton.Text = "Temperatura";
                humButton.Text = "Humedad";
                minLabel.Text = "Mínimo";
                maxLabel.Text = "Máximo";
                submitButton.Text = "Entregar";
                emailLabel.Text = "Introduce tu correo electrónico:";
                emailButton.Text = submitButton.Text;
                frequencyLabel.Text = "¿Con qué frecuencia le gustaría \n recibir alertas por correo electrónico?";
                if (frequencyBox.Text == "Select...")
                    frequencyBox.Text = "Seleccionar...";
            }
            else
            {
                language = false;

                label1.Text = "Settings";
                if (scaleBox.Text == "Escala de temperatura")
                    scaleBox.Text = "Temp Scale";
                if (fileBox.Text == "Tipo de Archivo")
                    fileBox.Text = "File Type";
                label2.Text = "Thresholds";
                tempButton.Text = "Temperature";
                humButton.Text = "Humidity";
                minLabel.Text = "Min";
                maxLabel.Text = "Max";
                submitButton.Text = "Submit";
                emailLabel.Text = "Enter your Email:";
                emailButton.Text = submitButton.Text;
                frequencyLabel.Text = "How often would you like to \n receive email alerts?";
                if (frequencyBox.Text == "Seleccionar...")
                    frequencyBox.Text = "Select...";
            }
        }

        private void scaleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scaleBox.SelectedIndex == 1)
            {
                scale = true;

                minTypeLabel.Text = "°C";
                maxTypeLabel.Text = "°C";
            }
            else
            {
                scale = false;

                minTypeLabel.Text = "°F";
                maxTypeLabel.Text = "°F";
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (tempHum)
            {
                maxMax = 70;
                minMin = 30;
            }
            else
            {
                if (scale)
                {
                    maxMax = 29.44;
                    minMin = -3.89;
                }
                else
                {
                    maxMax = 85;
                    minMin = 25;
                }
            }

            try
            {
                minValue = Convert.ToDouble(minBox.Text);
                maxValue = Convert.ToDouble(maxBox.Text);

                if (maxValue <= minValue || maxValue > maxMax || minValue < minMin)
                {
                    throw new Exception();
                }
                else
                {
                    switch (selectSens)
                    {
                        case 1:
                            sensor1.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 2:
                            sensor2.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 3:
                            sensor3.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 4:
                            sensor4.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 5:
                            sensor5.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 6:
                            sensor6.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 7:
                            sensor7.setThresh(minValue, maxValue, tempHum);
                            break;
                        case 8:
                            sensor8.setThresh(minValue, maxValue, tempHum);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                minBox.Text = string.Empty;
                maxBox.Text = string.Empty;
                if (tempHum)
                {
                    if (language)
                        MessageBox.Show("Valores no válidos. Inténtelo de nuevo con valores entre 0 y 100.");
                    else
                        MessageBox.Show("Invalid values. Please try again with values between 30 and 70.");
                }
                else
                {
                    if (scale)
                    {
                        if (language)
                            MessageBox.Show("Valores no válidos. Inténtelo de nuevo con valores entre -3.5 y 29.");
                        else
                            MessageBox.Show("Invalid values. Please try again with values between -3.5 and 29.");
                    }
                    else
                    {
                        if (language)
                            MessageBox.Show("Valores no válidos. Inténtelo de nuevo con valores entre 25 y 85.");
                        else
                            MessageBox.Show("Invalid values. Please try again with values between 25 and 85.");
                    }
                }
            }
        }

        private void sensor1Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 1;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor2Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 2;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor3Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 3;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor4Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 4;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor5Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 5;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor6Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 6;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor7Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 7;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void sensor8Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 8;
            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;
        }

        private void tempButton_CheckedChanged(object sender, EventArgs e)
        {
            tempHum = false;

            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;

            if (scale)
            {
                minTypeLabel.Text = "°C";
                maxTypeLabel.Text = "°C";
            }
            else
            {
                minTypeLabel.Text = "°F";
                maxTypeLabel.Text = "°F";
            }
        }

        private void humButton_CheckedChanged(object sender, EventArgs e)
        {
            tempHum = true;

            minBox.Text = string.Empty;
            maxBox.Text = string.Empty;

            minTypeLabel.Text = "%";
            maxTypeLabel.Text = "%";
        }

        private void fileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileBox.SelectedIndex == 1)
                file = true;
            else if (fileBox.SelectedIndex == 0)
                file = false;
        }

        private void frequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (frequencyBox.SelectedIndex)
            {
                case 0:
                    freq = 2;
                    if (!(emailAddress == null))
                        noAlert = false;
                    break;
                case 1:
                    freq = 4;
                    if (!(emailAddress == null))
                        noAlert = false;
                    break;
                case 2:
                    freq = 6;
                    if (!(emailAddress == null))
                        noAlert = false;
                    break;
                case 3:
                    freq = 12;
                    if (!(emailAddress == null))
                        noAlert = false;
                    break;
                default:
                    noAlert = true;
                    break;
            }
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            emailAddress = textBox3.Text;
        }
    }
}
