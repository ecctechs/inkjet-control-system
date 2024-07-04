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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet.UserControls
{
    public partial class ucOrder : UserControl
    {
        public ucOrder()
        {
            InitializeComponent();
        }
        private void ucOrder_Load(object sender, EventArgs e)
        {
            Order_temp.clear_temp_order();
            get_order();
        }

        public void get_order()
        {
            DataGridOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridOrder.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
            List<Order_temp> records = Order_temp.ListOrder();
            ordertempBindingSource.DataSource = records;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditOrdercs frm = new AddEditOrdercs(new Order_temp()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_order();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Order_temp obj = ordertempBindingSource.Current as Order_temp;
            if (obj != null)
            {
                using (AddEditOrdercs frm = new AddEditOrdercs(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        get_order();
                    }
                    else
                    {
                        get_order();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order_temp obj = ordertempBindingSource.Current as Order_temp;

            DialogResult result = MessageBox.Show("คุณต้องการลบออร์เดอร์หมายเลข " + obj.ord_id + " หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Order_temp.Delete_Order(obj.ord_id.ToString());
                get_order();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (UploadOrder frm = new UploadOrder())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_order();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Order_temp obj = ordertempBindingSource.Current as Order_temp;
            if (DataGridOrder.Rows.Count > 0)
            {
                Order_temp.submit_order();
                get_order();
            }
            else
            {
                MessageBox.Show("ไม่มีข้อมูลที่จะส่งไปหน้าไลน์ผลิต กรุณาเพิ่มข้อมูลก่อนกดส่ง");
            }
        }
    }
}
