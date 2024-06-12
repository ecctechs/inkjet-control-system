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
    public partial class AddEditLocation : Form
    {
        public AddEditLocation(location obj)
        {
            InitializeComponent();
            get_manager();
            if (obj.location_id != 0)
            {
                string location_id = Convert.ToString(obj.location_id);
                txtLocationName.Text = obj.location_name;
                txtLocationID.Text = location_id;
                textLocationPrefix.Text = obj.location_prefix;
                cboManager.Text = obj.emp_name;
            }
            else
            {
                cboManager.Text = "เลือก";
            }
        }
        private void AddEditLocation_Load(object sender, EventArgs e)
        {
            //get_manager();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        public void get_manager()
        {
            List<Employee> records = Employee.ListEmployeeByManager();
            records.Insert(0, new Employee() { emp_id = 0, emp_name = "เลือก" });
            cboManager.DataSource = records;
            cboManager.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var location_id = txtLocationID.Text;
            var location_name = txtLocationName.Text;
            var location_prefix = textLocationPrefix.Text;
            int emp_id = (int)cboManager.SelectedValue;

            
            //Console.WriteLine(emp_id);

            // ตรวจสอบว่ามีช่องไหนที่ว่างเปล่าหรือไม่
            if (string.IsNullOrWhiteSpace(location_name) ||
                string.IsNullOrWhiteSpace(location_prefix) ||
                emp_id == 0)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }

            if (location_prefix.Length < 2)
            {
                MessageBox.Show("ชื่อย่อไลน์ผลิตควรมี 2 ตัวอักษร");
                return;
            }
        
            var chk_duplicate = location.Duplicate_Location(Int32.Parse(location_id), location_name);

            if (chk_duplicate == false)
            {
                MessageBox.Show("ไลน์ผลิต " + location_name + " มีอยู่ในระบบแล้ว");
                return;
            }

            if (location_id == "0") // Add
            {
                location.Add_Location(location_name, emp_id, location_prefix);
                DialogResult = DialogResult.OK;
            }
            else // Update
            {
                location.Update_Location(location_id, location_name, emp_id, location_prefix);
                DialogResult = DialogResult.OK;
            }
      
        }
    }
}
