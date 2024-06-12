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
using Deksomboon_Inkjet.UserControls;

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class AddEditEmployee : Form
    {
        public AddEditEmployee(Employee obj)
        {
            InitializeComponent();

            if (obj.emp_id != null)
            {               
                string emp_id = Convert.ToString(obj.emp_id);
                empID.Text = emp_id;
                emp_name.Text = obj.emp_name;
                emp_code.Text = obj.emp_code;
                emp_pass.Text = obj.emp_password;
                emp_email.Text = obj.emp_email;
                emp_role.Text = obj.emp_role;   
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var empid = empID.Text;
            var empname = emp_name.Text;
            var empcode = emp_code.Text;
            var emppass = emp_pass.Text;
            var emprole = emp_role.Text;
            var empemail = emp_email.Text;

            // ตรวจสอบว่ามีช่องไหนที่ว่างเปล่าหรือไม่
            if (string.IsNullOrWhiteSpace(empname) ||
                string.IsNullOrWhiteSpace(empcode) ||
                string.IsNullOrWhiteSpace(emppass) ||
                string.IsNullOrWhiteSpace(emprole) ||
                string.IsNullOrWhiteSpace(empemail))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }

            var chk_duplicate = Employee.Duplicate_employee(Int32.Parse(empid), empcode);


            // ตรวจสอบว่ารหัสพนักงานและรหัสผ่านเหมือนกันหรือไม่
            if (empcode == emppass)
            {
                MessageBox.Show("รหัสพนักงานและพาสเวิร์ดไม่ควรซํ้ากัน");
                return;
            }

            if (chk_duplicate == false)
            {
                MessageBox.Show("รหัส " + empcode + " มีอยู่ในระบบแล้ว");
                return;
            }

            if (empid == "0") // Add
            {              
                    Employee.Add_Employee(empname, empcode, emppass, emprole, empemail);
                    DialogResult = DialogResult.OK;
            }
            else // Update
            {
                    Employee.Update_Employee(empid, empname, empcode, emppass, emprole, empemail);
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
