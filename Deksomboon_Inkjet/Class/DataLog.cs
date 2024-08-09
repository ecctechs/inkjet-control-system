using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using CsvHelper.Configuration.Attributes;
using Npgsql;

namespace Deksomboon_Inkjet.Class
{
    public class DataLog
    {
        [Name(name: "หมายเลขออร์เดอร์")]
        public int ord_id { get; set; }

        [Name(name: "ข้อความ")]
        public string programs { get; set; }

        [Name(name: "จํานวนที่ยิง")]
        public int order_qty { get; set; }

        [Name(name: "วันที่เริ่มผลิต")]
        public string start_date { get; set; }

        [Name(name: "วันที่สิ้นสุดการผลิต")]
        public string end_date { get; set; }

        ////[Name(name: "emp_id")]
        //public int emp_id { get; set; }

        [Name(name: "ชื่อพนักงาน Authorzied")]
        public string emp_name { get; set; }

        public static List<DataLog> ListDataLog()
        {
            List<DataLog> ListDatalog = new List<DataLog>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM datalog
                    LEFT JOIN order_detail
                    ON order_detail.ord_id = datalog.ord_id
                    LEFT JOIN employee
                    ON employee.emp_id = datalog.emp_id Order by log_id;";



                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataLog datalog = new DataLog
                            {
                                ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                programs = reader.GetString(reader.GetOrdinal("programs")),
                                order_qty = reader.GetInt32(reader.GetOrdinal("order_qty")),
                                start_date = reader.GetString(reader.GetOrdinal("start_date")),
                                end_date = reader.GetString(reader.GetOrdinal("end_date")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListDatalog.Add(datalog);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListDatalog;
        }

        public static List<DataLog> Search_DataLog(string emp_id, string start_date, string end_date)
        {
            List<DataLog> listDataLog = new List<DataLog>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query;

                    if (emp_id != "0")
                    {
                        query = @"SELECT * FROM datalog
                    LEFT JOIN order_detail
                    ON order_detail.ord_id = datalog.ord_id
                    LEFT JOIN employee
                    ON employee.emp_id = datalog.emp_id
                    Where datalog.emp_id = '" + emp_id + "' Order by log_id;";
                    }
                    else
                    {
                        query = @"SELECT * FROM datalog
                    LEFT JOIN order_detail
                    ON order_detail.ord_id = datalog.ord_id
                    LEFT JOIN employee
                    ON employee.emp_id = datalog.emp_id  Order by log_id";
                    }

                    //Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataLog datalog = new DataLog
                            {
                                ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                programs = reader.GetString(reader.GetOrdinal("programs")),
                                order_qty = reader.GetInt32(reader.GetOrdinal("order_qty")),
                                start_date = reader.GetString(reader.GetOrdinal("start_date")),
                                end_date = reader.GetString(reader.GetOrdinal("end_date")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),

                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };
                            var date_records = DateTime.Parse(datalog.start_date);
                            var date_records_start = DateTime.Parse(start_date);
                            var date_records_end = DateTime.Parse(end_date);

                            if (date_records >= date_records_start && date_records <= date_records_end)
                            {
                                listDataLog.Add(datalog);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return listDataLog;
        }

        public static void Add_DatLog(int ord_id, string programs, int order_qty, string start_date, string end_date, int emp_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO datalog (ord_id, programs, order_qty, start_date, end_date , emp_id  ) 
                             VALUES (@ord_id, @programs, @order_qty, @start_date, @end_date , @emp_id )";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@ord_id", ord_id);
                        command.Parameters.AddWithValue("@programs", programs);
                        command.Parameters.AddWithValue("@order_qty", order_qty);
                        command.Parameters.AddWithValue("@start_date", start_date);
                        command.Parameters.AddWithValue("@end_date", end_date);
                        command.Parameters.AddWithValue("@emp_id", emp_id);

                        command.ExecuteNonQuery();

                        Console.WriteLine("DataLog added successfully.");
                        //MessageBox.Show("DataLog added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding DataLog: " + e.Message);
                MessageBox.Show("Error adding DataLog: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Add_Authorized_Log(int ord_id, int emp_id, string date_authorized, string action, int level_authorized, string tenDigit)
        {
            //Console.WriteLine("ten :" + tenDigit);
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO authorized_log (ord_id, emp_id, date_authorized, action, level_authorized , batch_number  ) 
                             VALUES (@ord_id, @emp_id, @date_authorized, @action, @level_authorized , @batch_number )";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@ord_id", ord_id);
                        command.Parameters.AddWithValue("@emp_id", emp_id);
                        command.Parameters.AddWithValue("@date_authorized", date_authorized);
                        command.Parameters.AddWithValue("@action", action);
                        command.Parameters.AddWithValue("@level_authorized", level_authorized);
                        command.Parameters.AddWithValue("@batch_number", tenDigit);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Authorized DataLog added successfully.");
                        //MessageBox.Show("Authorized DataLog added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding Authorized DataLog: " + e.Message);
                MessageBox.Show("Error adding Authorized DataLog: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_DateLog(int ord_id, int order_qty, string end_date, int emp_id, string tenDigit , string order_date_start)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE datalog SET order_qty = '" + order_qty + "', end_date = '" + end_date + "', emp_id = '" + emp_id + "' WHERE ord_id = '" + ord_id + "' and programs = '" + tenDigit + "' and start_date = '"+ order_date_start + "'";
                    Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@ord_id", ord_id);
                        command.Parameters.AddWithValue("@order_qty", order_qty);
                        command.Parameters.AddWithValue("@end_date", end_date);
                        command.Parameters.AddWithValue("@emp_id", emp_id);
                        command.Parameters.AddWithValue("@programs", tenDigit);

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order with ID " + ord_id + " updated successfully.");
                            //MessageBox.Show("Order with ID " + ord_id + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("Order with ID " + ord_id + " not found.");
                            MessageBox.Show("Order with ID 2222 " + ord_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating Order: " + e.ToString());
                MessageBox.Show("Error updating Order: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Delete_DataLog(int ord_id,string ord_start_date)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "DELETE FROM datalog WHERE ord_id = '"+ ord_id + "' and start_date = '" + ord_start_date + "'";
                    //Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@ord_id", ord_id);
                        command.Parameters.AddWithValue("@ord_start_date", ord_start_date);

                        command.ExecuteNonQuery();

                        Console.WriteLine("DataLog deleted successfully.");
                        //MessageBox.Show("DataLog deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting DataLog: " + e.Message);
                MessageBox.Show("Error deleting DataLog: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
