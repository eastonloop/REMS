using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Reflection.Emit;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Vml;
using System.Runtime.Remoting.Messaging;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO.Packaging;
using System.Media;
using System.Windows.Media;
using OfficeOpenXml.Drawing.Chart.Style;
using DocumentFormat.OpenXml.Drawing;

namespace Environment_Monitoring_System_Interface
{
    public partial class HomePageForm : Form
    {
        private string[] transmitData;
        private int whichSens;
        string message;
        private SerialPort pigeon;
        private Thread serialThread;
        private Thread attourney;
        private Thread lawyer;
        private Thread paperBoy;
        private Thread whistleTemp1;
        private Thread whistleTemp2;
        private Thread whistleTemp3;
        private Thread whistleTemp4;
        private Thread whistleTemp5;
        private Thread whistleTemp6;
        private Thread whistleTemp7;
        private Thread whistleTemp8;
        private Thread whistleHum1;
        private Thread whistleHum2;
        private Thread whistleHum3;
        private Thread whistleHum4;
        private Thread whistleHum5;
        private Thread whistleHum6;
        private Thread whistleHum7;
        private Thread whistleHum8;
        private Thread whistleBat1;
        private Thread whistleBat2;
        private Thread whistleBat3;
        private Thread whistleBat4;
        private Thread whistleBat5;
        private Thread whistleBat6;
        private Thread whistleBat7;
        private Thread whistleBat8;
        private Thread theBritishAreComing;
        private Thread protester;
        private Thread hellmo;
        private CancellationTokenSource cancellationTokenSource= new CancellationTokenSource();
        public string theDate;

        private List<double> tempDay;
        private List<double> humDay;
        private List<double> batDay;
        public string path;
        public List<string> csvData;
        private string timeText;
        private bool firstExcel = true;

        private bool settingsExist = false;
        SettingsPageForm newGuy;
        public bool waitToSet;

        public SerialPort SerialPort
        {
            get { return pigeon; }
            set { pigeon = value; }
        }

        public List<Sensor> sensors = new List<Sensor>();

        Sensor sensor1 = new Sensor(1);
        Sensor sensor2 = new Sensor(2);
        Sensor sensor3 = new Sensor(3);
        Sensor sensor4 = new Sensor(4);
        Sensor sensor5 = new Sensor(5);
        Sensor sensor6 = new Sensor(6);
        Sensor sensor7 = new Sensor(7);
        Sensor sensor8 = new Sensor(8);

        int s1count = 0;
        int s2count = 0;
        int s3count = 0;
        int s4count = 0;
        int s5count = 0;
        int s6count = 0;
        int s7count = 0;
        int s8count = 0;



        public int count = 1;
       
        public bool scale = false;
        public bool language = false;
        public bool file = false;
        public int freq = 2;
        private string _emailAddress;

        public bool scaleType
        {
            get { return scale; }
            set { scale = value; }
        }

        public bool languageType
        {
            get { return language; }
            set { language = value; }
        }

        public bool fileType
        {
            get { return file; }
            set { file = value; }
        }

        public int freqType
        {
            get { return freq; }
            set { freq = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public string tempType;
        public string batText;
        public bool noAlert;

        public bool noAlertType
        {
            get { return noAlert; }
            set { noAlert = value; }
        }

        private System.Threading.Timer sequenceTime;
        private bool red = true;
        int i = 0;
        private SoundPlayer soundPlayer;


        private void doStuff()
        {
            pigeon.DataReceived += ListenUp;
        }

        private void ListenUp(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (pigeon.BytesToRead > 0)
                {
                    message = pigeon.ReadLine();
                    if (message != "\r")
                    {
                        PigeonDataReceived(message);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        private void PigeonDataReceived(string message)
        {
            transmitData = message.Split(':');

            whichSens = Convert.ToInt16(transmitData[0]);
            string messagesDelivered = transmitData[5];
            string attempts = transmitData[6];
            string totalRetries = transmitData[7];

            switch (whichSens)
            {
                case 1:
                    s1count++;

                    pc1.Invoke((MethodInvoker)delegate
                    {
                        pc1.Text = Convert.ToString(s1count);
                    });

                    sensor1.addData(transmitData, scale);

                    temp1Box.Invoke((MethodInvoker)delegate
                    {
                        temp1Box.Text = Convert.ToString(Math.Round(sensor1.holdTemp));
                    });

                    hum1Box.Invoke((MethodInvoker)delegate
                    {
                        hum1Box.Text = Convert.ToString(Math.Round(sensor1.holdHum));
                    });

                    bat1Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor1.bat < 2.42 && sensor1.bat > 1 && language)
                        {
                            bat1Label.Text = "Batería baja";
                            bat1Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor1.bat < 2.42 && sensor1.bat > 1 && !language)
                        {
                            bat1Label.Text = "Low battery";
                            bat1Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat1Label.Text = "";
                            bat1Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });
                    label1.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = messagesDelivered;
                    });
                    label2.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = attempts;
                    });
                    label3.Invoke((MethodInvoker)delegate
                    {
                        label3.Text = totalRetries;
                    });

                    sensor1Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor1.esm == 1)
                        sensor1Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor1.esm == 0)
                        sensor1Label.BackColor = System.Drawing.Color.Gold;

                    sensor1.checkTemp();

                    if (sensor1.breachTemp && !sensor1.standbyTemp)
                    {
                        sensor1.standbyTemp = true;
                        if (whistleTemp1 == null)
                            whistleTemp1 = new Thread(() => Alert(sensor1, false));
                        whistleTemp1.Start();
                    }

                    sensor1.checkHum();

                    if (sensor1.breachHum && !sensor1.standbyHum)
                    {
                        sensor1.standbyHum = true;
                        if (whistleHum1 == null)
                            whistleHum1 = new Thread(() => Alert(sensor1, true));
                        whistleHum1.Start();
                    }

                    if (sensor1.bat < 2.42 && sensor1.bat > 1)
                    {
                        if (whistleBat1 == null)
                        {
                            whistleBat1 = new Thread(() => AlertBat(sensor1));
                            whistleBat1.Start();
                        }
                    }

                    break;
                case 2:

                    s2count++;

                    pc2.Invoke((MethodInvoker)delegate
                    {
                        pc2.Text = Convert.ToString(s2count);
                    });

                    sensor2.addData(transmitData, scale);

                    temp2Box.Invoke((MethodInvoker)delegate
                    {
                        temp2Box.Text = Convert.ToString(Math.Round(sensor2.holdTemp));
                    });

                    hum2Box.Invoke((MethodInvoker)delegate
                    {
                        hum2Box.Text = Convert.ToString(Math.Round(sensor2.holdHum));
                    });

                    label4.Invoke((MethodInvoker)delegate
                    {
                        label4.Text = messagesDelivered;
                    });
                    label5.Invoke((MethodInvoker)delegate
                    {
                        label5.Text = attempts;
                    });
                    label6.Invoke((MethodInvoker)delegate
                    {
                        label6.Text = totalRetries;
                    });

                    bat2Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor2.bat < 2.42 && sensor2.bat > 1 && language)
                        {
                            bat2Label.Text = "Batería baja";
                            bat2Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor2.bat < 2.42 && sensor2.bat > 1 && !language)
                        {
                            bat2Label.Text = "Low battery";
                            bat2Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat2Label.Text = "";
                            bat2Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    /*      if (sensor2.esm == 1)
                              sensor2Label.BackColor = System.Drawing.Color.CornflowerBlue;
                          else if (sensor2.esm == 0)
                              sensor2Label.BackColor = System.Drawing.Color.Gold;
                    */
                    sensor2Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    sensor2Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor2.esm == 1)
                            sensor2Label.BackColor = System.Drawing.Color.CornflowerBlue;
                        else if (sensor2.esm == 0)
                            sensor2Label.BackColor = System.Drawing.Color.Gold;
                    });

                    sensor2.checkTemp();

                    if (sensor2.breachTemp && !sensor2.standbyTemp)
                    {
                        sensor2.standbyTemp = true;
                        if (whistleTemp2 == null)
                            whistleTemp2 = new Thread(() => Alert(sensor2, false));
                        whistleTemp2.Start();
                    }

                    sensor2.checkHum();

                    if (sensor2.breachHum && !sensor2.standbyHum)
                    {
                        sensor2.standbyHum = true;
                        if (whistleHum2 == null)
                            whistleHum2 = new Thread(() => Alert(sensor2, true));
                        whistleHum2.Start();
                    }

                    if (sensor2.bat < 2.42 && sensor2.bat > 1)
                    {
                        if (whistleBat2 == null)
                        {
                            whistleBat2 = new Thread(() => AlertBat(sensor2));
                            whistleBat2.Start();
                        }
                    }

                    break;
                case 3:

                    s3count++;

                    pc3.Invoke((MethodInvoker)delegate
                    {
                        pc3.Text = Convert.ToString(s3count);
                    });

                    sensor3.addData(transmitData, scale);

                    temp3Box.Invoke((MethodInvoker)delegate
                    {
                        temp3Box.Text = Convert.ToString(Math.Round(sensor3.holdTemp));
                    });

                    hum3Box.Invoke((MethodInvoker)delegate
                    {
                        hum3Box.Text = Convert.ToString(Math.Round(sensor3.holdHum));
                    });
                    label7.Invoke((MethodInvoker)delegate
                    {
                        label7.Text = messagesDelivered;
                    });
                    label8.Invoke((MethodInvoker)delegate
                    {
                        label8.Text = attempts;
                    });
                    label9.Invoke((MethodInvoker)delegate
                    {
                        label9.Text = totalRetries;
                    });

                    bat3Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor3.bat < 2.42 && sensor3.bat > 1 && language)
                        {
                            bat3Label.Text = "Batería baja";
                            bat3Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor3.bat < 2.42 && sensor3.bat > 1 && !language)
                        {
                            bat3Label.Text = "Low battery";
                            bat3Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat3Label.Text = "";
                            bat3Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor3Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor3.esm == 1)
                        sensor3Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor3.esm == 0)
                        sensor3Label.BackColor = System.Drawing.Color.Gold;

                    sensor3.checkTemp();

                    if (sensor3.breachTemp && !sensor3.standbyTemp)
                    {
                        sensor3.standbyTemp = true;
                        if (whistleTemp3 == null)
                            whistleTemp3 = new Thread(() => Alert(sensor3, false));
                        whistleTemp3.Start();
                    }

                    sensor3.checkHum();

                    if (sensor3.breachHum && !sensor3.standbyHum)
                    {
                        sensor3.standbyHum = true;
                        if (whistleHum3 == null)
                            whistleHum3 = new Thread(() => Alert(sensor3, true));
                        whistleHum3.Start();
                    }

                    if (sensor3.bat < 2.42 && sensor3.bat > 1)
                    {
                        if (whistleBat3 == null)
                        {
                            whistleBat3 = new Thread(() => AlertBat(sensor3));
                            whistleBat3.Start();
                        }
                    }

                    break;
                case 4:
                    s4count++;

                    pc4.Invoke((MethodInvoker)delegate
                    {
                        pc4.Text = Convert.ToString(s4count);
                    });

                    sensor4.addData(transmitData, scale);

                    temp4Box.Invoke((MethodInvoker)delegate
                    {
                        temp4Box.Text = Convert.ToString(Math.Round(sensor4.holdTemp));
                    });

                    hum4Box.Invoke((MethodInvoker)delegate
                    {
                        hum4Box.Text = Convert.ToString(Math.Round(sensor4.holdHum));
                    });

                    label10.Invoke((MethodInvoker)delegate
                    {
                        label10.Text = messagesDelivered;
                    });
                    label11.Invoke((MethodInvoker)delegate
                    {
                        label11.Text = attempts;
                    });
                    label12.Invoke((MethodInvoker)delegate
                    {
                        label12.Text = totalRetries;
                    });

                    bat4Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor4.bat < 2.42 && sensor4.bat > 1 && language)
                        {
                            bat4Label.Text = "Batería baja";
                            bat4Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor4.bat < 2.42 && sensor4.bat > 1 && !language)
                        {
                            bat4Label.Text = "Low battery";
                            bat4Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat4Label.Text = "";
                            bat4Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor4Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor4.esm == 1)
                        sensor4Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor4.esm == 0)
                        sensor4Label.BackColor = System.Drawing.Color.Gold;

                    sensor4.checkTemp();

                    if (sensor4.breachTemp && !sensor4.standbyTemp)
                    {
                        sensor4.standbyTemp = true;
                        if (whistleTemp4 == null)
                            whistleTemp4 = new Thread(() => Alert(sensor4, false));
                        whistleTemp4.Start();
                    }

                    sensor4.checkHum();

                    if (sensor4.breachHum && !sensor4.standbyHum)
                    {
                        sensor4.standbyHum = true;
                        if (whistleHum4 == null)
                            whistleHum4 = new Thread(() => Alert(sensor4, true));
                        whistleHum4.Start();
                    }

                    if (sensor4.bat < 2.42 && sensor4.bat > 1)
                    {
                        if (whistleBat4 == null)
                        {
                            whistleBat4 = new Thread(() => AlertBat(sensor4));
                            whistleBat4.Start();
                        }
                    }

                    break;
                case 5:
                    s5count++;

                    pc5.Invoke((MethodInvoker)delegate
                    {
                        pc5.Text = Convert.ToString(s5count);
                    });

                    sensor5.addData(transmitData, scale);

                    temp5Box.Invoke((MethodInvoker)delegate
                    {
                        temp5Box.Text = Convert.ToString(Math.Round(sensor5.holdTemp));
                    });

                    hum5Box.Invoke((MethodInvoker)delegate
                    {
                        hum5Box.Text = Convert.ToString(Math.Round(sensor5.holdHum));
                    });

                    label13.Invoke((MethodInvoker)delegate
                    {
                        label13.Text = messagesDelivered;
                    });
                    label14.Invoke((MethodInvoker)delegate
                    {
                        label14.Text = attempts;
                    });
                    label15.Invoke((MethodInvoker)delegate
                    {
                        label15.Text = totalRetries;
                    });

                    bat5Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor5.bat < 2.42 && sensor5.bat > 1 && language)
                        {
                            bat5Label.Text = "Batería baja";
                            bat5Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor5.bat < 2.42 && sensor5.bat > 1 && !language)
                        {
                            bat5Label.Text = "Low battery";
                            bat5Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat5Label.Text = "";
                            bat5Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor5Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor5.esm == 1)
                        sensor5Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor5.esm == 0)
                        sensor5Label.BackColor = System.Drawing.Color.Gold;

                    sensor5.checkTemp();

                    if (sensor5.breachTemp && !sensor5.standbyTemp)
                    {
                        sensor5.standbyTemp = true;
                        if (whistleTemp5 == null)
                            whistleTemp5 = new Thread(() => Alert(sensor5, false));
                        whistleTemp5.Start();
                    }

                    sensor5.checkHum();

                    if (sensor5.breachHum && !sensor5.standbyHum)
                    {
                        sensor5.standbyHum = true;
                        if (whistleHum5 == null)
                            whistleHum5 = new Thread(() => Alert(sensor5, true));
                        whistleHum5.Start();
                    }

                    if (sensor5.bat < 2.42 && sensor5.bat > 1)
                    {
                        if (whistleBat5 == null)
                        {
                            whistleBat5 = new Thread(() => AlertBat(sensor5));
                            whistleBat5.Start();
                        }
                    }

                    break;
                case 6:
                    s6count++;

                    pc6.Invoke((MethodInvoker)delegate
                    {
                        pc6.Text = Convert.ToString(s6count);
                    });

                    sensor6.addData(transmitData, scale);

                    temp6Box.Invoke((MethodInvoker)delegate
                    {
                        temp6Box.Text = Convert.ToString(Math.Round(sensor6.holdTemp));
                    });

                    hum6Box.Invoke((MethodInvoker)delegate
                    {
                        hum6Box.Text = Convert.ToString(Math.Round(sensor6.holdHum));
                    });

                    label16.Invoke((MethodInvoker)delegate
                    {
                        label16.Text = messagesDelivered;
                    });
                    label17.Invoke((MethodInvoker)delegate
                    {
                        label17.Text = attempts;
                    });
                    label18.Invoke((MethodInvoker)delegate
                    {
                        label18.Text = totalRetries;
                    });

                    bat6Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor6.bat < 2.42 && sensor6.bat > 1 && language)
                        {
                            bat6Label.Text = "Batería baja";
                            bat6Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor6.bat < 2.42 && sensor6.bat > 1 && !language)
                        {
                            bat6Label.Text = "Low battery";
                            bat6Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat6Label.Text = "";
                            bat6Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor6Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor6.esm == 1)
                        sensor6Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor6.esm == 0)
                        sensor6Label.BackColor = System.Drawing.Color.Gold;

                    sensor6.checkTemp();

                    if (sensor6.breachTemp && !sensor6.standbyTemp)
                    {
                        sensor6.standbyTemp = true;
                        if (whistleTemp6 == null)
                            whistleTemp6 = new Thread(() => Alert(sensor6, false));
                        whistleTemp6.Start();
                    }

                    sensor6.checkHum();

                    if (sensor6.breachHum && !sensor6.standbyHum)
                    {
                        sensor6.standbyHum = true;
                        if (whistleHum6 == null)
                            whistleHum6 = new Thread(() => Alert(sensor6, true));
                        whistleHum6.Start();
                    }

                    if (sensor6.bat < 2.42 && sensor6.bat > 1)
                    {
                        if (whistleBat6 == null)
                        {
                            whistleBat6 = new Thread(() => AlertBat(sensor6));
                            whistleBat6.Start();
                        }
                    }

                    break;
                case 7:
                    s7count++;

                    pc7.Invoke((MethodInvoker)delegate
                    {
                        pc7.Text = Convert.ToString(s7count);
                    });

                    sensor7.addData(transmitData, scale);

                    temp7Box.Invoke((MethodInvoker)delegate
                    {
                        temp7Box.Text = Convert.ToString(Math.Round(sensor7.holdTemp));
                    });

                    hum7Box.Invoke((MethodInvoker)delegate
                    {
                        hum7Box.Text = Convert.ToString(Math.Round(sensor7.holdHum));
                    });

                    label19.Invoke((MethodInvoker)delegate
                    {
                        label19.Text = messagesDelivered;
                    });
                    label20.Invoke((MethodInvoker)delegate
                    {
                        label20.Text = attempts;
                    });
                    label21.Invoke((MethodInvoker)delegate
                    {
                        label21.Text = totalRetries;
                    });

                    bat7Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor7.bat < 2.42 && sensor7.bat > 1 && language)
                        {
                            bat7Label.Text = "Batería baja";
                            bat7Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor7.bat < 2.42 && sensor7.bat > 1 && !language)
                        {
                            bat7Label.Text = "Low battery";
                            bat7Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat7Label.Text = "";
                            bat7Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor7Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor7.esm == 1)
                        sensor7Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor7.esm == 0)
                        sensor7Label.BackColor = System.Drawing.Color.Gold;

                    sensor7.checkTemp();

                    if (sensor7.breachTemp && !sensor7.standbyTemp)
                    {
                        sensor7.standbyTemp = true;
                        if (whistleTemp7 == null)
                            whistleTemp7 = new Thread(() => Alert(sensor7, false));
                        whistleTemp7.Start();
                    }

                    sensor7.checkHum();

                    if (sensor7.breachHum && !sensor7.standbyHum)
                    {
                        sensor7.standbyHum = true;
                        if (whistleHum7 == null)
                            whistleHum7 = new Thread(() => Alert(sensor7, true));
                        whistleHum7.Start();
                    }

                    if (sensor7.bat < 2.42 && sensor7.bat > 1)
                    {
                        if (whistleBat7 == null)
                        {
                            whistleBat7 = new Thread(() => AlertBat(sensor7));
                            whistleBat7.Start();
                        }
                    }

                    break;
                case 8:
                    s8count++;

                    pc8.Invoke((MethodInvoker)delegate
                    {
                        pc8.Text = Convert.ToString(s8count);
                    });

                    sensor8.addData(transmitData, scale);

                    temp8Box.Invoke((MethodInvoker)delegate
                    {
                        temp8Box.Text = Convert.ToString(Math.Round(sensor8.holdTemp));
                    });

                    hum8Box.Invoke((MethodInvoker)delegate
                    {
                        hum8Box.Text = Convert.ToString(Math.Round(sensor8.holdHum));
                    });

                    label22.Invoke((MethodInvoker)delegate
                    {
                        label22.Text = messagesDelivered;
                    });
                    label23.Invoke((MethodInvoker)delegate
                    {
                        label23.Text = attempts;
                    });
                    label24.Invoke((MethodInvoker)delegate
                    {
                        label24.Text = totalRetries;
                    }); 

                    bat8Label.Invoke((MethodInvoker)delegate
                    {
                        if (sensor8.bat < 2.42 && sensor8.bat > 1 && language)
                        {
                            bat8Label.Text = "Batería baja";
                            bat8Label.BackColor = System.Drawing.Color.Red;
                        }
                        else if (sensor8.bat < 2.42 && sensor8.bat > 1 && !language)
                        {
                            bat8Label.Text = "Low battery";
                            bat8Label.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bat8Label.Text = "";
                            bat8Label.BackColor = sensorFeedLabel.BackColor;
                        }
                    });

                    sensor8Label.BackColor = sensorFeedLabel.BackColor;
                    Thread.Sleep(500);

                    if (sensor8.esm == 1)
                        sensor8Label.BackColor = System.Drawing.Color.CornflowerBlue;
                    else if (sensor8.esm == 0)
                        sensor8Label.BackColor = System.Drawing.Color.Gold;

                    sensor8.checkTemp();

                    if (sensor8.breachTemp && !sensor8.standbyTemp)
                    {
                        sensor8.standbyTemp = true;
                        if (whistleTemp8 == null)
                            whistleTemp8 = new Thread(() => Alert(sensor8, false));
                        whistleTemp8.Start();
                    }

                    sensor8.checkHum();

                    if (sensor8.breachHum && !sensor8.standbyHum)
                    {
                        sensor8.standbyHum = true;
                        if (whistleHum8 == null)
                            whistleHum8 = new Thread(() => Alert(sensor8, true));
                        whistleHum8.Start();
                    }

                    if (sensor8.bat < 2.42 && sensor8.bat > 1)
                    {
                        if (whistleBat8 == null)
                        {
                            whistleBat8 = new Thread(() => AlertBat(sensor8));
                            whistleBat8.Start();
                        }
                    }

                    break;
                default: break;
            }
        }


        public HomePageForm()
        {
            InitializeComponent();

            this.FormClosing += endAll;

            tempDay = new List<double>();
            humDay = new List<double>();
            batDay = new List<double>();

            sensors.Add(sensor1);
            sensors.Add(sensor2);
            sensors.Add(sensor3);
            sensors.Add(sensor4);
            sensors.Add(sensor5);
            sensors.Add(sensor6);
            sensors.Add(sensor7);
            sensors.Add(sensor8);
        //    _emailAddress = "wwpool@mc.edu";
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            serialThread = new Thread(doStuff);
            serialThread.Start();
        }

        public void SettingsButton_Click(object sender, EventArgs e)
        {
    

            this.Hide();
            if (newGuy == null)
            {
                newGuy = new SettingsPageForm(this);
                newGuy.FormClosed += (s, args) => { newGuy = null; };

                newGuy.sensor1 = sensor1;
                newGuy.sensor2 = sensor2;
                newGuy.sensor3 = sensor3;
                newGuy.sensor4 = sensor4;
                newGuy.sensor5 = sensor5;
                newGuy.sensor6 = sensor6;
                newGuy.sensor7 = sensor7;
                newGuy.sensor8 = sensor8;
                newGuy.waitToSet = waitToSet;

                newGuy.ShowDialog();
            }
            else
                newGuy.Visible = true;

           // waitToSet = true;

            this.Show();

           // if (!waitToSet)
           // {
               // scale = newGuy.scale;
               // language = newGuy.language;
               // file = newGuy.file;
               // freq = newGuy.freq;
               // emailAddress = newGuy.emailAddress;
               // noAlert = newGuy.noAlert;
           // }
            
            if (attourney == null)
                attourney = new Thread(dailyReport);
      

          //  newGuy = null;

            if (!(_emailAddress == null) && !(attourney.IsAlive))
            {
                attourney.Start();
            }
            updateElements();
        }        
        public void dailyReport()
        {
            while (true)
            {
                for (int i = 0; i < 24; i++)
                {
                    Thread.Sleep(1000*5);
                    sensor1.takeAvg();
                    sensor2.takeAvg();
                    sensor3.takeAvg();
                    sensor4.takeAvg();
                    sensor5.takeAvg();
                    sensor6.takeAvg();
                    sensor7.takeAvg();
                    sensor8.takeAvg();
                }
                for (int i = 0; i < 8; i++)
                {
                    tempDay.Add(0);
                    humDay.Add(0);
                    batDay.Add(0);
                }

                tempDay[0] = Math.Round(100 * sensor1.dailyTempAvg()) / 100;
                tempDay[1] = Math.Round(100 * sensor2.dailyTempAvg()) / 100;
                tempDay[2] = Math.Round(100 * sensor3.dailyTempAvg()) / 100;
                tempDay[3] = Math.Round(100 * sensor4.dailyTempAvg()) / 100;
                tempDay[4] = Math.Round(100 * sensor5.dailyTempAvg()) / 100;
                tempDay[5] = Math.Round(100 * sensor6.dailyTempAvg()) / 100;
                tempDay[6] = Math.Round(100 * sensor7.dailyTempAvg()) / 100;
                tempDay[7] = Math.Round(100 * sensor8.dailyTempAvg()) / 100;

                humDay[0] = Math.Round(100 * sensor1.dailyHumAvg()) / 100;
                humDay[1] = Math.Round(100 * sensor2.dailyHumAvg()) / 100;
                humDay[2] = Math.Round(100 * sensor3.dailyHumAvg()) / 100;
                humDay[3] = Math.Round(100 * sensor4.dailyHumAvg()) / 100;
                humDay[4] = Math.Round(100 * sensor5.dailyHumAvg()) / 100;
                humDay[5] = Math.Round(100 * sensor6.dailyHumAvg()) / 100;
                humDay[6] = Math.Round(100 * sensor7.dailyHumAvg()) / 100;
                humDay[7] = Math.Round(100 * sensor8.dailyHumAvg()) / 100;

                batDay[0] = sensor1.bat;
                batDay[1] = sensor2.bat;
                batDay[2] = sensor3.bat;
                batDay[3] = sensor4.bat;
                batDay[4] = sensor5.bat;
                batDay[5] = sensor6.bat;
                batDay[6] = sensor7.bat;
                batDay[7] = sensor8.bat;

                if (file)
                {
                    excelOut();
                }
                else
                    csvOut();

                
                tempDay.Clear();
                humDay.Clear();
                batDay.Clear();

                /*
                if (attourney.IsAlive)
                {
                    attourney.Abort();
                }
                else
                {
                    lawyer.Abort();
                }
                */
            }
            

        }
            
        

        /*
        public void minuteTaker()
        {
            paperBoy = new Thread(dailyReport);
            paperBoy.Start();
            while (!(this.IsDisposed))
            {
                Thread.Sleep(1000);
                sensor1.takeAvg();
                sensor2.takeAvg();
                sensor3.takeAvg();
                sensor4.takeAvg();
                sensor5.takeAvg();
                sensor6.takeAvg();
                sensor7.takeAvg();
                sensor8.takeAvg();
            }
        }

        private void dailyReport()
        {
            while (!(IsDisposed))
            {
                Thread.Sleep(1000 * 24);

                for (int i = 0; i < 8; i++)
                {
                    tempDay.Add(0);
                    humDay.Add(0);
                    batDay.Add(0);
                }

                tempDay[0] = Math.Round(100 * sensor1.dailyTempAvg()) / 100;
                tempDay[1] = Math.Round(100 * sensor2.dailyTempAvg()) / 100;
                tempDay[2] = Math.Round(100 * sensor3.dailyTempAvg()) / 100;
                tempDay[3] = Math.Round(100 * sensor4.dailyTempAvg()) / 100;
                tempDay[4] = Math.Round(100 * sensor5.dailyTempAvg()) / 100;
                tempDay[5] = Math.Round(100 * sensor6.dailyTempAvg()) / 100;
                tempDay[6] = Math.Round(100 * sensor7.dailyTempAvg()) / 100;
                tempDay[7] = Math.Round(100 * sensor8.dailyTempAvg()) / 100;

                humDay[0] = Math.Round(100 * sensor1.dailyHumAvg()) / 100;
                humDay[1] = Math.Round(100 * sensor2.dailyHumAvg()) / 100;
                humDay[2] = Math.Round(100 * sensor3.dailyHumAvg()) / 100;
                humDay[3] = Math.Round(100 * sensor4.dailyHumAvg()) / 100;
                humDay[4] = Math.Round(100 * sensor5.dailyHumAvg()) / 100;
                humDay[5] = Math.Round(100 * sensor6.dailyHumAvg()) / 100;
                humDay[6] = Math.Round(100 * sensor7.dailyHumAvg()) / 100;
                humDay[7] = Math.Round(100 * sensor8.dailyHumAvg()) / 100;

                batDay[0] = sensor1.bat;
                batDay[1] = sensor2.bat;
                batDay[2] = sensor3.bat;
                batDay[3] = sensor4.bat;
                batDay[4] = sensor5.bat;
                batDay[5] = sensor6.bat;
                batDay[6] = sensor7.bat;
                batDay[7] = sensor8.bat;

                if (file)
                    excelOut();
                else
                    csvOut();

                tempDay.Clear();
                humDay.Clear();
                batDay.Clear();

                lawyer = new Thread(minuteTaker);
                lawyer.Start();
                attourney.Abort();
                paperBoy.Abort();

         
            }
           
        }
        */
        private void updateElements()
        {
            if (scale)
            {
                temp1Label.Text = "°C";
                temp2Label.Text = "°C";
                temp3Label.Text = "°C";
                temp4Label.Text = "°C";
                temp5Label.Text = "°C";
                temp6Label.Text = "°C";
                temp7Label.Text = "°C";
                temp8Label.Text = "°C";
            }
            else
            {
                temp1Label.Text = "°F";
                temp2Label.Text = "°F";
                temp3Label.Text = "°F";
                temp4Label.Text = "°F";
                temp5Label.Text = "°F";
                temp6Label.Text = "°F";
                temp7Label.Text = "°F";
                temp8Label.Text = "°F";
            }

            if (language)
            {
                sensorFeedLabel.Text = "Alimentación del Sensor";
                SettingsButton.Text = "Ajustes";
                legendOnLabel.Text = "ESM Desactivado";
                legendOffLabel.Text = "ESM Activado";
            }
            else
            {
                sensorFeedLabel.Text = "Sensor Feed";
                SettingsButton.Text = "Settings";
                legendOnLabel.Text = "ESM On";
                legendOffLabel.Text = "ESM Off";
            }
        }

        public void excelOut()
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                ExcelWorksheet report;

                if (language)
                {
                    path = "Reporte Diario.xlsx";
                }
                else
                {
                    path = "Daily Report.xlsx";
                }


                    using (ExcelPackage package = new ExcelPackage())
                    {

                        theDate = DateTime.Today.ToString().Split(' ')[0];

                        if (language)
                            report = package.Workbook.Worksheets.Add("Reportante");
                        else
                            report = package.Workbook.Worksheets.Add("Report");

                        if (scale)
                            tempType = " °C";
                        else
                            tempType = " °F";

                        report.Cells[1, 1].Value = theDate;

                        for (int i = 0; i < 8; i++)
                        {
                            report.Cells[2, i * 3 + 3].Value = "Sensor " + (i + 1);

                            if (language)
                            {
                                report.Name = "REMS Reporte Diario- " + theDate;
                                report.Cells[3, i * 3 + 2].Value = "Temperatura Media";
                                report.Cells[3, i * 3 + 3].Value = "Humedad Promedio";
                                report.Cells[3, i * 3 + 4].Value = "Último Nivel de Batería";
                                batText = " Voltios";
                                report.Cells[30, 1].Value = "Acumulativo";
                            }
                            else
                            {
                                report.Name = "REMS Daily Report- " + theDate;
                                report.Cells[3, i * 3 + 2].Value = "Average Temperature";
                                report.Cells[3, i * 3 + 3].Value = "Average Humidity";
                                report.Cells[3, i * 3 + 4].Value = "Latest Battery Level";
                                batText = " Volts";
                                report.Cells[30, 1].Value = "Cumulative";
                            }
                        }

                        for (int i = 1; i < 9; i++)
                        {
                            Sensor americanPeople = sensors[i - 1];

                            report.Cells[2, i * 3 - 1].Value = "CPU: " + americanPeople.sendCount;
                            report.Cells[2, i * 3 + 1].Value = "GUI: " + americanPeople.catchCount;

                            for (int j = 4; j < 28; j++)
                            {
                                report.Cells[j, i * 3 - 1].Value = americanPeople.tempAvg[j - 4] + tempType;
                                report.Cells[j, i * 3].Value = americanPeople.humAvg[j - 4] + " %";
                                report.Cells[j, i * 3 + 1].Value = americanPeople.lastBat[j - 4] + batText;
                            }

                            report.Cells[30, i * 3 - 1].Value = tempDay[i - 1] + tempType;
                            report.Cells[30, i * 3].Value = humDay[i - 1] + " %";
                            report.Cells[30, i * 3 + 1].Value = batDay[i - 1] + batText;

                            americanPeople.tempAvg.Clear();
                            americanPeople.humAvg.Clear();
                            americanPeople.lastBat.Clear();
                            americanPeople.catchCount = 0;
                        }
                        using (var stream = new MemoryStream())
                        {
                            package.SaveAs(stream);
                            stream.Position = 0;
                            if (!(_emailAddress == null))
                                MailMan.SendReport(_emailAddress, language, theDate, stream, path);

                        }



                        //package.Save();
                     
                    }

                
               
                    
            }

                // Dispose of the ExcelPackage before deleting the file
               
            
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void csvOut()
        {
            if (language)
            {
                path = "Reporte Diario.csv";
                batText = " Voltios";
                timeText = "Hora ";
            }
            else
            {
                path = "Daily Report.csv";
                batText = " Volts";
                timeText = "Hour ";
            }

          //  path = System.IO.Path.Combine(Environment.CurrentDirectory, path);

            List<Sensor> sensors = new List<Sensor>
            {
                sensor1, sensor2, sensor3, sensor4, sensor5, sensor6, sensor7, sensor8
            };

            if (scale)
                tempType = " °C";
            else
                tempType = " °F";

            //   bool fileSaved = false;
            //   int retries = 3;
            //   while (!fileSaved && retries > 0)
            //  {
            using (var stream = new MemoryStream())
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        writer.WriteLine(DateTime.Now.ToString());
                        writer.WriteLine('\n');

                        if (language)
                        {
                            writer.Write("Tiempo,");
                        }
                        else
                        {
                            writer.Write("Time,");
                        }

                        for (int i = 0; i < sensors.Count; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                writer.Write(sensors[i].name + ",");
                            }
                        }

                        writer.Write('\n');

                        for (int i = 0; i < sensors.Count; i++)
                        {
                            if (language)
                            {
                                writer.Write("Tiempo, Temperatura, Humedad, Nivel de Bateria" + ",");
                            }
                            else
                                writer.Write("Time, Temperature, Humidity, Battery Level" + ",");
                        }

                        writer.WriteLine('\n');

                        for (int i = 0; i < sensors[0].tempAvg.Count; i++)
                        {
                            writer.Write(timeText + (i + 1).ToString() + ",");

                            for (int j = 0; j < sensors.Count; j++)
                            {
                                writer.Write(sensors[j].tempAvg[i] + tempType + "," + sensors[j].humAvg[i]
                                + " %" + "," + sensors[j].lastBat[i] + batText + ",");
                            }

                            writer.WriteLine("\n");
                        }

                        if (language)
                        {
                            writer.Write("Acumulativo" + ",");
                        }
                        else
                        {
                            writer.Write("Cumulative" + ",");
                        }

                        for (int i = 0; i < sensors.Count; i++)
                        {
                            writer.Write(sensors[i].name + "," + tempDay[i] + tempType + "," + humDay[i]
                                + " %" + "," + sensors[i].bat + batText + ",");

                            sensors[i].tempAvg.Clear();
                            sensors[i].humAvg.Clear();
                            sensors[i].lastBat.Clear();
                            sensors[i].catchCount = 0;
                        }
                        //writer.Dispose();

                     //   Thread.Sleep(1000);
                    byte[] bytes = Encoding.UTF8.GetBytes(writer.ToString());
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    Thread.Sleep(1000);

                    // package.SaveAs(stream);
                    //  stream.Position = 0;
                    if (!(_emailAddress == null))
                        MailMan.SendReport(_emailAddress, language, theDate, stream, path);

                        
                    writer.Dispose();
                }
                 //   fileSaved = true;

                }
                catch (IOException)
                {
                    // Wait for a short period before retrying
                    System.Threading.Thread.Sleep(1000); // 1 second
            //        retries--;
                }
            }

            /* if (fileSaved && !string.IsNullOrEmpty(_emailAddress))
             {
                 MailMan.SendReport(_emailAddress, language, theDate, path);

             }
            */

            
        }


        public void Alert(Sensor culprit, bool quantity)
        {
            theBritishAreComing = new Thread(() => PeriodicEmail(culprit, quantity));
            theBritishAreComing.Start();

            protester = new Thread(() => Visual(culprit, quantity));
            protester.Start();

            hellmo = new Thread(Audio);
            hellmo.Start();

            Thread.Sleep(10000);

            if (quantity)
                culprit.standbyHum = false;
            else
                culprit.standbyTemp = false;

            switch (culprit.num)
            {
                case 1:
                    if (quantity)
                    {
                        whistleHum1.Abort();
                        whistleHum1 = null;
                    }
                    else
                        whistleTemp1.Abort(); whistleTemp1 = null;
                    break;
                case 2:
                    if (quantity)
                    {
                        whistleHum2.Abort();
                        whistleHum2 = null;
                    }
                    else
                        whistleTemp2.Abort(); whistleTemp2 = null;
                    break;
                case 3:
                    if (quantity)
                    {
                        whistleHum3.Abort();
                        whistleHum3 = null;
                    }
                    else
                        whistleTemp3.Abort(); whistleTemp3 = null;
                    break;
                case 4:
                    if (quantity)
                    {
                        whistleHum4.Abort();
                        whistleHum4 = null;
                    }
                    else
                        whistleTemp4.Abort(); whistleTemp4 = null;
                    break;
                case 5:
                    if (quantity)
                    {
                        whistleHum5.Abort();
                        whistleHum5 = null;
                    }
                    else
                        whistleTemp5.Abort(); whistleTemp5 = null;
                    break;
                case 6:
                    if (quantity)
                    {
                        whistleHum6.Abort();
                        whistleHum6 = null;
                    }
                    else
                        whistleTemp6.Abort(); whistleTemp6 = null;
                    break;
                case 7:
                    if (quantity)
                    {
                        whistleHum7.Abort();
                        whistleHum7 = null;
                    }
                    else
                        whistleTemp7.Abort(); whistleTemp7 = null;
                    break;
                case 8:
                    if (quantity)
                    {
                        whistleHum8.Abort();
                        whistleHum8 = null;
                    }
                    else
                        whistleTemp8.Abort(); whistleTemp8 = null;
                    break;
                default: break;
            }
        }

        public void Visual(Sensor culprit, bool quantity)
        {
            if (language && quantity && culprit.inequality)
                SetAlertText("La humedad del " + culprit.name + " es demasiado alta.");
            else if (language && quantity && !culprit.inequality)
                SetAlertText("La humedad del " + culprit.name + "es demasiado baja.");
            else if (language && !quantity && culprit.inequality)
                SetAlertText("La temperatura del " + culprit.name + "es demasiado alta.");
            else if (language && !quantity && !culprit.inequality)
                SetAlertText("La temperatura del " + culprit.name + "es demasiado baja.");
            else if (!language && quantity && culprit.inequality)
                SetAlertText(culprit.name + " humidity is too high.");
            else if (!language && quantity && !culprit.inequality)
                SetAlertText(culprit.name + " humidity is too low.");
            else if (!language && !quantity && culprit.inequality)
                SetAlertText(culprit.name + " temperature is too high.");
            else if (!language && !quantity && !culprit.inequality)
                SetAlertText(culprit.name + " temperature is too low.");

            for (int i = 0; i < 5; i++)
            {
                alertLabel.BackColor = System.Drawing.Color.LightGreen;
                Thread.Sleep(300);
                alertLabel.BackColor = System.Drawing.Color.Red;
                Thread.Sleep(300);
            }

            Thread.Sleep(1000);
            alertLabel.BackColor = sensorFeedLabel.BackColor;
            SetAlertText("");

            Thread.Sleep(5500);

            protester.Abort();
        }

        private void SetAlertText(string words)
        {
            if (alertText.InvokeRequired)
            {
                alertText.Invoke((MethodInvoker)delegate
                {
                    alertText.Text = words;
                });
            }
        }

        public void Audio()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Beep(370, 300);
                Console.Beep(330, 300);
            }

            Thread.Sleep(5500);

            hellmo.Abort();
        }

        public void AlertBat(Sensor culprit)
        {
            if (!noAlert)
            {
                while (culprit.bat < 2.42 && culprit.bat > 1 && !(_emailAddress == null))
                {
                    MailMan.SendBat(_emailAddress, language, culprit);
                    Thread.Sleep(1000 * 60 * freq);
                }
            }

            switch (culprit.num)
            {
                case 1:
                    whistleBat1.Abort();
                    whistleBat1 = null;
                    break;
                case 2:
                    whistleBat2.Abort();
                    whistleBat2 = null;
                    break;
                case 3:
                    whistleBat3.Abort();
                    whistleBat3 = null;
                    break;
                case 4:
                    whistleBat4.Abort();
                    whistleBat4 = null;
                    break;
                case 5:
                    whistleBat5.Abort();
                    whistleBat5 = null;
                    break;
                case 6:
                    whistleBat6.Abort();
                    whistleBat6 = null;
                    break;
                case 7:
                    whistleBat7.Abort();
                    whistleBat7 = null;
                    break;
                case 8:
                    whistleBat8.Abort();
                    whistleBat8 = null;
                    break;
                default: break;
            }
        }

        public void PeriodicEmail(Sensor culprit, bool quantity)
        {
                   if (quantity && !noAlert)
                   {
                       while (culprit.breachHum  && !(_emailAddress == null))
                       {
                           MailMan.SendAlert(_emailAddress, language, culprit, quantity, culprit.inequality);
                           Thread.Sleep(1000 * 60 * freq);
                       }
                   }
                   else if (!quantity && !noAlert)
                   {
                       while (culprit.breachTemp && !(_emailAddress == null))
                       {
                           MailMan.SendAlert(_emailAddress, language, culprit, quantity, culprit.inequality);
                           Thread.Sleep(1000 * 60 * freq);
                       }
                   }

            theBritishAreComing.Abort();
            theBritishAreComing = null;
        }

        private void endAll(object sender, FormClosingEventArgs e)
        {
            serialThread.Abort();

            if (!(attourney == null))
                attourney.Abort();

            if (!(paperBoy == null))
                paperBoy.Abort();

            if (!(theBritishAreComing == null))
                theBritishAreComing.Abort();

            if (!(protester == null))
                protester.Abort();

            if (!(hellmo == null))
                hellmo.Abort();

            if (!(whistleTemp1 == null))
                whistleTemp1.Abort();

            if (!(whistleTemp2 == null))
                whistleTemp2.Abort();

            if (!(whistleTemp3 == null))
                whistleTemp3.Abort();

            if (!(whistleTemp4 == null))
                whistleTemp4.Abort();

            if (!(whistleTemp5 == null))
                whistleTemp5.Abort();

            if (!(whistleTemp6 == null))
                whistleTemp6.Abort();

            if (!(whistleTemp7 == null))
                whistleTemp7.Abort();

            if (!(whistleTemp8 == null))
                whistleTemp8.Abort();

            if (!(whistleHum1 == null))
                whistleHum1.Abort();

            if (!(whistleHum2 == null))
                whistleHum2.Abort();

            if (!(whistleHum3 == null))
                whistleHum3.Abort();

            if (!(whistleHum4 == null))
                whistleHum4.Abort();

            if (!(whistleHum5 == null))
                whistleHum5.Abort();

            if (!(whistleHum6 == null))
                whistleHum6.Abort();

            if (!(whistleHum7 == null))
                whistleHum7.Abort();

            if (!(whistleHum8 == null))
                whistleHum8.Abort();

            if (!(whistleBat1 == null))
                whistleBat1.Abort();

            if (!(whistleBat2 == null))
                whistleBat2.Abort();

            if (!(whistleBat3 == null))
                whistleBat3.Abort();

            if (!(whistleBat4 == null))
                whistleBat4.Abort();

            if (!(whistleBat5 == null))
                whistleBat5.Abort();

            if (!(whistleBat6 == null))
                whistleBat6.Abort();

            if (!(whistleBat7 == null))
                whistleBat7.Abort();

            if (!(whistleBat8 == null))
                whistleBat8.Abort();
        }

        private void sensor1NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor1.name = sensor1NameBox.Text;
        }

        private void sensor2NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor2.name = sensor2NameBox.Text;
        }

        private void sensor3NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor3.name = sensor3NameBox.Text;
        }

        private void sensor4NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor4.name = sensor4NameBox.Text;
        }

        private void sensor5NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor5.name = sensor5NameBox.Text;
        }

        private void sensor6NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor6.name = sensor6NameBox.Text;
        }

        private void sensor7NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor7.name = sensor7NameBox.Text;
        }

        private void sensor8NameBox_TextChanged(object sender, EventArgs e)
        {
            sensor8.name = sensor8NameBox.Text;
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            s1count = 0;
            s2count = 0;
            s3count = 0;
            s4count = 0;
            s5count = 0;
            s6count = 0;
            s7count = 0;
            s8count = 0;

            pc1.Text = Convert.ToString(s1count);
            pc2.Text = Convert.ToString(s2count);
            pc3.Text = Convert.ToString(s3count);
            pc4.Text = Convert.ToString(s4count);
            pc5.Text = Convert.ToString(s5count);
            pc6.Text = Convert.ToString(s6count);
            pc7.Text = Convert.ToString(s7count);
            pc8.Text = Convert.ToString(s8count);
        }
    }
}
