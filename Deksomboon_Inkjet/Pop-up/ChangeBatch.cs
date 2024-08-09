using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using Deksomboon_Inkjet.UserControls;
using Guna.UI2.WinForms;

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class ChangeBatch : Form
    {
        public ChangeBatch(Order obj, string form, string emp_code, string emp_pass, int sum_count, string emp_id, string ord_date_start , string amount , string count_print)
        {
            InitializeComponent();


            string inkjet_name = LocalStorage.ReadInkjetData();
            string lcation_prefix = LocalStorage.ReadLocationPrefixData();
            List<Inkjet> record = Inkjet.ListInkjetLocationByInkjetName(inkjet_name);
            //Console.WriteLine(record[0].location_id.ToString());

            txtAmount.Text = amount;
            txtLine.Text = lcation_prefix;
            txtLineID.Text = record[0].location_id.ToString();
            txtInkjetID.Text = record[0].inkjet_id.ToString();

            txtEmpcode.Text = emp_code;
            txtEmppass.Text = emp_pass;
            txtCount.Text = count_print;
            txtCheckForm.Text = form;

            get_product();

            cboMaterial.Enabled = false;


            txtOrdID.Text = obj.ord_id.ToString();
            cboOrdType.Text = obj.ord_type.ToString();
            guna2HtmlLabel1.Text = "เปลี่ยน batch";
            cboMaterial.SelectedValue = obj.material_id;
            txtBatch.Text = obj.ord_batch;
            txtBatchOld.Text = obj.ord_batch;
            txtSumCount.Text = sum_count.ToString();
            txtEmpID.Text = emp_id.ToString();
            txtOrderDate.Text = ord_date_start;
            cboTypePrint.Text = obj.ord_type_print.ToString();

            txtCheckSwap.Checked = obj.ord_type_print_swap;
            txtCheckTime.Checked = obj.ord_type_print_time;

            //DateTime myDate = DateTime.ParseExact(obj.ord_date.ToString(), "dd/MM/yyyy hh:mm",
            //                     System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateInBuddhistEra = DateTime.ParseExact(obj.ord_date, "d/M/yyyy H:mm:ss", CultureInfo.InvariantCulture);
            guna2DateTimePicker1.Value = dateInBuddhistEra;
            guna2DateTimePicker1.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string line = txtLineID.Text;
            string batch = txtBatch.Text.Trim();
            string material_selected = cboMaterial.SelectedValue.ToString();
            string inkjet = txtInkjetID.Text;
            string type = cboOrdType.Text;
            string form = txtCheckForm.Text;
            string ord_id = txtOrdID.Text;
            string ord_type_print = cboTypePrint.Text;
            string amount = txtAmount.Text;
            string sum_count = txtSumCount.Text;    
            string count = txtCount.Text;

            bool check_swap = txtCheckSwap.Checked;
            bool check_time = txtCheckTime.Checked;

            DateTime st = DateTime.Now.AddYears(-543);
            string start_date = st.AddSeconds(-st.Second).ToString();
            //string date = guna2DateTimePicker1.Value.AddYears(-543).ToString("dd/MM/yyyy hh:mm");

            DateTime st1 = guna2DateTimePicker1.Value.AddYears(-543);
            string date = st1.AddSeconds(-st1.Second).ToString();
            if (string.IsNullOrEmpty(batch))
            {
                MessageBox.Show("กรุณาใส่ batch");
            }
            else
            {
                //string end_date = DateTime.Now.AddYears(-543).ToString("dd/MM/yyyy hh:mm");
                DialogResult confrim_startjet = MessageBox.Show("คุณแน่ใจที่จะจบ batch : " + txtBatchOld.Text + " หรือไม่", "Comfrim End Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confrim_startjet == DialogResult.Yes)
                {
                    string ord_status_print = "";
                    if (Int32.Parse(txtCount.Text) >= Int32.Parse(txtAmount.Text))
                    {
                        ord_status_print = "ผลิตครบแล้ว";
                    }
                    else
                    {
                        ord_status_print = "ยังผลิตไม่ครบ";
                    }

                    //int diffcount = Int32.Parse(txtCount.Text) + Int32.Parse(sum_count);
                    Order.Update_Order(ord_id, line, inkjet, material_selected, batch, type, date , ord_type_print , amount , check_swap , check_time);
                    Order.Update_Order_Status(ord_id, batch, "จบ batch", ord_status_print , Int32.Parse(txtCount.Text));
                    DataLog.Update_DateLog(Int32.Parse(ord_id), Int32.Parse(txtSumCount.Text), start_date, Int32.Parse(txtEmpID.Text), txtTenDigitOld.Text, txtOrderDate.Text);

                    //DataLog.Add_DatLog(Int32.Parse(ord_id), txtTenDigit.Text, 0, start_date, end_date, Int32.Parse(txtEmpID.Text));
                    DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(txtEmpID.Text), start_date, "จบ batch", 1, txtTenDigitOld.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void txtBatch_TextChanged(object sender, EventArgs e)
        {
            gen10number();
        }

        public void gen10number()
        {
            //DateTime order_date_test = guna2DateTimePicker1.Value;
            //string batch = txtBatch.Text;
            //string formula = txtFormula.Text;
            //string line = txtLine.Text;
            //string slife = txtSLife.Text;

            //bool column_ord_type_print_swap = false;
            //bool column_ord_type_print_time = false;

            //string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            //string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife , column_ord_type_print_swap , column_ord_type_print_time);

            //txtTenDigit.Text = tenDigit;
            //txtBBF.Text = BBF;

            string selected_type_print = cboTypePrint.Text;
            DateTime order_date_test = guna2DateTimePicker1.Value;
            string batch = txtBatch.Text;
            string formula = txtFormula.Text;
            string line = txtLine.Text;
            string slife = txtSLife.Text;
            bool check_swap = txtCheckSwap.Checked;
            bool check_time = txtCheckTime.Checked;
            var selected_material = cboMaterial.SelectedValue;


            string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife, check_swap, check_time);
            string MFG = GenerateBatchNumber.order_mfg_generate(order_date_test, slife, check_swap, check_time);
            string EXP = GenerateBatchNumber.order_exp_generate(order_date_test, slife, check_swap, check_time);

            txtTenDitgit_temp.Text = tenDigit;
            if (selected_type_print == "2 บรรทัด")
            {

                txtTenDigit.Text = tenDigit;
                txtBBF.Text = BBF;
                txtExp.Text = "";

            }
            else if (selected_type_print == "2 บรรทัด-สลับ")
            {

                txtTenDigit.Text = BBF;
                txtBBF.Text = tenDigit;
                txtExp.Text = "";

            }
            else if (selected_type_print == "3 บรรทัด")
            {
                txtTenDigit.Text = tenDigit;
                txtBBF.Text = MFG;
                txtExp.Text = EXP;
            }
            else
            {
                txtTenDigit.Text = MFG;
                txtBBF.Text = EXP;
                txtExp.Text = tenDigit;
            }
        }

        public void get_product()
        {
            List<Material> records = Material.ListMaterial();
            records.Insert(0, new Material() { material_id = "0", material_des = "เลือก" });
            cboMaterial.DataSource = records;
        }

        public void get_old_10_digit()
        {
            //DateTime order_date_test = guna2DateTimePicker1.Value;
            //string batch = txtBatch.Text;
            //string formula = txtFormula.Text;
            //string line = txtLine.Text;
            //string slife = txtSLife.Text;

            ////Console.WriteLine(order_date_test);
            //bool column_ord_type_print_swap = false;
            //bool column_ord_type_print_time = false;


            //string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            //string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife , column_ord_type_print_swap , column_ord_type_print_time);
            
            string selected_type_print = cboTypePrint.Text;
            DateTime order_date_test = guna2DateTimePicker1.Value;
            string batch = txtBatch.Text;
            string formula = txtFormula.Text;
            string line = txtLine.Text;
            string slife = txtSLife.Text;
            bool check_swap = txtCheckSwap.Checked;
            bool check_time = txtCheckTime.Checked;
            var selected_material = cboMaterial.SelectedValue;


            string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife, check_swap, check_time);
            string MFG = GenerateBatchNumber.order_mfg_generate(order_date_test, slife, check_swap, check_time);
            string EXP = GenerateBatchNumber.order_exp_generate(order_date_test, slife, check_swap, check_time);
            
            txtTenDigitOld.Text = tenDigit;

            if (selected_type_print == "2 บรรทัด")
            {

                txtTenDigit.Text = tenDigit;
                txtBBF.Text = BBF;
                txtExp.Text = "";

            }
            else if (selected_type_print == "2 บรรทัด-สลับ")
            {

                txtTenDigit.Text = BBF;
                txtBBF.Text = tenDigit;
                txtExp.Text = "";

            }
            else if (selected_type_print == "3 บรรทัด")
            {
                txtTenDigit.Text = tenDigit;
                txtBBF.Text = MFG;
                txtExp.Text = EXP;
            }
            else
            {
                txtTenDigit.Text = MFG;
                txtBBF.Text = EXP;
                txtExp.Text = tenDigit;
            }


        }

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var material_selected = cboMaterial.SelectedValue;
            List<Material> records = Material.ListMaterialByID(material_selected.ToString());
            if (records.Count > 0)
            {
                txtFormula.Text = records[0].formula;
                txtSLife.Text = records[0].slife.ToString();
            }
            else
            {
                txtFormula.Text = "";
                txtSLife.Text = "";
            }
            gen10number();
        }

        private void ChangeBatch_Load(object sender, EventArgs e)
        {

            get_old_10_digit();
        }

        private void txtBatch_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
