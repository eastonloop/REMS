using System;
using System.Windows.Forms;

namespace Environment_Monitoring_System_Interface
{
    public partial class SettingsPageForm : Form
    {
        double minValue;
        double maxValue;
        double maxMax = 85;
        double minMin = 25;
        
        int selectSens = 10;
        bool tempHum = false;
       
        public Sensor sensor1 { get; set; }
        public Sensor sensor2 { get; set; }
        public Sensor sensor3 { get; set; }
        public Sensor sensor4 { get; set; }
        public Sensor sensor5 { get; set; }
        public Sensor sensor6 { get; set; }
        public Sensor sensor7 { get; set; }
        public Sensor sensor8 { get; set; }

        private HomePageForm form;

        public SettingsPageForm(HomePageForm HomePageForm)
        {
            InitializeComponent();
            form = HomePageForm;
            textBox3.Text = form.EmailAddress;
            if (form.fileType)
            {
                fileBox.SelectedIndex = 1;
            }
            else
            {
                fileBox.SelectedIndex = 0;
            }
        }

        private void languageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex == 1)
            {
                form.languageType = true;

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
                form.languageType = false;

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
                form.scaleType = true;
                
                minTypeLabel.Text = "°C";
                maxTypeLabel.Text = "°C";
            }
            else
            {
                form.scaleType = false;

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
                if (form.scaleType)
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
                    if (form.languageType)
                        MessageBox.Show("Valores no válidos. Inténtelo de nuevo con valores entre 0 y 100.");
                    else
                        MessageBox.Show("Invalid values. Please try again with values between 30 and 70.");
                }
                else
                {
                    if (form.scaleType)
                    {
                        if (form.languageType)
                            MessageBox.Show("Valores no válidos. Inténtelo de nuevo con valores entre -3.5 y 29.");
                        else
                            MessageBox.Show("Invalid values. Please try again with values between -3.5 and 29.");
                    }
                    else
                    {
                        if (form.languageType)
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
            getTempThresh(sensor1, tempHum);
        }

        private void sensor2Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 2;
            getTempThresh(sensor2, tempHum);
        }

        private void sensor3Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 3;
            getTempThresh(sensor3, tempHum);
        }

        private void sensor4Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 4;
            getTempThresh(sensor4, tempHum);
        }

        private void sensor5Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 5;
            getTempThresh(sensor5, tempHum);
        }

        private void sensor6Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 6;
            getTempThresh(sensor6, tempHum);
        }

        private void sensor7Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 7;
            getTempThresh(sensor7, tempHum);
        }

        private void sensor8Button_CheckedChanged(object sender, EventArgs e)
        {
            selectSens = 8;
            getTempThresh(sensor8, tempHum);
        }

        private void tempButton_CheckedChanged(object sender, EventArgs e)
        {
            tempHum = false;

            switch (selectSens)
            {
                case 1: getTempThresh(sensor1, tempHum); break;
                case 2: getTempThresh(sensor2, tempHum); break;
                case 3: getTempThresh(sensor3, tempHum); break;
                case 4: getTempThresh(sensor4, tempHum); break;
                case 5: getTempThresh(sensor5, tempHum); break;
                case 6: getTempThresh(sensor6, tempHum); break;
                case 7: getTempThresh(sensor7, tempHum); break;
                case 8: getTempThresh(sensor8, tempHum); break;
                default: break;
            }   

            if (form.scaleType)
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

            switch(selectSens)
            {
                case 1: getTempThresh(sensor1,tempHum); break;
                case 2: getTempThresh(sensor2,tempHum); break;
                case 3: getTempThresh(sensor3,tempHum); break;
                case 4: getTempThresh(sensor4,tempHum); break;
                case 5: getTempThresh(sensor5,tempHum); break;
                case 6: getTempThresh(sensor6,tempHum); break;
                case 7: getTempThresh(sensor7,tempHum); break;
                case 8: getTempThresh(sensor8,tempHum); break;
                default: break;
            }
            
            minTypeLabel.Text = "%";
            maxTypeLabel.Text = "%";
        }

        private void fileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileBox.SelectedIndex == 1)
                form.fileType = true;
            else if (fileBox.SelectedIndex == 0)
                form.fileType = false;
        }

        private void frequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (frequencyBox.SelectedIndex)
            {
                case 0:
                    form.freqType = 2;
                    if (!(form.EmailAddress == null))
                        form.noAlertType = false;
                    break;
                case 1:
                    form.freqType = 4;
                    if (!(form.EmailAddress == null))
                        form.noAlertType = false;
                    break;
                case 2:
                    form.freqType = 6;
                    if (!(form.EmailAddress == null))
                        form.noAlertType = false;
                    break;
                case 3:
                    form.freqType = 12;
                    if (!(form.EmailAddress == null))
                        form.noAlertType = false;
                    break;
                case 4:
                    form.noAlertType = true;
                    break;
                default:
                    form.noAlertType = true;
                    break;
            }
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            form.EmailAddress = textBox3.Text;
        }

        private void settingsPageForm_Closing(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }
        private void getTempThresh(Sensor sensor, bool tempHum )
        {
            if((sensor.minTemp != -5) && !tempHum)
            {
                minBox.Text = Convert.ToString(sensor.minTemp);
                maxBox.Text = Convert.ToString(sensor.maxTemp);
            }
            else if ((sensor.minHum != -5) && tempHum)
            {
                minBox.Text = Convert.ToString(sensor.minHum);
                maxBox.Text = Convert.ToString(sensor.maxHum);
            }
            else
            {
                minBox.Text = string.Empty;
                maxBox.Text = string.Empty;
            }
        }

        private void SettingsPageForm_Load(object sender, EventArgs e)
        {

        }

        private void yesButton_CheckedChanged(object sender, EventArgs e)
        {
            form.yesNoType = true;
        }

        private void noButton_CheckedChanged(object sender, EventArgs e)
        {
            form.yesNoType = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            switch (selectSens)
            {
                case 1:
                    sensor1.setThresh(-5, 100, tempHum);
                    break;
                case 2:
                    sensor2.setThresh(-5, 100, tempHum);
                    break;
                case 3:
                    sensor3.setThresh(-5, 100, tempHum);
                    break;
                case 4:
                    sensor4.setThresh(-5, 100, tempHum);
                    break;
                case 5:
                    sensor5.setThresh(-5, 100, tempHum);
                    break;
                case 6:
                    sensor6.setThresh(-5, 100, tempHum);
                    break;
                case 7:
                    sensor7.setThresh(-5, 100, tempHum);
                    break;
                case 8:
                    sensor8.setThresh(-5, 100, tempHum);
                    break;
            }
        }
    }
}
