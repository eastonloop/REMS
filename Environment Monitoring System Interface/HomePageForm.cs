using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Reflection.Emit;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Vml;
using System.Runtime.Remoting.Messaging;

namespace Environment_Monitoring_System_Interface
{
    public partial class HomePageForm : Form
    {
        private string[] transmitData;
        private int whichSens;
        string message;
        private SerialPort pigeon;
        private Thread serialThread;
        private Thread updateLabels;

        public SerialPort SerialPort
        {
            get { return pigeon; }
            set { pigeon = value; }
        }

        Sensor sensor1 = new Sensor();
        Sensor sensor2 = new Sensor();
        Sensor sensor3 = new Sensor();
        Sensor sensor4 = new Sensor();
        Sensor sensor5 = new Sensor();
        Sensor sensor6 = new Sensor();
        Sensor sensor7 = new Sensor();
        Sensor sensor8 = new Sensor();

        
        private void doStuff()
        {
            pigeon.DataReceived += ListenUp;
        }
       
        
        private void ListenUp(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if(pigeon.BytesToRead>0)
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

            switch (whichSens)
            {
                case 1:
                    sensor1.addData(transmitData);

                    temp1Box.Invoke((MethodInvoker)delegate
                    {
                        temp1Box.Text = Convert.ToString(sensor1.holdTemp);
                    });

                    hum1Box.Invoke((MethodInvoker)delegate
                    {
                        hum1Box.Text = Convert.ToString(sensor1.holdHum);
                    });

                    break;
                case 2:
                    sensor2.addData(transmitData);

                    temp2Box.Invoke((MethodInvoker)delegate
                    {
                        temp2Box.Text = Convert.ToString(sensor2.holdTemp);
                    });

                    hum2Box.Invoke((MethodInvoker)delegate
                    {
                        hum2Box.Text = Convert.ToString(sensor2.holdHum);
                    });

                    break;
                case 3:
                    sensor3.addData(transmitData);

                    temp3Box.Invoke((MethodInvoker)delegate
                    {
                        temp3Box.Text = Convert.ToString(sensor3.holdTemp);
                    });

                    hum3Box.Invoke((MethodInvoker)delegate
                    {
                        hum3Box.Text = Convert.ToString(sensor3.holdHum);
                    });

                    break;
                case 4:
                    sensor4.addData(transmitData);

                    temp4Box.Invoke((MethodInvoker)delegate
                    {
                        temp4Box.Text = Convert.ToString(sensor4.holdTemp);
                    });

                    hum4Box.Invoke((MethodInvoker)delegate
                    {
                        hum4Box.Text = Convert.ToString(sensor4.holdHum);
                    });

                    break;
                case 5:
                    sensor5.addData(transmitData);

                    temp5Box.Invoke((MethodInvoker)delegate
                    {
                        temp5Box.Text = Convert.ToString(sensor5.holdTemp);
                    });

                    hum5Box.Invoke((MethodInvoker)delegate
                    {
                        hum5Box.Text = Convert.ToString(sensor5.holdHum);
                    });

                    break;
                case 6:
                    sensor6.addData(transmitData);

                    temp6Box.Invoke((MethodInvoker)delegate
                    {
                        temp6Box.Text = Convert.ToString(sensor6.holdTemp);
                    });

                    hum6Box.Invoke((MethodInvoker)delegate
                    {
                        hum6Box.Text = Convert.ToString(sensor6.holdHum);
                    });

                    break;
                case 7:
                    sensor7.addData(transmitData);

                    temp7Box.Invoke((MethodInvoker)delegate
                    {
                        temp7Box.Text = Convert.ToString(sensor7.holdTemp);
                    });

                    hum7Box.Invoke((MethodInvoker)delegate
                    {
                        hum7Box.Text = Convert.ToString(sensor7.holdHum);
                    });

                    break;
                case 8:
                    sensor8.addData(transmitData);

                    temp8Box.Invoke((MethodInvoker)delegate
                    {
                        temp8Box.Text = Convert.ToString(sensor8.holdTemp);
                    });

                    hum8Box.Invoke((MethodInvoker)delegate
                    {
                        hum8Box.Text = Convert.ToString(sensor8.holdHum);
                    });

                    break;
                default: break;
            }
        }
                
      
        public HomePageForm()
        {
            InitializeComponent();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            serialThread = new Thread(doStuff);
            serialThread.Start();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsPageForm newGuy = new SettingsPageForm();

            newGuy.ShowDialog();
        }


        //start Eric Excel Testing
        /*
        void SaveAnswers(List<String> sensorData)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Create a new Excel package
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet;
                // Check if the worksheet already exists
                if (package.Workbook.Worksheets.Count == 0)
                {
                    // Create a new worksheet
                    worksheet = package.Workbook.Worksheets.Add("Sensor Data");

                    // Write the current date to the first row, first column
                    worksheet.Cells[1, 1].Value = DateTime.Now.ToString("MM-dd-yyyy");

                    int teamNameColumn = 2;
                    int questionNumberColumn = 1;

                    // Set column headers for team names and display scores
                    for (int i = 0; i < 6; i++)
                    {
                        string tempstr = "Team " + (i + 1);
                        worksheet.Cells[2, teamNameColumn].Value = tempstr;
                        teamNameColumn++;

                        //adds score to the correct column
                        if (teamInfo.TryGetValue(tempstr, out Tuple<string, string, int, int, string> teamTuple))
                        {
                            int score = teamTuple.Item3;
                            string customName = teamTuple.Item2;
                            worksheet.Cells[highestQuestionReached + 3, i + 2].Value = score;
                            worksheet.Cells[1, i + 2].Value = customName;
                        }
                        else
                        {
                            worksheet.Cells[highestQuestionReached + 3, i + 2].Value = 0;
                        }
                    }

                    // Set column header for question number
                    worksheet.Cells[2, questionNumberColumn].Value = "Question";

                    //Write "score" in column 1, row = highestQuestionReached + 3
                    worksheet.Cells[highestQuestionReached + 3, 1].Value = "Score";
                }
                else
                {
                    // Get the existing worksheet
                    worksheet = package.Workbook.Worksheets[0];
                }

                //adds question numbers to question column
                for (int l = 0; l < highestQuestionReached; l++)
                {
                    worksheet.Cells[l + 3, 1].Value = l + 1;
                }

                // Write answers for each team
                for (int j = 0; j < 6; j++)

                {
                    string teamName = "Team " + (j + 1);
                    for (int i = 0; i < answers.Count; i++)
                    {
                        if (answers[i].TeamName == teamName)
                        {
                            int row = answers[i].QuestionNumber + 2;
                            worksheet.Cells[row, j + 2].Value = answers[i].TeamAnswer;

                        }
                    }
                }


                // Save the Excel file
                package.SaveAs(new FileInfo(filePath));
            }
        }
    */

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            serialThread.Abort();
        }
    }
}
