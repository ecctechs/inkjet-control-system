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
    public partial class ucLocation : UserControl
    {
        public ucLocation()
        {
            InitializeComponent();
        }
        private void ucLocation_Load(object sender, EventArgs e)
        {
            get_location();
        }
        public void get_location()
        {
            DataGridLocation.ColumnHeadersDefaultCellStyle.Font = new Font("Prompt", 12F, FontStyle.Regular);
            DataGridLocation.DefaultCellStyle.Font = new Font("Prompt", 10, FontStyle.Regular);
            List<location> records = location.ListLocation();
            locationBindingSource.DataSource = records;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditLocation frm = new AddEditLocation(new location()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    get_location();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            location obj = locationBindingSource.Current as location;
            if (obj != null)
            {
                using (AddEditLocation frm = new AddEditLocation(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        get_location();
                    }
                    else
                    {
                        get_location();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            location obj = locationBindingSource.Current as location;

            DialogResult result = MessageBox.Show("คุณต้องการลบไลน์ผลิต " + obj.location_name + " หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                location.Delete_Location(obj.location_id);
                get_location();
            }
        }
    }
}
