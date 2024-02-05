using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

namespace Environment_Monitoring_System_Interface
{
    public partial class Form1 : Form
    {
        string selectedCOMPort;
        private ManagementEventWatcher comPortWatcher;
         
        bool ArduinoConnected;
        public bool isConnectedToCU = false;
        string data;

        //start Eric storage of data coming in
        List<String> sensorDataList;

        private async Task<string> ReadResponse()
        {
            using (var reader = new StreamReader(serialPort1.BaseStream))
            {
                try
                {
                    string response = await reader.ReadLineAsync();
                    return response;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                    return string.Empty;
                }
            }
        }
        private async void autoConnectCOMPort()
        {
            isConnectedToCU = false;
            string[] comPorts = GetCOMPorts();

            foreach (string port in comPorts)
            {
                if (serialPort1.IsOpen)
                {
                    return;
                }

                serialPort1.PortName = port;
                serialPort1.BaudRate = 9600;
                serialPort1.DtrEnable = true;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Encoding = System.Text.Encoding.Default;

                try
                {
                    await Task.Run(() => serialPort1.Open());
                    serialPort1.Write("Z");
                    var timeoutTask = Task.Delay(TimeSpan.FromSeconds(1));
                    var responseTask = ReadResponse();

                    await Task.WhenAny(responseTask, timeoutTask);

                    if (responseTask.IsCompleted && responseTask.Result == "Connected")
                    {
                        serialPort1.Open();
                        isConnectedToCU = true;
                        textBox1.Text = "Connected";
                        serialPort1.DataReceived += SerialPort1_DataReceived;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception during COM port communication: {ex.Message}");
                    textBox1.Text = "Not connected";
                }
                finally
                {
                    if (!isConnectedToCU)
                    {
                        serialPort1.Close();
                    }
                }
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();

            //test data storage


            textBox2.Invoke((MethodInvoker)delegate
            {
                textBox2.Text = data;
            });
            
        }

        public Form1()
        {
            InitializeComponent();

            comPortWatcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            comPortWatcher.EventArrived += new EventArrivedEventHandler(ComPortEventArrived);
            comPortWatcher.Query = query;
            comPortWatcher.Start();
            autoConnectCOMPort();
            GetData();
        }
       
        private void ComPortEventArrived(object sender, EventArrivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(autoConnectCOMPort));
            }
            else
            {
                autoConnectCOMPort();
            }
        }

        private string[] GetCOMPorts()
        {
            string[] availablePorts = SerialPort.GetPortNames();
            return availablePorts;
        }

        private void populateCOMPorts()
        {
            string[] availablePorts = SerialPort.GetPortNames();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            populateCOMPorts();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            comPortWatcher.Stop();
            comPortWatcher.Dispose();
        }

        private async void GetData()
        {
            if (serialPort1.IsOpen && isConnectedToCU)
            {
                var responseTask = ReadResponse();
                await Task.WhenAny(responseTask);

                if (responseTask.IsCompleted)
                {
                    return;
                }
            }
           
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
        
    }
    */
}
