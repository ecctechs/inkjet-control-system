using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class Material
    {
        public string material_id { get; set; }
        public string per_ind { get; set; }
        public int slife { get; set; }
        public string material_des { get; set; }
        public string formula { get; set; }
        public int id { get; set; }

        public static List<Material> ListMaterial()
        {
            List<Material> ListMaterial = new List<Material>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM material Order by id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Material material = new Material
                            {
                                material_id = reader.GetString(reader.GetOrdinal("material_id")),
                                per_ind = reader.GetString(reader.GetOrdinal("per_ind")),
                                slife = reader.GetInt32(reader.GetOrdinal("slife")),
                                material_des = reader.GetString(reader.GetOrdinal("material_des")),
                                formula = reader.GetString(reader.GetOrdinal("formula")),
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListMaterial.Add(material);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListMaterial;
        }

        public static List<Material> ListMaterialByID(string id)
        {
            List<Material> ListMaterial = new List<Material>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "SELECT * FROM material Where material_id = '" + id + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Material material = new Material
                            {
                                per_ind = reader.GetString(reader.GetOrdinal("per_ind")),
                                slife = reader.GetInt32(reader.GetOrdinal("slife")),
                                material_des = reader.GetString(reader.GetOrdinal("material_des")),
                                formula = reader.GetString(reader.GetOrdinal("formula")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListMaterial.Add(material);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return ListMaterial;
        }

        public static void Add_Material(string material_id, string material_description, string slife, string per_ind, string formula)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO material (material_id, per_ind, slife, material_des, formula) 
                             VALUES (@material_id, @per_ind, @slife, @material_des, @formula)";

                    Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@material_id", material_id);
                        command.Parameters.AddWithValue("@per_ind", per_ind);
                        command.Parameters.AddWithValue("@slife", int.Parse(slife));
                        command.Parameters.AddWithValue("@material_des", material_description);
                        command.Parameters.AddWithValue("@formula", formula);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Material added successfully.");
                        MessageBox.Show("Material added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding material: " + e.ToString());
                MessageBox.Show("Error adding material: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_Material(string material_id, string material_description, string slife, string per_ind, string formula)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE material 
                             SET material_des = @material_des, 
                                 slife = @slife, 
                                 per_ind = @per_ind, 
                                 formula = @formula
                             WHERE material_id = @material_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@material_id", material_id);
                        command.Parameters.AddWithValue("@material_des", material_description);
                        command.Parameters.AddWithValue("@slife", int.Parse(slife));
                        command.Parameters.AddWithValue("@per_ind", per_ind);
                        command.Parameters.AddWithValue("@formula", formula);

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Material with ID " + material_id + " updated successfully.");
                            MessageBox.Show("Material with ID " + material_id + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("Material with ID " + material_id + " not found.");
                            MessageBox.Show("Material with ID " + material_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating material: " + e.ToString());
                MessageBox.Show("Error updating material: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Delete_Material(int material_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();


                    string query = @"DELETE FROM material where id ='" + material_id + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the delete
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Materials deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No materials found to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting materials: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Duplicate_Material(int id, string material_id)
        {
            List<Material> list_material = ListMaterial();
            foreach (var material in list_material)
            {
                if (material_id == material.material_id && id != material.id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
