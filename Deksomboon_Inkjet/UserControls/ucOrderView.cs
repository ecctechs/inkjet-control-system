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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucOrderView : UserControl
    {
        private Timer timer;
        public ucOrderView()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void ucOrderView_Load(object sender, EventArgs e)
        {
            get_location();
            get_order_view();
        }

        public void get_location()
        {
            List<location> records = location.ListLocation();
            records.Insert(0, new location() { location_id = 0, location_name = "เลือก" });
            locationBindingSource.DataSource = records;
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
            get_order_view();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            get_order_view();
        }

        public void get_order_view()
        {
            DataGridOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridOrder.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
            string line = cboLine.SelectedValue.ToString();

            DateTime start_date = guna2DateTimePicker1.Value;
            TimeSpan ts = new TimeSpan(00, 00, 0);
            var date_start = start_date.Date + ts;
            string d_start = date_start.AddYears(-543).ToString();

            DateTime end_date = guna2DateTimePicker2.Value;
            TimeSpan ts2 = new TimeSpan(23, 59, 59);
            var date_end = end_date.Date + ts2;
            string d_end = date_end.AddYears(-543).ToString();

            List<Order> records = Order.Search_order(line, d_start, d_end);
            orderBindingSource.DataSource = records;
        }
    }
}
