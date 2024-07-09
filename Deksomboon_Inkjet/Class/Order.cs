using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Deksomboon_Inkjet.Class
{
    public class Order
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
        public string ord_date { get; set; }

        public string location_prefix { get; set; }

        public int ord_amount { get; set; }

        public int ord_count { get; set; }

        public static List<Order> ListOrder()
        {
            List<Order> listOrder = new List<Order>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM order_detail
                    LEFT JOIN location
                    ON order_detail.location_id = location.location_id
                    LEFT JOIN material 
                    ON order_detail.material_id = material.material_id
                    LEFT JOIN inkjet 
                    ON inkjet.inkjet_id = order_detail.inkjet_id
                    order by ord_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
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
                                ord_date = reader.GetString(reader.GetOrdinal("ord_date")),
                                location_prefix = reader.GetString(reader.GetOrdinal("location_prefix"))

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

        public static List<Order> Search_order(string line, string start_date, string end_date)
        {
            List<Order> listOrder = new List<Order>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query;

                    if (line != "0")
                    {
                        query = @"SELECT * FROM order_detail
                    LEFT JOIN location ON order_detail.location_id = location.location_id
                    LEFT JOIN material ON order_detail.material_id = material.material_id
                    LEFT JOIN inkjet ON inkjet.inkjet_id = order_detail.inkjet_id
                    Where order_detail.location_id = '" + line + "' " +
                       "order by ord_id;";
                    }
                    else
                    {
                        query = @"SELECT * FROM order_detail
                    LEFT JOIN location ON order_detail.location_id = location.location_id
                    LEFT JOIN material ON order_detail.material_id = material.material_id
                    LEFT JOIN inkjet ON inkjet.inkjet_id = order_detail.inkjet_id order by ord_id;";
                    }

                    //Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
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
                                ord_date = reader.GetString(reader.GetOrdinal("ord_date"))

                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };
                            var date_records = DateTime.Parse(order.ord_date);
                            var date_records_start = DateTime.Parse(start_date);
                            var date_records_end = DateTime.Parse(end_date);

                            if (date_records >= date_records_start && date_records <= date_records_end)
                            {
                                listOrder.Add(order);
                            }

                            //listOrder.Add(order);

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
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"INSERT INTO order_detail ( material_id, location_id, ord_batch, inkjet_id , ord_type , ord_status , ord_date) 
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
                        command.Parameters.AddWithValue("@ord_date", DateTime.Now.AddYears(-543).ToString("dd/MM/yyyy hh:mm"));

                        command.ExecuteNonQuery();

                        Console.WriteLine("Order added successfully.");
                        MessageBox.Show("Order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Order adding material: " + e.ToString());
                MessageBox.Show("Order adding material: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static void Add_OrderEmergency(string material_id, string line, int batch, string inkjet_id, string type , int ord_position)
        //{
        //    try
        //    {
        //        using (var dbManager = new DatabaseManager())
        //        {
        //            dbManager.OpenConnection();

        //            string query = @"INSERT INTO order_detail ( material_id, location_id, ord_batch, inkjet_id , ord_type , ord_status) 
        //                     VALUES ( @material_id, @location_id, @ord_batch, @inkjet_id , @ord_type , @ord_status)";

        //            //Console.WriteLine(query);
        //            using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
        //            {
        //                command.Parameters.AddWithValue("@material_id", material_id);
        //                command.Parameters.AddWithValue("@location_id", Int32.Parse(line));
        //                command.Parameters.AddWithValue("@ord_batch", batch);
        //                command.Parameters.AddWithValue("@inkjet_id", Int32.Parse(inkjet_id));
        //                command.Parameters.AddWithValue("@ord_type", type);
        //                command.Parameters.AddWithValue("@ord_status", "รับออร์เดอร์");

        //                command.ExecuteNonQuery();

        //                Console.WriteLine("Order added successfully.");
        //                MessageBox.Show("Order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Order adding material: " + e.ToString());
        //        MessageBox.Show("Order adding material: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public static void Add_OrderEmergency(string material_id, int line, string batch, int inkjet_id, string type, int ord_position, int emp_id, string tenDigit , string date)
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
                                            ord_position = reader.GetInt32(reader.GetOrdinal("ord_position")),
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

                            string query2 = @"INSERT INTO order_detail ( material_id, ord_batch, location_id, inkjet_id , ord_type , ord_status , ord_position ,ord_date) 
                             VALUES ( @material_id, @ord_batch, @location_id, @inkjet_id , @ord_type , @ord_status , @ord_position , @ord_date)";
                            //Console.WriteLine(query2);
                            //Console.WriteLine(line);
                            //Console.WriteLine(inkjet_id);

                            using (NpgsqlCommand insertCommand = new NpgsqlCommand(query2, dbManager.connection))
                            {
                                insertCommand.Parameters.AddWithValue("@material_id", material_id);
                                insertCommand.Parameters.AddWithValue("@ord_batch", batch);
                                insertCommand.Parameters.AddWithValue("@location_id", line);
                                insertCommand.Parameters.AddWithValue("@inkjet_id", inkjet_id);
                                insertCommand.Parameters.AddWithValue("@ord_type", type);
                                insertCommand.Parameters.AddWithValue("@ord_status", "รับออร์เดอร์");
                                insertCommand.Parameters.AddWithValue("@ord_position", ord_position);
                                insertCommand.Parameters.AddWithValue("@ord_date", date);

                                insertCommand.ExecuteNonQuery();

                            }
                            string selectLastInsertedIdQuery = "SELECT LASTVAL()";
                            using (NpgsqlCommand selectLastInsertedIdCommand = new NpgsqlCommand(selectLastInsertedIdQuery, dbManager.connection))
                            {
                                // อ่านค่า ord_id ที่เพิ่มล่าสุดขึ้นมา
                                int lastInsertedId = Convert.ToInt32(selectLastInsertedIdCommand.ExecuteScalar());
                                Console.WriteLine("The last inserted ord_id is: " + lastInsertedId);
                                // ทำสิ่งที่ต้องการกับ lastInsertedId ที่ได้รับ เช่น แสดงผล หรือใช้ในการประมวลผลต่อไป
                                //DataLog.Add_Authorized_Log(lastInsertedId, emp_id, DateTime.Now.ToString("dd/MM/yyyy hh:mm"), "เพิ่มงานด่วน", 1, tenDigit);
                            }

                            // Commit การทำ transaction
                            transaction.Commit();

                            Console.WriteLine("Emergency order added successfully.");
                            MessageBox.Show("Emergency order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void Update_Order_Date(List<Order> record)
        {
            try
            {
                DateTime st1 = DateTime.Now.AddYears(-543);
                string date_now = st1.AddSeconds(-st1.Second).ToString();

                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    foreach (Order order in record)
                    {
                        string query = @"UPDATE order_detail 
                                 SET location_id = @location_id, 
                                     material_id = @material_id, 
                                     inkjet_id = @inkjet_id, 
                                     ord_batch = @ord_batch,
                                     ord_date = @ord_date,
                                     ord_type = @ord_type 
                                 WHERE ord_id = @ord_id";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                        {
                            command.Parameters.AddWithValue("@location_id", order.location_id); // ตั้งค่าพารามิเตอร์ต่างๆ
                            command.Parameters.AddWithValue("@inkjet_id", order.inkjet_id);
                            command.Parameters.AddWithValue("@material_id", order.material_id);
                            command.Parameters.AddWithValue("@ord_batch", order.ord_batch);
                            command.Parameters.AddWithValue("@ord_type", order.ord_type);
                            command.Parameters.AddWithValue("@ord_date", date_now); // ตั้งค่า ord_date เป็นวันที่ปัจจุบัน
                            command.Parameters.AddWithValue("@ord_id", order.ord_id); // ตั้งค่า ord_id

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Order with ID " + order.ord_id + " updated successfully.");
                                // แสดงผลลัพธ์หรือแจ้งเตือนตามที่คุณต้องการ
                            }
                            else
                            {
                                Console.WriteLine("Order with ID " + order.ord_id + " not found.");
                                // แสดงผลลัพธ์หรือแจ้งเตือนตามที่คุณต้องการ
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating Order: " + e.ToString());
                // แสดงข้อผิดพลาดหรือแจ้งเตือนตามที่คุณต้องการ
            }
        }

        public static void Update_Order(string order_id, string line, string inkjet, string material, string batch, string type , string ord_date)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE order_detail 
                             SET location_id = @location_id, 
                             material_id = @material_id, 
                             inkjet_id = @inkjet_id, 
                             ord_batch = @ord_batch,
                             ord_date = @ord_date,
                             ord_type = @ord_type 
                             WHERE ord_id = " + Int32.Parse(order_id);
                    //Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@location_id", Int32.Parse(line));
                        command.Parameters.AddWithValue("@inkjet_id", Int32.Parse(inkjet));
                        command.Parameters.AddWithValue("@material_id", material);
                        command.Parameters.AddWithValue("@ord_batch", batch);
                        command.Parameters.AddWithValue("@ord_type", type);
                        command.Parameters.AddWithValue("@ord_date", ord_date);


                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order with ID " + order_id + " updated successfully.");
                            //MessageBox.Show("Order with ID " + order_id + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void Update_Order_Status(string order_id, string batch, string ord_status)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"UPDATE order_detail 
                             SET ord_status = @ord_status,
                             ord_batch = @ord_batch 
                             WHERE ord_id = " + Int32.Parse(order_id);
                    //Console.WriteLine(query);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        // ตั้งค่าค่าพารามิเตอร์
                        command.Parameters.AddWithValue("@order_id", Int32.Parse(order_id));
                        command.Parameters.AddWithValue("@ord_status", ord_status);
                        command.Parameters.AddWithValue("@ord_batch", batch);



                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order with ID " + order_id + " updated successfully.");
                            //MessageBox.Show("Order with ID " + order_id + " updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("Order with ID " + order_id + " not found.");
                            //MessageBox.Show("Order with ID " + order_id + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string query = @"DELETE FROM order_detail where ord_id ='" + Int32.Parse(order_id) + "'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the delete
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //        string query = @"SELECT * FROM order_detail
                    //LEFT JOIN location
                    //ON order_detail.location_id = location.location_id
                    //LEFT JOIN material 
                    //ON order_detail.material_id = material.material_id
                    //LEFT JOIN inkjet 
                    //ON inkjet.inkjet_id = order_detail.inkjet_id 
                    //WHERE location.location_name = @location AND inkjet.inkjet_name = @inkjet AND ord_status = 'รับออร์เดอร์' OR ord_status = 'กำลังผลิต' OR ord_status = 'หยุดผลิตชั่วคราว' OR ord_status = 'จบ batch'
                    //ORDER BY ord_position";

                    string query = $@"
    SELECT * FROM order_detail
    LEFT JOIN location ON order_detail.location_id = location.location_id
    LEFT JOIN material ON order_detail.material_id = material.material_id
    LEFT JOIN inkjet ON inkjet.inkjet_id = order_detail.inkjet_id
    WHERE location.location_name = '{location}' 
    AND inkjet.inkjet_name = '{inkjet}'
    AND (order_detail.ord_status = 'รับออร์เดอร์' 
         OR order_detail.ord_status = 'กำลังผลิต' 
         OR order_detail.ord_status = 'หยุดผลิตชั่วคราว' 
         OR order_detail.ord_status = 'จบ batch'
         OR order_detail.ord_status = 'ทดสอบพิมพ์')
    ORDER BY order_detail.ord_position";

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
                                    location_prefix = reader.GetString(reader.GetOrdinal("location_prefix")),
                                    ord_date = reader.GetString(reader.GetOrdinal("ord_date")),
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

        //public static List<Order> ListOrderByInkjetLocation(string location , string inkjet)
        //{
        //    List<Order> listOrder = new List<Order>();

        //    try
        //    {
        //        using (var dbManager = new DatabaseManager())
        //        {
        //            dbManager.OpenConnection();

        //            string query = @"SELECT * FROM order_detail
        //            LEFT JOIN location
        //            ON order_detail.location_id = location.location_id
        //            LEFT JOIN material 
        //            ON order_detail.material_id = material.material_id
        //            LEFT JOIN inkjet 
        //            ON inkjet.inkjet_id = order_detail.inkjet_id 
        //            Where location.location_name = '" + location + "' and inkjet.inkjet_name = '"+ inkjet + "' " +
        //            "order by ord_id";


        //            using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
        //            using (NpgsqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Order order = new Order
        //                    {
        //                        ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
        //                        material_id = reader.GetString(reader.GetOrdinal("material_id")),
        //                        material_des = reader.GetString(reader.GetOrdinal("material_des")),
        //                        formula = reader.GetString(reader.GetOrdinal("formula")),
        //                        slife = reader.GetInt32(reader.GetOrdinal("slife")),
        //                        location_id = reader.GetInt32(reader.GetOrdinal("location_id")),
        //                        location_name = reader.GetString(reader.GetOrdinal("location_name")),
        //                        ord_batch = reader.GetInt32(reader.GetOrdinal("ord_batch")),
        //                        inkjet_id = reader.GetInt32(reader.GetOrdinal("inkjet_id")),
        //                        inkjet_name = reader.GetString(reader.GetOrdinal("inkjet_name")),
        //                        ord_type = reader.GetString(reader.GetOrdinal("ord_type")),
        //                        ord_status = reader.GetString(reader.GetOrdinal("ord_status")),
        //                        ord_position = reader.GetInt32(reader.GetOrdinal("ord_position")),
        //                        // เพิ่ม properties อื่น ๆ ตามต้องการ
        //                    };

        //                    listOrder.Add(order);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }

        //    return listOrder;
        //}


        //public static void Update_Order_Position(List<Order> records)
        //{
        //    try
        //    {
        //        using (var dbManager = new DatabaseManager())
        //        {
        //            dbManager.OpenConnection();

        //            // เริ่มต้นการทำ transaction
        //            using (var transaction = dbManager.connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    var count = 1;
        //                    // Loop through each order and update its position
        //                    foreach (var order in records)
        //                    {
        //                        string query_update = "UPDATE order_detail SET ord_position = @ord_position WHERE ord_id = @ord_id";
        //                        using (var command = new NpgsqlCommand(query_update, dbManager.connection))
        //                        {
        //                            command.Parameters.AddWithValue("ord_position", count);
        //                            command.Parameters.AddWithValue("ord_id", order.ord_id);
        //                            command.ExecuteNonQuery();
        //                        }
        //                        count++;
        //                    }

        //                    // Commit การทำ transaction
        //                    transaction.Commit();
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    throw ex;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error updating Order: " + e.ToString());
        //        System.Windows.Forms.MessageBox.Show("Error updating Order: " + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //    }
        //}

        public static void Update_Order_Position(int ord_id , int ord_position)
        {
            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = "UPDATE order_detail SET ord_position = @ord_position WHERE ord_id = @ord_id";

                    using (var command = new NpgsqlCommand(query, dbManager.connection))
                    {
                        command.Parameters.AddWithValue("ord_position", ord_position);
                        command.Parameters.AddWithValue("ord_id", ord_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

   
    }
}
