using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class AddEditInkjet : Form
    {
        public AddEditInkjet(Inkjet obj)
        {
            InitializeComponent();
            get_location();
            if (obj.inkjet_id != 0)
            {
                string inkjet_id = Convert.ToString(obj.inkjet_id);
                txtInkjetID.Text = inkjet_id;
                txtInkjetName.Text = obj.inkjet_name;
                cboLine.Text = obj.location_name;
            }
            else
            {
                cboLine.SelectedIndex = 0;
            }
        }
        private void AddEditInkjet_Load(object sender, EventArgs e)
        {
            //get_location();
        }

        public void get_location()
        {
            List<location> records = location.ListLocation();
            records.Insert(0, new location() { location_id = 0, location_name = "เลือก" });
            cboLine.DataSource = records;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var inkjet_id = txtInkjetID.Text;
            var inkjet_name = txtInkjetName.Text;
            var location_id = cboLine.SelectedValue.ToString();


            if (string.IsNullOrWhiteSpace(location_id) ||
             string.IsNullOrWhiteSpace(inkjet_name) ||
                location_id == "0" )
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }

            var chk_duplicate = Inkjet.Duplicate_Inkjet(Int32.Parse(inkjet_id), inkjet_name);

            if (chk_duplicate == false)
            {
                MessageBox.Show("อินเจ็ก " + inkjet_name + " มีอยู่ในระบบแล้ว");
                return;
            }

            if (inkjet_id == "0") // Add
            {
                Inkjet.Add_Inkjet(inkjet_name, location_id.ToString());
                DialogResult = DialogResult.OK;
            }
            else // Update
            {
                Inkjet.Update_Inkjet(inkjet_id, inkjet_name, location_id.ToString());
                DialogResult = DialogResult.OK;
            }


        }
    }
}
