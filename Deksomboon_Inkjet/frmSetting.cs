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
            get_location();

            string inkjet_local = LocalStorage.ReadInkjetData();
            string location_local = LocalStorage.ReadLocationData();

            //Console.WriteLine(lcation_prefix);

            if (inkjet_local != null && location_local != null)
            {
                cboLine.Text = location_local;
                guna2ComboBox2.Text = inkjet_local;
            }
            else
            {
                cboLine.SelectedIndex = 0;
                //guna2ComboBox2.SelectedIndex = 0;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            rs232_connect();
            line_setting();
        }

        public void line_setting()
        {
            string line = cboLine.Text;
            string inkjet = guna2ComboBox2.Text;
            //string line = cboLine.SelectedValue.ToString();
            //string inkjet = guna2ComboBox2.SelectedValue.ToString();
            string line_prefix = txtLocationPrefix.Text;

            //Console.WriteLine("--------->>"+ cboLine.SelectedIndex + "---" + inkjet);


            if (cboLine.SelectedIndex == 0 || guna2ComboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Please Fill All Data");
            }
            else
            {
                LocalStorage.AddInkjetData(inkjet);
                LocalStorage.AddLocationData(line);
                LocalStorage.AddLocationPrefixData(line_prefix);
                MessageBox.Show("เปลี่ยนไลน์ผลิตสําเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
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
                    //DialogResult = DialogResult.OK;
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

        public void get_location()
        {
            List<location> records = location.ListLocation();
            records.Insert(0, new location() { location_id = 0, location_name = "เลือก" });
            locationBindingSource.DataSource = records;
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            var line_selected = cboLine.SelectedValue;
            int lineId = Convert.ToInt32(line_selected);
            List<Inkjet> records = Inkjet.ListInkjetByID(lineId);
            records.Insert(0, new Inkjet() { inkjet_id = 0, inkjet_name = "เลือก" });
            inkjetBindingSource.DataSource = records;

            List<location> records2 = location.ListLocationByID(cboLine.Text);
            if (lineId > 0)
            {
                txtLocationPrefix.Text = records2[0].location_prefix;
            }
        }
    }
}
