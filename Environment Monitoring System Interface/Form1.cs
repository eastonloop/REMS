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
        public string data;
        bool stop = false;

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
            isConnectedToCU = true;     //DON'T KEEP IT LIKE THIS
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

                    if (true/*responseTask.IsCompleted && responseTask.Result == "Connected"*/)
                    {
                        serialPort1.Open();
                        isConnectedToCU = true;
                        textBox1.Text = "Connected";
                        //if (stop)
                        //    serialPort1.DataReceived += SerialPort1_DataReceived;
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
     
        private void continueButton_Click_1(object sender, EventArgs e)
        {
            if (isConnectedToCU)
            {
                HomePageForm form = new HomePageForm
                {
                    SerialPort = serialPort1
                };

                stop = true;                

              //  Task.Delay(500);
                this.Hide();

                form.ShowDialog();           
                
              //  Task.Delay(500);
              //  this.Dispose();
            }
        }
    }
}
