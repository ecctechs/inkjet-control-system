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
    public partial class AddEditProduct : Form
    {
        public AddEditProduct(Material obj)
        {
            InitializeComponent()
                ;
            if (obj.id != 0)
            {
                string id = Convert.ToString(obj.id);
                txtMaterialDes.Text = obj.material_des;
                txtID.Text = id;
                txtFormula.Text = obj.formula;
                txtSLife.Text = obj.slife.ToString();
                txtMaterialID.Text = obj.material_id;
                txtPerind.Text = obj.per_ind;
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var material_id = txtMaterialID.Text;
            var material_descrition = txtMaterialDes.Text;
            var slife = txtSLife.Text;
            var per_ind = txtPerind.Text;
            var formula = txtFormula.Text;
            var id = txtID.Text;

            // ตรวจสอบว่ามีช่องไหนที่ว่างเปล่าหรือไม่
            if (string.IsNullOrWhiteSpace(material_id) ||
                string.IsNullOrWhiteSpace(material_descrition) ||
                string.IsNullOrWhiteSpace(slife) ||
                string.IsNullOrWhiteSpace(per_ind) ||
                string.IsNullOrWhiteSpace(formula) )
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }

            if (formula.Length < 3)
            {
                MessageBox.Show("Formula ควรมี 3 ตัวอักษร");
                return;
            }

            var chk_duplicate = Material.Duplicate_Material(Int32.Parse(id), material_id);

            if (chk_duplicate == false)
            {
                MessageBox.Show("Material ID: " + material_id + " มีอยู่ในระบบแล้ว");
                return;
            }

            if (id == "0") // Add
            {
                Material.Add_Material(material_id, material_descrition, slife, per_ind, formula);
                DialogResult = DialogResult.OK;
            }
            else // Update
            {
                Material.Update_Material(material_id, material_descrition, slife, per_ind, formula);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
