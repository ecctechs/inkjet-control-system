using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class Inkjet
    {
        public int inkjet_id { get; set; }
        public string inkjet_name { get; set; }
        public int location_id { get; set; }
        public string location_name { get; set; }
        public string inkjet_status { get; set; }
        public string inkjet_connect { get; set; }

        public static List<Inkjet> ListInkjet()
        {
            List<Inkjet> ListInkjet = new List<Inkjet>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM inkjet
                    LEFT JOIN location
                    ON location.location_id = inkjet.location_id Order by inkjet_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inkjet inkjet = new Inkjet
                            {
                                inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                inkjet_connect = reader.GetString(reader.GetOrdinal("inkjet_connect")),
                                inkjet_status = reader.GetString(reader.GetOrdinal("inkjet_status")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListInkjet.Add(inkjet);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListInkjet;
        }

        public static List<Inkjet> ListInkjetByID(int id)
        {
            List<Inkjet> ListInkjet = new List<Inkjet>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM inkjet Where location_id = " + id;

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inkjet inkjet = new Inkjet
                            {
                                inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListInkjet.Add(inkjet);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListInkjet;
        }

        public static List<Inkjet> ListInkjetLocationByInkjetName(string name)
        {
            List<Inkjet> ListInkjet = new List<Inkjet>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    //string query = "SELECT * FROM inkjet Where inkjet_name = '" + name + "' ";
                    string query = "SELECT * FROM inkjet LEFT JOIN location ON location.location_id = inkjet.location_id Where inkjet.inkjet_name = '"+name+"' Order by inkjet_id";
                    Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inkjet inkjet = new Inkjet
                            {
                                inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                inkjet_status = reader.GetString(reader.GetOrdinal("inkjet_status")),
                                location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListInkjet.Add(inkjet);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListInkjet;
        }

        //public static List<Inkjet> ListInkjetByInkjetName(string name)
        //{
        //    List<Inkjet> ListInkjet = new List<Inkjet>();

        //    try
        //    {
        //        using (var dbManager = new DatabaseManager())
        //        {
        //            dbManager.OpenConnection();

        //            string query = "SELECT * FROM inkjet Where inkjet_name = '" + name + "' ";

        //            using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
        //            using (NpgsqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Inkjet inkjet = new Inkjet
        //                    {
        //                        inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
        //                        inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
        //                        inkjet_status = reader.GetString(reader.GetOrdinal("inkjet_status")),
        //                        location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
        //                        // เพิ่ม properties อื่น ๆ ตามต้องการ
        //                    };

        //                    ListInkjet.Add(inkjet);
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }

        //    return ListInkjet;
        //}

        public static void Add_Inkjet(string inkjet_name, string location_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO inkjet (inkjet_name, location_id , inkjet_connect , inkjet_status) 
                             VALUES ('" + inkjet_name + "', '" + Int32.Parse(location_id) + "' , 'Not Connect' , '---')";

                    //Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@location_name", inkjet_name);
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(location_id));

                        command.ExecuteNonQuery();

                        Console.WriteLine("inkjet added successfully.");
                        MessageBox.Show("inkjet added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding inkjet: " + e.ToString());
                MessageBox.Show("Error adding inkjet: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_Inkjet(string inkjet_id, string inkjet_name, string location_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE inkjet 
                             SET inkjet_name = @inkjet_name,
                             location_id = @location_id 
                             WHERE inkjet_id = @inkjet_id";

                    //Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@inkjet_id", Int32.Parse(inkjet_id));
                        command.Parameters.AddWithValue("@inkjet_name", inkjet_name);
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(location_id));


                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("inkjet with ID " + inkjet_id + " updated successfully.");
                            MessageBox.Show("inkjet with ID " + inkjet_id + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("inkjet with ID " + inkjet_id + " not found.");
                            MessageBox.Show("inkjet with ID " + inkjet_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void Update_Inkjet_status(string inkjet_name, string inkjet_status)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE inkjet 
                             SET inkjet_status = @inkjet_status 
                             WHERE inkjet_name = @inkjet_name";

                    //Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์         
                        command.Parameters.AddWithValue("@inkjet_status", inkjet_status);
                        command.Parameters.AddWithValue("@inkjet_name", inkjet_name);

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            //Console.WriteLine("inkjet with ID " + inkjet_name + " updated successfully.");
                            Console.WriteLine("Inkjet Name :" + inkjet_name + " Update Status Successfully in Database");
                            //MessageBox.Show("inkjet with ID " + inkjet_name + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("inkjet with ID " + inkjet_name + " not found.");
                            //MessageBox.Show("inkjet with ID " + inkjet_name + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating inkjet: " + e.ToString());
                //MessageBox.Show("Error updating inkjet: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Delete_Inkjet(int inkjet_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"DELETE FROM inkjet where inkjet_id ='" + inkjet_id + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the delete
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("inkjet deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No inkjet found to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting inkjet: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Duplicate_Inkjet(int inkjet_id, string inkjet_name)
        {
            List<Inkjet> list_inkjet = ListInkjet();
            foreach (var inkjet in list_inkjet)
            {
                if (inkjet_name == inkjet.inkjet_name && inkjet_id != inkjet.inkjet_id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
