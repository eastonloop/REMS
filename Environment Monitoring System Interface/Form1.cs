﻿using System;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Environment_Monitoring_System_Interface
{

    public partial class Form1 : Form
    {
        private ManagementEventWatcher comPortWatcher;

        public bool isConnectedToCU = false;
        public string data;
        bool stop = false;

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

                        serialPort1.Open();
                        if(serialPort1.IsOpen) 
                            isConnectedToCU = true;
                        if (stop)
                            serialPort1.DataReceived += SerialPort1_DataReceived;
                        return;
                }
                catch (Exception ex)
                {
                    welcomeMessageBox.Text = $"Exception during COM port communication: {ex.Message}";
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
            HomePageForm form = new HomePageForm
            {
                SerialPort = serialPort1
            };

            stop = true;

            this.Hide();

            form.ShowDialog();

            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
