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
using Deksomboon_Inkjet.Pop_up;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucEmployee : UserControl
    {
        public ucEmployee()
        {
            InitializeComponent();
        }
        private void ucEmployee_Load_1(object sender, EventArgs e)
        {
            get_employee();

            DataGridEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridEmployee.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
        }

        public void get_employee()
        {
            List<Employee> records = Employee.ListEmployee();
            employeeBindingSource.DataSource = records;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (AddEditEmployee frm = new AddEditEmployee(new Employee()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_employee();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                using (AddEditEmployee frm = new AddEditEmployee(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        get_employee();
                    }

                    else
                    {
                        get_employee();
                    }
                }
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;

            DialogResult result = MessageBox.Show("คุณต้องการลบพนักงานชื่อ " + obj.emp_name + " หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Employee.Delete_Employee(obj.emp_id);
                get_employee();
            }
        }

        private void DataGridEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
