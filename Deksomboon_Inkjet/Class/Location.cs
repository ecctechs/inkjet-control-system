using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class location
    {
        public int location_id { get; set; }
        public string location_name { get; set; }

        public string emp_name { get; set; }

        public string emp_email { get; set; }

        public string location_prefix { get; set; }


        public static List<location> ListLocation()
        {
            List<location> ListLocation = new List<location>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM location
                    LEFT JOIN employee
                    ON employee.emp_id = location.emp_id Order by location_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            location location = new location
                            {
                                location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                location_prefix = reader.GetString(reader.GetOrdinal("location_prefix")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListLocation.Add(location);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListLocation;
        }

        public static List<location> ListLocationByID(string location_name)
        {
            List<location> ListLocation = new List<location>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM location 
                    LEFT JOIN employee 
                    ON employee.emp_id = location.emp_id 
                    Where location.location_name = '" + location_name + "'";
                    Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            location location = new location
                            {
                                location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                emp_email = reader.GetString(reader.GetOrdinal("emp_email")),
                                location_prefix = reader.GetString(reader.GetOrdinal("location_prefix")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListLocation.Add(location);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListLocation;
        }

        public static void Add_Location(string location_name, int emp_id, string location_prefix)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO location (location_name,emp_id,location_prefix) 
                             VALUES (@location_name,@emp_id,@location_prefix)";

                    Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@location_name", location_name);
                        command.Parameters.AddWithValue("@emp_id", emp_id);
                        command.Parameters.AddWithValue("@location_prefix", location_prefix);

                        command.ExecuteNonQuery();

                        Console.WriteLine("location added successfully.");
                        MessageBox.Show("เพิ่มข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding location: " + e.ToString());
                MessageBox.Show("Error adding location: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_Location(string location_id, string location_name, int emp_id, string location_prefix)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE location 
                             SET location_name = @location_name,
                             emp_id = @emp_id,
                             location_prefix = @location_prefix 
                             WHERE location_id = @location_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(location_id));
                        command.Parameters.AddWithValue("@location_name", location_name);
                        command.Parameters.AddWithValue("@emp_id", emp_id);
                        command.Parameters.AddWithValue("@location_prefix", location_prefix);


                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("location with ID " + location_id + " updated successfully.");
                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("location with ID " + location_id + " not found.");
                            MessageBox.Show("location with ID " + location_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating location: " + e.ToString());
                MessageBox.Show("Error updating location: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Delete_Location(int location_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"DELETE FROM location where location_id ='" + location_id + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the delete
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No location found to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting location: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Duplicate_Location(int location_id, string location_name)
        {
            List<location> list_location = ListLocation();
            foreach (var location in list_location)
            {
                if (location_name == location.location_name && location_id != location.location_id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
