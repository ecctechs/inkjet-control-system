using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.UserControls;
using Npgsql;

namespace Deksomboon_Inkjet.Class
{
    public class Employee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_code { get; set; }
        public string emp_password { get; set; }
        public string emp_role { get; set; }
        public string emp_email { get; set; }

        public static List<Employee> ListEmployee()
        {
            List<Employee> ListEmployee = new List<Employee>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM employee order by emp_id";

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

        public static void Add_Employee(string empname, string empcode, string emppass, string emprole, string empemail)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO employee (emp_name, emp_code, emp_password, emp_role, emp_email) 
                             VALUES (@empname, @empcode, @emppass, @emprole, @empemail)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@empname", empname);
                        command.Parameters.AddWithValue("@empcode", empcode);
                        command.Parameters.AddWithValue("@emppass", emppass);
                        command.Parameters.AddWithValue("@emprole", emprole);
                        command.Parameters.AddWithValue("@empemail", empemail);

                        command.ExecuteNonQuery();

                        Console.WriteLine("เพิ่มข้อมูลเรียบร้อย");
                        MessageBox.Show("เพิ่มข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding employee: " + e.Message);
                MessageBox.Show("Error adding employee: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_Employee(string emp_id, string empname, string empcode, string emppass, string emprole, string empemail)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE employee
                             SET emp_name = @empname, emp_code = @empcode, emp_password = @emppass, emp_role = @emprole, emp_email = @empemail 
                             WHERE emp_id = @emp_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@empname", empname);
                        command.Parameters.AddWithValue("@empcode", empcode);
                        command.Parameters.AddWithValue("@emppass", emppass);
                        command.Parameters.AddWithValue("@emprole", emprole);
                        command.Parameters.AddWithValue("@empemail", empemail);
                        // สมมติว่าคุณมีคอลัมน์ emp_id เพื่อระบุพนักงานที่ต้องการปรับปรุง
                        command.Parameters.AddWithValue("@emp_id", Int32.Parse(emp_id)); // แก้ไขตามต้องการ

                        command.ExecuteNonQuery();

                        Console.WriteLine("Employee updated successfully.");
                        MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Error updating employee: " + e.Message);
                MessageBox.Show("Error updating employee: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static bool Duplicate_employee(int emp_id, string emp_code)
        {
            List<Employee> list_employee = ListEmployee();
            foreach (var employee in list_employee)
            {
                if (emp_code == employee.emp_code && emp_id != employee.emp_id)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Delete_Employee(int emp_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"DELETE FROM employee WHERE emp_id = @emp_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@emp_id", emp_id);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Employee deleted successfully.");
                        MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting employee: " + e.Message);
                MessageBox.Show("Error deleting employee: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Employee> ListEmployeeByManager()
        {
            List<Employee> ListEmployee = new List<Employee>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM employee where emp_role = 'Manager'";

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
