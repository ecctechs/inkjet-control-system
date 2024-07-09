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
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class UploadOrder : Form
    {
        public UploadOrder()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int location_id = (int)comboBox1.SelectedValue;
            int inkjet_id = (int)comboBox2.SelectedValue;
            string type = OrdTypecomboBox4.Text;

            if (location_id > 0 && inkjet_id > 0)
            {
                var filePath = ChooseCsvFile();
                ImportCsv(filePath, location_id, inkjet_id, type);
                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("กรุณาเลือก ไลน์ผลิตและอินเจ็ก ที่ต้องการอัพโหลด");
            }
        }
        public static string ChooseCsvFile()
        {
            // สร้าง OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.Title = "Choose a CSV File";

            // เปิดหน้าต่างเลือกไฟล์
            DialogResult result = openFileDialog.ShowDialog();

            // ตรวจสอบว่าผู้ใช้เลือกไฟล์หรือไม่
            if (result == DialogResult.OK)
            {
                // คืนเส้นทางไฟล์ที่ผู้ใช้เลือก
                return openFileDialog.FileName;
            }
            else
            {
                return null; // ถ้าผู้ใช้ยกเลิกการเลือกไฟล์
            }
        }

        //public static void ImportCsv(string filePath, int location_id, int inkjet_id, string type)
        //{
        //    try
        //    {
        //        DateTime st = DateTime.Now.AddYears(-543);
        //        string date_now = st.AddSeconds(-st.Second).ToString();

        //        // อ่านข้อมูลจากไฟล์ CSV
        //        List<string[]> data = File.ReadAllLines(filePath)
        //                                   .Select(line => line.Split(','))
        //                                   .ToList();
        //        string ip = LocalStorage.ReadIPaddress();
        //        // เชื่อมต่อฐานข้อมูล PostgreSQL
        //        string connectionString = "Host="+ ip + ";Username=postgres;Password=123456;Database=deksomboon_local";
        //        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // สร้างคำสั่ง SQL เพื่อเพิ่มข้อมูล
        //            foreach (string[] row in data)
        //            {
        //                // ตรวจสอบความถูกต้องของข้อมูลก่อนแปลง
        //                if (row.Length == 2 && int.TryParse(row[1], out int ord_batch))
        //                {
        //                    // เพิ่มการตรวจสอบว่า material_id มีอยู่ในตาราง material หรือไม่
        //                    string checkMaterialQuery = "SELECT COUNT(*) FROM material WHERE material_id = @material_id";
        //                    using (NpgsqlCommand checkMaterialCommand = new NpgsqlCommand(checkMaterialQuery, connection))
        //                    {
        //                        checkMaterialCommand.Parameters.AddWithValue("@material_id", row[0]);
        //                        int materialCount = Convert.ToInt32(checkMaterialCommand.ExecuteScalar());

        //                        if (materialCount > 0)
        //                        {
        //                            string query = @"INSERT INTO order_preview (material_id, location_id, ord_batch, inkjet_id , ord_type , ord_status , ord_date) 
        //                                     VALUES (@material_id, @location_id, @ord_batch, @inkjet_id , @ord_type , @ord_status , @ord_date) 
        //                                     ON CONFLICT (ord_id) DO UPDATE
        //                                     SET material_id = EXCLUDED.material_id, 
        //                                         location_id = EXCLUDED.location_id, 
        //                                         ord_batch = EXCLUDED.ord_batch, 
        //                                         inkjet_id = EXCLUDED.inkjet_id";

        //                            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        //                            {
        //                                command.Parameters.AddWithValue("@material_id", row[0]);
        //                                command.Parameters.AddWithValue("@location_id", location_id);
        //                                command.Parameters.AddWithValue("@ord_batch", ord_batch);
        //                                command.Parameters.AddWithValue("@inkjet_id", inkjet_id);
        //                                command.Parameters.AddWithValue("@ord_type", type);
        //                                command.Parameters.AddWithValue("@ord_status", "ยังไม่เสร็จ");
        //                                command.Parameters.AddWithValue("@ord_date", date_now);

        //                                command.ExecuteNonQuery();
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Material not found for material_id: " + row[0]);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid data format: " + string.Join(",", row));
        //                }
        //            }

        //            Console.WriteLine("Data imported successfully.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error importing data: " + e.Message);
        //    }
        //}

        public static void ImportCsv(string filePath, int location_id, int inkjet_id, string type)
        {
            try
            {
                DateTime st = DateTime.Now.AddYears(-543);
                string date_now = st.AddSeconds(-st.Second).ToString();

                // อ่านข้อมูลจากไฟล์ CSV
                List<string[]> data = File.ReadAllLines(filePath)
                                           .Select(line => line.Split(','))
                                           .ToList();
                string ip = LocalStorage.ReadIPaddress();
                // เชื่อมต่อฐานข้อมูล PostgreSQL
                string connectionString = "Host=" + ip + ";Username=postgres;Password=123456;Database=deksomboon_local";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // สร้างคำสั่ง SQL เพื่อเพิ่มข้อมูล
                    foreach (string[] row in data)
                    {
                        // ตรวจสอบความถูกต้องของข้อมูลก่อนแปลง
                        if (row.Length >= 2)
                        {
                            string material_id = row[0].Trim();
                            string ord_batch = row[1].Trim();

                            // ตรวจสอบความถูกต้องของ ord_batch
                            if (ord_batch.Length <= 1 )
                            {
                                // เพิ่มการตรวจสอบว่า material_id มีอยู่ในตาราง material หรือไม่
                                string checkMaterialQuery = "SELECT COUNT(*) FROM material WHERE material_id = @material_id";
                                using (NpgsqlCommand checkMaterialCommand = new NpgsqlCommand(checkMaterialQuery, connection))
                                {
                                    checkMaterialCommand.Parameters.AddWithValue("@material_id", material_id);
                                    int materialCount = Convert.ToInt32(checkMaterialCommand.ExecuteScalar());

                                    if (materialCount > 0)
                                    {
                                        string query = @"INSERT INTO order_preview (material_id, location_id, ord_batch, inkjet_id , ord_type , ord_status , ord_date) 
                                         VALUES (@material_id, @location_id, @ord_batch, @inkjet_id , @ord_type , @ord_status , @ord_date) 
                                         ON CONFLICT (ord_id) DO UPDATE
                                         SET material_id = EXCLUDED.material_id, 
                                             location_id = EXCLUDED.location_id, 
                                             ord_batch = EXCLUDED.ord_batch, 
                                             inkjet_id = EXCLUDED.inkjet_id";

                                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                        {
                                            command.Parameters.AddWithValue("@material_id", material_id);
                                            command.Parameters.AddWithValue("@location_id", location_id);
                                            command.Parameters.AddWithValue("@ord_batch", ord_batch);
                                            command.Parameters.AddWithValue("@inkjet_id", inkjet_id);
                                            command.Parameters.AddWithValue("@ord_type", type);
                                            command.Parameters.AddWithValue("@ord_status", "ยังไม่เสร็จ");
                                            command.Parameters.AddWithValue("@ord_date", date_now);

                                            command.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Material not found for material_id: " + material_id);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid ord_batch format: " + ord_batch );
                                Console.WriteLine("Invalid ord_batch format: " + ord_batch);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format: " + string.Join(",", row));
                        }
                    }

                    Console.WriteLine("Data imported successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error importing data: " + e.Message);
            }
        }


        private void UploadOrder_Load(object sender, EventArgs e)
        {
            get_location();
            OrdTypecomboBox4.SelectedIndex = 0;
        }

        public void get_location()
        {
            List<location> records = location.ListLocation();
            records.Insert(0, new location() { location_id = 0, location_name = "เลือก" });
            comboBox1.DataSource = records;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var line_selected = comboBox1.SelectedValue;
            int lineId = Convert.ToInt32(line_selected);
            List<Inkjet> records = Inkjet.ListInkjetByID(lineId);
            records.Insert(0, new Inkjet() { inkjet_id = 0, inkjet_name = "เลือก" });
            comboBox2.DataSource = records;
        }
    }
}
