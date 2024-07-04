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

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucInkjet : UserControl
    {
        private Timer timer;
        public ucInkjet()
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
            get_inkjet();
        }

        private void ucInkjet_Load(object sender, EventArgs e)
        {
            get_inkjet();
        }
        public void get_inkjet()
        {
            DataGridEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridEmployee.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
            List<Inkjet> records = Inkjet.ListInkjet();
            inkjetBindingSource.DataSource = records;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditInkjet frm = new AddEditInkjet(new Inkjet()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_inkjet();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Inkjet obj = inkjetBindingSource.Current as Inkjet;
            if (obj != null)
            {
                using (AddEditInkjet frm = new AddEditInkjet(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        get_inkjet();
                    }

                    else
                    {
                        get_inkjet();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Inkjet obj = inkjetBindingSource.Current as Inkjet;

            DialogResult result = MessageBox.Show("คุณต้องการลบอินเจ็ก " + obj.inkjet_name + "หรือ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Inkjet.Delete_Inkjet(obj.inkjet_id);
                get_inkjet();
            }
        }
    }
}
