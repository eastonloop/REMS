using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Environment_Monitoring_System_Interface
{
    public partial class SettingsPageForm : Form
    {
        bool language = false;
        bool scale = false;
        double minValue;
        double maxValue;
        double maxMax = 100;
        double minMin = 32;
        int selectSens;
        bool tempHum = false;
        bool file = false;
        public SettingsPageForm()
        {
            InitializeComponent();
        }

        private void languageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageBox.Text == "Español")
            {
                language = true;

                label1.Text = "Ajustes";
                if (scaleBox.Text == "Temp Scale")
                    scaleBox.Text = "Escala de temperatura";
                label2.Text = "Límites";
                tempButton.Text = "Temperatura";
                humButton.Text = "humedad";
                minLabel.Text = "Mínimo";
                maxLabel.Text = "Máximo";
                submitButton.Text = "Entregar";
                emailLabel.Text = "Introduce tu correo electrónico";
                emailButton.Text = submitButton.Text;
                frequencyLabel.Text = "¿Con qué frecuencia le gustaría recibir alertas por correo electrónico?";
                if (frequencyBox.Text == "Select...")
                    frequencyBox.Text = "seleccionar...";
            }
        }

        private void scaleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scaleBox.Text == "Celsius")
            {
                scale = true;

                if (minTypeLabel.Text == "°F")
                {
                    minTypeLabel.Text = "°C";
                    maxTypeLabel.Text = "°C";
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (scale)
            {
                maxMax = 37.78;
                minMin = 1.67;
            }

            try
            {
                minValue = Convert.ToDouble(minBox.Text);
                maxValue = Convert.ToDouble(maxBox.Text);

                if (maxValue <= minValue || maxValue > maxMax || minValue < minMin)
                    throw new Exception();


            }
            catch (Exception ex)
            {
                minBox.Text = string.Empty;
                maxBox.Text = string.Empty;
                MessageBox.Show("Invalid values. Please try again with values between 0 and 100.");
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

        }
    }
}
