using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class Order_temp
    {
        public int ord_id { get; set; }
        public string material_id { get; set; }
        public int location_id { get; set; }
        public string ord_batch { get; set; }
        public int per_ind { get; set; }
        public int slife { get; set; }
        public string material_des { get; set; }
        public string formula { get; set; }
        public string location_name { get; set; }
        public int inkjet_id { get; set; }
        public string inkjet_name { get; set; }
        public string ord_type { get; set; }
        public string ord_status { get; set; }
        public int ord_position { get; set; }

        public string ord_temp { get; set; }
        public string ord_date { get; set; }

        public int ord_amount { get; set; }

        public int ord_count { get; set; }

        public static List<Order_temp> ListOrder()
        {
            List<Order_temp> listOrder = new List<Order_temp>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM order_preview
                    LEFT JOIN location
                    ON order_preview.location_id = location.location_id
                    LEFT JOIN material 
                    ON order_preview.material_id = material.material_id
                    LEFT JOIN inkjet 
                    ON order_preview.inkjet_id = inkjet.inkjet_id
                    order by ord_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order_temp order = new Order_temp
                            {
                                ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                material_id = reader.GetString(reader.GetOrdinal("material_id")),
                                material_des = reader.GetString(reader.GetOrdinal("material_des")),
                                formula = reader.GetString(reader.GetOrdinal("formula")),
                                slife = reader.GetInt32(reader.GetOrdinal("slife")),
                                location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                ord_batch = reader.GetString(reader.GetOrdinal("ord_batch")),
                                inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                ord_type = reader.GetString(reader.GetOrdinal("ord_type")),
                                ord_status = reader.GetString(reader.GetOrdinal("ord_status")),

                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            listOrder.Add(order);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return listOrder;
        }

        public static void Add_Order(string material_id, string line, string batch, string inkjet_id, string type)
        {
            try
            {
                DateTime st = DateTime.Now.AddYears(-543);
                string date_now = st.AddSeconds(-st.Second).ToString();

                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO order_preview ( material_id, location_id, ord_batch, inkjet_id , ord_type , ord_status , ord_date) 
                             VALUES ( @material_id, @location_id, @ord_batch, @inkjet_id , @ord_type , @ord_status , @ord_date)";

                    //Console.WriteLine(query);
                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("@material_id", material_id);
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(line));
                        command.Parameters.AddWithValue("@ord_batch", batch);
                        command.Parameters.AddWithValue("@inkjet_id", Int32.Parse(inkjet_id));
                        command.Parameters.AddWithValue("@ord_type", type);
                        command.Parameters.AddWithValue("@ord_status", "รับออร์เดอร์");
                        command.Parameters.AddWithValue("@ord_date", date_now);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Order added successfully.");
                        MessageBox.Show("เพิ่มข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Order adding material: " + e.ToString());
                MessageBox.Show("Order adding material: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Add_OrderEmergency(string material_id, int line, string batch, int inkjet_id, string type, int ord_position)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    // เริ่ม transaction เพื่อทำการแทรก order เร่งด่วนตามตำแหน่งที่กำหนด
                    using (var transaction = dbManager.connection.BeginTransaction())
                    {
                        try
                        {
                            // ค้นหาว่ามี order ที่อยู่หลังตำแหน่งที่ต้องการแทรกหรือไม่
                            string query = @"SELECT ord_id, ord_position FROM order_detail WHERE ord_position >= @ord_position ORDER BY ord_position DESC";

                            List<Order> ordersToUpdate = new List<Order>();

                            using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                            {
                                command.Parameters.AddWithValue("@ord_position", ord_position);

                                using (NpgsqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Order order = new Order
                                        {
                                            ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                            ord_position = reader.GetInt32(reader.GetOrdinal("ord_position"))
                                        };

                                        ordersToUpdate.Add(order);
                                    }
                                }
                            }

                            // อัพเดตตำแหน่งของ order ที่ต้องการเลื่อนลงอย่างใหม่
                            foreach (var order in ordersToUpdate)
                            {
                                string updateQuery = "UPDATE order_detail SET ord_position = " + (order.ord_position + 1) + " WHERE ord_id = '" + order.ord_id + "' ";
                                Console.WriteLine(updateQuery);
                                using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, dbManager.connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@new_position", order.ord_position + 1);
                                    updateCommand.Parameters.AddWithValue("@ord_id", order.ord_id);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }

                            string query2 = @"INSERT INTO order_detail ( material_id, ord_batch, location_id, inkjet_id , ord_type , ord_status , ord_position) 
                             VALUES ( @material_id, @ord_batch, @location_id, @inkjet_id , @ord_type , @ord_status , @ord_position)";
                            Console.WriteLine(query2);
                            Console.WriteLine(line);
                            Console.WriteLine(inkjet_id);

                            using (NpgsqlCommand insertCommand = new NpgsqlCommand(query2, dbManager.connection))
                            {
                                insertCommand.Parameters.AddWithValue("@material_id", material_id);
                                insertCommand.Parameters.AddWithValue("@ord_batch", batch);
                                insertCommand.Parameters.AddWithValue("@location_id", line);
                                insertCommand.Parameters.AddWithValue("@inkjet_id", inkjet_id);
                                insertCommand.Parameters.AddWithValue("@ord_type", type);
                                insertCommand.Parameters.AddWithValue("@ord_status", "รับออร์เดอร์");
                                insertCommand.Parameters.AddWithValue("@ord_position", ord_position);

                                insertCommand.ExecuteNonQuery();
                            }


                            // Commit การทำ transaction
                            transaction.Commit();

                            Console.WriteLine("Emergency order added successfully.");
                            MessageBox.Show("เพิ่มออร์เดอร์เร่งด่วนเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding emergency order: " + e.ToString());
                MessageBox.Show("Error adding emergency order: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void Update_Order(string order_id, string line, string inkjet, string material, string batch, string type)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE order_preview 
                             SET location_id = @location_id, 
                             material_id = @material_id, 
                             inkjet_id = @inkjet_id, 
                             ord_batch = @ord_batch,
                             ord_type = @ord_type 
                             WHERE ord_id = " + Int32.Parse(order_id);
                    Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(line));
                        command.Parameters.AddWithValue("@inkjet_id", Int32.Parse(inkjet));
                        command.Parameters.AddWithValue("@material_id", material);
                        command.Parameters.AddWithValue("@ord_batch", batch);
                        command.Parameters.AddWithValue("@ord_type", type);


                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order with ID " + order_id + " updated successfully.");
                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("Order with ID " + order_id + " not found.");
                            MessageBox.Show("Order with ID " + order_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void Update_Order_Status(string order_id, string ord_status)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE order_detail 
                             SET ord_status = @ord_status           
                             WHERE ord_id = " + Int32.Parse(order_id);
                    Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@order_id", Int32.Parse(order_id));
                        command.Parameters.AddWithValue("@ord_status", ord_status);



                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order with ID " + order_id + " updated successfully.");
                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("Order with ID " + order_id + " not found.");
                            MessageBox.Show("Order with ID " + order_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void Delete_Order(string order_id)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"DELETE FROM order_preview where ord_id ='" + Int32.Parse(order_id) + "'";

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
                            MessageBox.Show("No Order found to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting Order: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static List<Order> ListAndUpdateOrderByInkjetLocation(string location, string inkjet)
        {
            List<Order> listOrder = new List<Order>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    // ดึงข้อมูล order จากฐานข้อมูล
                    string query = @"SELECT * FROM order_temp
            LEFT JOIN location
            ON order_detail.location_id = location.location_id
            LEFT JOIN material 
            ON order_detail.material_id = material.material_id
            LEFT JOIN inkjet 
            ON inkjet.inkjet_id = order_detail.inkjet_id 
            WHERE location.location_name = @location AND inkjet.inkjet_name = @inkjet AND ord_status = 'รับออร์เดอร์'
            ORDER BY ord_position";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("location", location);
                        command.Parameters.AddWithValue("inkjet", inkjet);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Order order = new Order
                                {
                                    ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                    material_id = reader.GetString(reader.GetOrdinal("material_id")),
                                    material_des = reader.GetString(reader.GetOrdinal("material_des")),
                                    formula = reader.GetString(reader.GetOrdinal("formula")),
                                    slife = reader.GetInt32(reader.GetOrdinal("slife")),
                                    location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                    location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                    ord_batch = reader.GetString(reader.GetOrdinal("ord_batch")),
                                    inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                    inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                    ord_type = reader.GetString(reader.GetOrdinal("ord_type")),
                                    ord_status = reader.GetString(reader.GetOrdinal("ord_status")),
                                    //ord_position = reader.GetInt32(reader.GetOrdinal("ord_position")),
                                };

                                listOrder.Add(order);
                            }
                        }
                    }

                    // อัพเดตตำแหน่ง order ในฐานข้อมูล
                    using (var transaction = dbManager.connection.BeginTransaction())
                    {
                        try
                        {
                            var count = 1;
                            foreach (var order in listOrder)
                            {
                                string query_update = "UPDATE order_detail SET ord_position = @ord_position WHERE ord_id = @ord_id";
                                using (var command = new NpgsqlCommand(query_update, dbManager.connection))
                                {
                                    command.Parameters.AddWithValue("ord_position", count);
                                    command.Parameters.AddWithValue("ord_id", order.ord_id);
                                    command.ExecuteNonQuery();
                                }
                                order.ord_position = count; // อัพเดตตำแหน่งในออบเจ็กต์ Order ด้วย
                                count++;
                            }

                            // Commit การทำ transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("Error updating Order: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listOrder;
        }



        public static List<Order> Update_Order_Position(List<Order> records)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    // เริ่มต้นการทำ transaction
                    using (var transaction = dbManager.connection.BeginTransaction())
                    {
                        try
                        {
                            var count = 1;
                            // Loop through each order and update its position
                            foreach (var order in records)
                            {
                                string query_update = "UPDATE order_detail SET ord_position = @ord_position WHERE ord_id = @ord_id";
                                using (var command = new NpgsqlCommand(query_update, dbManager.connection))
                                {
                                    command.Parameters.AddWithValue("ord_position", count);
                                    command.Parameters.AddWithValue("ord_id", order.ord_id);
                                    command.ExecuteNonQuery();
                                }
                                order.ord_position = count; // อัปเดตตำแหน่งในออบเจ็กต์ Order ด้วย
                                count++;
                            }

                            // Commit การทำ transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating Order: " + e.ToString());
                System.Windows.Forms.MessageBox.Show("Error updating Order: " + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return records; // คืนค่า List<Order> ที่ได้รับการอัปเดตตำแหน่งแล้ว
        }

        public static void submit_order()
        {
            List<Order_temp> listOrder = new List<Order_temp>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM order_preview
                              LEFT JOIN location
                              ON order_preview.location_id = location.location_id
                              LEFT JOIN material 
                              ON order_preview.material_id = material.material_id
                              LEFT JOIN inkjet 
                              ON order_preview.inkjet_id = inkjet.inkjet_id
                              ORDER BY ord_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order_temp order = new Order_temp
                            {
                                ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                material_id = reader.GetString(reader.GetOrdinal("material_id")),
                                material_des = reader.GetString(reader.GetOrdinal("material_des")),
                                formula = reader.GetString(reader.GetOrdinal("formula")),
                                slife = reader.GetInt32(reader.GetOrdinal("slife")),
                                location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
                                location_name = reader.GetString(reader.GetOrdinal("location_name")),
                                ord_batch = reader.GetString(reader.GetOrdinal("ord_batch")),
                                inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
                                inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
                                ord_type = reader.GetString(reader.GetOrdinal("ord_type")),
                                ord_status = reader.GetString(reader.GetOrdinal("ord_status")),
                                ord_date = reader.GetString(reader.GetOrdinal("ord_date"))

                            };

                            listOrder.Add(order);
                        }
                    }

                    // เพิ่มข้อมูลในตาราง order_detail จาก listOrder
                    foreach (Order_temp order in listOrder)
                    {
                        string insertQuery = @"INSERT INTO order_detail (material_id, location_id, ord_batch, inkjet_id, ord_type, ord_status , ord_date) 
                                       VALUES (@material_id, @location_id, @ord_batch, @inkjet_id, @ord_type, @ord_status, @ord_date)";

                        using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, dbManager.connection))
                        {
                            command.Parameters.AddWithValue("@material_id", order.material_id);
                            command.Parameters.AddWithValue("@location_id", order.location_id);
                            command.Parameters.AddWithValue("@ord_batch", order.ord_batch);
                            command.Parameters.AddWithValue("@inkjet_id", order.inkjet_id);
                            command.Parameters.AddWithValue("@ord_type", order.ord_type);
                            command.Parameters.AddWithValue("@ord_status", "รับออร์เดอร์");
                            command.Parameters.AddWithValue("@ord_date", order.ord_date);

                            command.ExecuteNonQuery();

                            Console.WriteLine("Order Submit successfully.");

                        }
                    }
                    MessageBox.Show("ส่งออร์เดอร์ไปหน้าไลน์ผลิตเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_temp_order();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void clear_temp_order()
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"DELETE FROM order_preview";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();



                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting Order: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
