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
using Npgsql;
using System.IO;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            get_material();
  
            DataGridEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridEmployee.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
        }

        public void get_material()
        {
            List<Material> records = Material.ListMaterial();
            materialBindingSource.DataSource = records;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditProduct frm = new AddEditProduct(new Material()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_material();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Material obj = materialBindingSource.Current as Material;
            if (obj != null)
            {
                using (AddEditProduct frm = new AddEditProduct(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        get_material();
                    }
                    else
                    {
                        get_material();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Material obj = materialBindingSource.Current as Material;

            DialogResult result = MessageBox.Show("คุณต้องการลบสินค้าหมายเลขวัสดุ " + obj.material_id + " หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Material.Delete_Material(obj.id);
                get_material();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var filePath = ChooseCsvFile();
            ImportCsv(filePath);
            get_material();
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

        public static void ImportCsv(string filePath)
        {
            try
            {
                // อ่านข้อมูลจากไฟล์ CSV
                List<string[]> data = File.ReadAllLines(filePath)
                                           .Select(line => line.Split(','))
                                           .ToList();
                string ip = LocalStorage.ReadIPaddress();
                // เชื่อมต่อฐานข้อมูล PostgreSQL
                string connectionString = "Host="+ ip + ";Username=postgres;Password=123456;Database=deksomboon_local";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // สร้างคำสั่ง SQL เพื่อเพิ่มข้อมูล
                    foreach (string[] row in data)
                    {
                        // ตรวจสอบความถูกต้องของข้อมูลก่อนแปลง
                        if (row.Length == 5 && int.TryParse(row[2], out int slife))
                        {
                            //string query = "INSERT INTO material (material_id, per_ind, slife, material_des, formula) " +
                            //               "VALUES (@material_id, @per_ind, @slife, @material_des, @formula)";

                            string query = @"INSERT INTO material (material_id, per_ind, slife, material_des, formula) 
                 VALUES (@material_id, @per_ind, @slife, @material_des, @formula) 
                 ON CONFLICT (material_id) DO UPDATE 
                 SET per_ind = EXCLUDED.per_ind, slife = EXCLUDED.slife, material_des = EXCLUDED.material_des, formula = EXCLUDED.formula";

                            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@material_id", row[0]);
                                command.Parameters.AddWithValue("@per_ind", row[1]);
                                command.Parameters.AddWithValue("@slife", slife);
                                command.Parameters.AddWithValue("@material_des", row[3]);
                                command.Parameters.AddWithValue("@formula", row[4]);

                                command.ExecuteNonQuery();
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

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
