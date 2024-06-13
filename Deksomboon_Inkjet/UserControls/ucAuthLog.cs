using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Deksomboon_Inkjet.Class;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucAuthLog : UserControl
    {
        private Timer timer;
        public ucAuthLog()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 5000; // 5 วินาที
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();
        }
        private async void OnTimerTick(object sender, EventArgs e)
        {
            search_authlog();
        }

        private void ucAuthLog_Load(object sender, EventArgs e)
        {
            get_employee();
            search_authlog();
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
        public void get_employee()
        {
            List<Employee> records = Employee.ListEmployee();
            records.Insert(0, new Employee() { emp_id = 0, emp_name = "เลือก" });
            comboBox2.DataSource = records;
        }
        public void search_authlog()
        {
            DataGridAuth.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridAuth.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);

            string action = comboBox1.Text;
            string level = comboBox3.Text;
            string emp_id = comboBox2.SelectedValue.ToString();

            DateTime start_date = guna2DateTimePicker1.Value;
            TimeSpan ts = new TimeSpan(00, 00, 0);
            var date_start = start_date.Date + ts;
            string d_start = date_start.AddYears(-543).ToString();

            DateTime end_date = guna2DateTimePicker2.Value;
            TimeSpan ts2 = new TimeSpan(23, 59, 59);
            var date_end = end_date.Date + ts2;
            string d_end = date_end.AddYears(-543).ToString();


            List<DataLogAuth> records = DataLogAuth.Search_DataLogAuth(action, level, emp_id, d_start, d_end);
            DataGridAuth.DataSource = records;
        }

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    if (DataGridAuth.DataSource != null && DataGridAuth.DataSource is List<DataLogAuth> dataLogsAuth)
        //    {
        //        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
        //        {
        //            if (sfd.ShowDialog() == DialogResult.OK)
        //            {
        //                using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
        //                {
        //                    using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
        //                    {
        //                        csv.WriteHeader(typeof(DataLogAuth));
        //                        foreach (DataLogAuth s in dataLogsAuth)
        //                        {
        //                            csv.NextRecord();
        //                            csv.WriteRecord(s);
        //                        }
        //                    }
        //                }
        //                MessageBox.Show(this, "Your data has been successfully export.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "No data available for export.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (DataGridAuth.DataSource != null && DataGridAuth.DataSource is List<DataLogAuth> dataLogsAuth)
            {
                // Create a list of anonymous objects with selected columns
                var selectedDataLogsAuth = dataLogsAuth.Select(log => new
                {
                    ข้อความที่พิมพ์ = log.batch_number,
                    Action = log.action,
                    พนักงาน_Authorized = log.emp_name,
                    Level_Authorized = log.level_authorized,
                    วันที่_Authorized = log.date_authorized,
                }).ToList();

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                            {
                                csv.WriteRecords(selectedDataLogsAuth);
                            }
                        }
                        MessageBox.Show(this, "Your data has been successfully exported.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "No data available for export.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search_authlog();
        }
    }
}
