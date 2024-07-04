using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();          
        }

        static frmConnection _instance;

        public static frmConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmConnection();
                return _instance;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string line = cboLine.Text;
            string inkjet = guna2ComboBox2.Text;
            //string line = cboLine.SelectedValue.ToString();
            //string inkjet = guna2ComboBox2.SelectedValue.ToString();
            string line_prefix = txtLocationPrefix.Text;

            //Console.WriteLine("--------->>"+ line);


            if (line == "0" || inkjet == "0")
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
    }
}
