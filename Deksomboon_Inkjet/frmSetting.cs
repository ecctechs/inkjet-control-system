using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using Deksomboon_Inkjet.UserControls;

namespace Deksomboon_Inkjet
{
    public partial class frmSetting : Form
    {
        private SerialPortManager serialPortManager;
        public frmSetting()
        {
            InitializeComponent();
            serialPortManager = SerialPortManager.Instance;
            string[] ports = SerialPort.GetPortNames();
            cboCOMPort.Items.AddRange(ports);

            if (LocalStorage.ReadLocalComport() != null)
            {
                cboCOMPort.Text = LocalStorage.ReadLocalComport();
            }

            cboDataBite.SelectedIndex = 0;
            cboBaudRate.SelectedIndex = 0;
            cboParity.SelectedIndex = 0;
            cboStopBit.SelectedIndex = 0;

        }

        static frmSetting _instance;

        public static frmSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSetting();
                return _instance;
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            //if (LocalStorage.ReadLocalComport() != null)
            //{
            //    cboCOMPort.Text = LocalStorage.ReadLocalComport();
            //}

            //cboDataBite.SelectedIndex = 0;
            //cboBaudRate.SelectedIndex = 0;
            //cboParity.SelectedIndex = 0;
            //cboStopBit.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            rs232_connect();
        }

        public void rs232_connect()
        {
            try
            {
                string PortName = cboCOMPort.Text;
                string BaudRate = cboBaudRate.Text;
                string DataBits = cboDataBite.Text;
                string StopBits = cboStopBit.Text;
                string Parity = cboParity.Text;

                serialPortManager.ConfigureSerialPort(PortName, BaudRate, DataBits, StopBits, Parity);
                serialPortManager.OpenSerialPort();

                if (serialPortManager.IsOpen())
                {
                    DialogResult = DialogResult.OK;
                    LocalStorage.Add_Local_ComPort(PortName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serialPortManager.CloseSerialPort();
            DialogResult = DialogResult.Cancel;
        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortManager.IsOpen())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
