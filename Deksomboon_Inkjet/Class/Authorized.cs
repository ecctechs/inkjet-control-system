using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Deksomboon_Inkjet.Pop_up;

namespace Deksomboon_Inkjet.Class
{
    public class Authorized
    {
        public static string authorized_level_1(string empidtextbox, string emppasstextbox)
        {
            string emp_code = empidtextbox;
            string emp_pass = emppasstextbox;

            if (!string.IsNullOrEmpty(emp_code) && !string.IsNullOrEmpty(emp_pass))
            {
                List<Employee> authorized_status = Authorized.ListEmployeeByEmpCode(emp_code, emp_pass);

                if (authorized_status.Count > 0)
                {
                    return authorized_status[0].emp_id.ToString();
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลพนักงานหรือรหัสผ่านไม่ถูกต้อง");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอก รหัสพนักงานและพาสเวิร์ด");
                return null;
            }
        }

        public static string authorized_level_2(string empidtextbox, string emppasstextbox)
        {
            string emp_code = empidtextbox;
            string emp_pass = emppasstextbox;

            if (!string.IsNullOrEmpty(emp_code) && !string.IsNullOrEmpty(emp_pass))
            {
                List<Employee> authorized_status = Authorized.ListEmployeeByEmpCode(emp_code, emp_pass);
            
                if (authorized_status.Count > 0)
                {
                    using (Otp_order otp_order = new Otp_order())
                    {
                        if (otp_order.ShowDialog() == DialogResult.OK)
                        {
                            return authorized_status[0].emp_id.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลพนักงานหรือรหัสผ่านไม่ถูกต้อง");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอก รหัสพนักงานและพาสเวิร์ด");
                return null;
            }
        }

        public static List<Employee> ListEmployeeByEmpCode(string emp_code, string emp_pass)
        {
            List<Employee> ListEmployee = new List<Employee>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM employee where emp_code = '" + emp_code + "' AND emp_password = '" + emp_pass + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                emp_id = reader.GetInt32(reader.GetOrdinal("emp_id")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                emp_code = reader.GetString(reader.GetOrdinal("emp_code")),
                                emp_password = reader.GetString(reader.GetOrdinal("emp_password")),
                                emp_role = reader.GetString(reader.GetOrdinal("emp_role")),
                                emp_email = reader.GetString(reader.GetOrdinal("emp_email")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListEmployee.Add(employee);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListEmployee;
        }
    }
}
