using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class SerialPortManager
    {
        public SerialPort serialPort;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public static SerialPortManager _instance;

        public static SerialPortManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SerialPortManager();
                }
                return _instance;
            }
        }

        public SerialPortManager()
        {
            serialPort = new SerialPort();

            serialPort.Encoding = Encoding.GetEncoding(28591);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
        }

        public void ConfigureSerialPort(string portName, string baudRate, string dataBits, string stopBits, string parity)
        {
            try
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = Convert.ToInt32(baudRate);
                serialPort.DataBits = Convert.ToInt32(dataBits);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Configuration error: " + ex.Message);
                Console.WriteLine("Configuration error: " + ex.Message);
            }
        }

        public void OpenSerialPort()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    //MessageBox.Show("Serial Port Opened Successfully!");
                    Console.WriteLine("Serial Port Opened Successfully!");
                }
                else
                {
                    MessageBox.Show("Serial Port is already open.");
                    
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Open error: " + ex.Message);
                Console.WriteLine("Open error: " + ex.Message);
            }
        }

        public void CloseSerialPort()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    MessageBox.Show("Serial Port Closed Successfully!");
                }
                else
                {
                    MessageBox.Show("Serial Port is not open.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close error: " + ex.Message);
            }
        }

        public void SetProgressBar(ProgressBar progressBar)
        {
            if (serialPort.IsOpen)
            {
                progressBar.Value = 100;
            }
            else
            {
                progressBar.Value = 0;
            }
        }

        //public void SendCommand(byte[] commandBytes)
        //{
        //    try
        //    {
        //        if (serialPort.IsOpen)
        //        {
        //            serialPort.Write(commandBytes, 0, commandBytes.Length);
        //            // Adding a small delay might help with timing issues
        //            Task.Delay(100).Wait(); // Delay for 100 milliseconds
        //            //MessageBox.Show("Command sent successfully!");
        //            // Log command sent successfully
        //            Console.WriteLine("Command sent successfully.");

        //        }
        //        else
        //        {
        //            MessageBox.Show("Serial Port is not open.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Send error: " + ex.Message);
        //    }
        //}

        public async Task SendCommandAsync(byte[] commandBytes)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Write(commandBytes, 0, commandBytes.Length);
                    // Adding a small delay might help with timing issues
                    await Task.Delay(100); // Delay for 100 milliseconds
                                           // Log command sent successfully
                    Console.WriteLine("Command sent successfully.");
                }
                else
                {
                    // Log serial port not open
                    Console.WriteLine("Serial Port is not open.");
                }
            }
            catch (Exception ex)
            {
                // Log send error
                Console.WriteLine("Send error: " + ex.Message);
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string dataIN = serialPort.ReadExisting();
            DataReceived?.Invoke(this, new DataReceivedEventArgs(dataIN));
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        public void DiscardInBuffer()
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
            }
        }
    }
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; private set; }

        public DataReceivedEventArgs(string data)
        {
            Data = data;
        }

    }
}
