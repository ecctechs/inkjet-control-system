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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucOrderLog : UserControl
    {
        private Timer timer;
        public ucOrderLog()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void ucOrderLog_Load(object sender, EventArgs e)
        {
            get_employee();
            search_datalog();
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
            search_datalog();
        }

        public void get_employee()
        {
            List<Employee> records = Employee.ListEmployee();
            records.Insert(0, new Employee() { emp_id = 0, emp_name = "เลือก" });
            guna2ComboBox1.DataSource = records;
        }

        public void search_datalog()
        {
            DataGridOrderLog.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridOrderLog.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);

            string emp_id = guna2ComboBox1.SelectedValue.ToString();

            DateTime start_date = guna2DateTimePicker1.Value;
            TimeSpan ts = new TimeSpan(00, 00, 0);
            var date_start = start_date.Date + ts;
            string d_start = date_start.AddYears(-543).ToString();

            DateTime end_date = guna2DateTimePicker2.Value;
            TimeSpan ts2 = new TimeSpan(23, 59, 59);
            var date_end = end_date.Date + ts2;
            string d_end = date_end.AddYears(-543).ToString();


            List<DataLog> records = DataLog.Search_DataLog(emp_id, d_start, d_end);
            DataGridOrderLog.DataSource = records;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (DataGridOrderLog.DataSource != null && DataGridOrderLog.DataSource is List<DataLog> dataLogs)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                            {
                                csv.WriteHeader(typeof(DataLog));
                                foreach (DataLog s in dataLogs)
                                {
                                    csv.NextRecord();
                                    csv.WriteRecord(s);
                                }
                            }
                        }
                        MessageBox.Show(this, "Your data has been successfully export.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            search_datalog();
        }
    }
}
