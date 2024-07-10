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

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class AddEditOrdercs : Form
    {
        public AddEditOrdercs(Order_temp obj)
        {
            InitializeComponent();
            get_location();
            get_product();

            if (obj.ord_id != 0)
            {
                string id = Convert.ToString(obj.ord_id);
                orderidtext.Text = id;
                comboBox1.Text = obj.location_name;
                comboBox2.Text = obj.inkjet_name;
                comboBox3.SelectedValue = obj.material_id;
                txtCountAmount.Text = obj.ord_count_amount.ToString();

                batchnumberbox.Text = obj.ord_batch;
                OrdTypecomboBox4.Text = obj.ord_type;
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
        }
        private void AddEditOrdercs_Load(object sender, EventArgs e)
        {
            //get_location();
            //get_product();
            OrdTypecomboBox4.SelectedIndex = 0;
        }

        public void get_location()
        {
            List<location> records = location.ListLocation();
            records.Insert(0, new location() { location_id = 0, location_name = "เลือก" });
            comboBox1.DataSource = records;
        }

        public void get_product()
        {
            List<Material> records = Material.ListMaterial();
            records.Insert(0, new Material() { material_id = "0", material_des = "เลือก" });
            comboBox3.DataSource = records;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var line_selected = comboBox1.SelectedValue;
            int lineId = Convert.ToInt32(line_selected);
            List<Inkjet> records = Inkjet.ListInkjetByID(lineId);
            records.Insert(0, new Inkjet() { inkjet_id = 0, inkjet_name = "เลือก" });
            comboBox2.DataSource = records;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var material_selected = comboBox3.SelectedValue;
            List<Material> records = Material.ListMaterialByID(material_selected.ToString());
            if (records.Count > 0)
            {
                formulatxtbox.Text = records[0].formula;
                slifetextbox.Text = records[0].slife.ToString();
            }
            else
            {
                formulatxtbox.Text = "";
                slifetextbox.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string line = comboBox1.SelectedValue.ToString();
            string inkjet = comboBox2.SelectedValue.ToString();
            string material = comboBox3.SelectedValue.ToString();
            string type = OrdTypecomboBox4.Text;
            string batch = batchnumberbox.Text;
            string Order_id = orderidtext.Text;
            int amount = Int32.Parse(txtCountAmount.Text);

            if (line == "0" ||
               inkjet == "0" ||
               material == "0" ||
               amount == 0 ||
               string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }

            if (Order_id == "0") // Add
            {
                Order_temp.Add_Order(material, line, batch, inkjet, type , amount);
                DialogResult = DialogResult.OK;
            }
            else // Update
            {
                Order_temp.Update_Order(Order_id, line, inkjet, material, batch, type , amount);
                DialogResult = DialogResult.OK;
            }
        }

        private void batchnumberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is not a control character (like Backspace)
            // and is not a letter or digit
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // If it's not, then handle the event by setting e.Handled to true
                e.Handled = true;
            }
            else if (e.KeyChar >= '\u0E00' && e.KeyChar <= '\u0E7F')
            {
                // If the character is in the Thai Unicode block, handle the event
                e.Handled = true;
            }
        }

        private void slifetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
