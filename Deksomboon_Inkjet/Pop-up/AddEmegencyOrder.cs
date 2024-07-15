using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using Deksomboon_Inkjet.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet.Pop_up
{
    public partial class AddEmegencyOrder : Form
    {
        public AddEmegencyOrder(Order obj,string form , string emp_code ,string emp_pass , int sum_count , string emp_id , string ord_date_start , string amount)
        {
            InitializeComponent();

            string inkjet_name = LocalStorage.ReadInkjetData();
            string lcation_prefix = LocalStorage.ReadLocationPrefixData();
            List<Inkjet> record = Inkjet.ListInkjetLocationByInkjetName(inkjet_name);
            //Console.WriteLine(record[0].location_id.ToString());

                txtLine.Text = lcation_prefix;
                txtLineID.Text = record[0].location_id.ToString();
                txtInkjetID.Text = record[0].inkjet_id.ToString();

                txtEmpcode.Text = emp_code;
                txtEmppass.Text = emp_pass;

                txtCheckForm.Text = form;
                get_product();

                if (form == "1")
                {
                    cboMaterial.Enabled = true;
                    cboPosition.Enabled = true;
                txtAmount.Enabled = true;
                txtAmount.FillColor = Color.White;
                guna2HtmlLabel1.Text = "เพิ่มงานด่วน";
                cboOrdType.Text = "งานเร่งด่วน";
                txtEmpID.Text = emp_id.ToString();
                txtOrdID.Text = obj.ord_id.ToString();
                txtAmount.Text = "0";
                this.Text = "งานเร่งด่วน";

                }
                else if (form == "2")
                {
                 cboMaterial.Enabled = false;
                cboPosition.Enabled = false;
                //txtAmount.Enabled = false;
                //txtAmount.FillColor = Color.FromArgb(193, 200, 207);

                cboTypePrint.Text = obj.ord_type_print.ToString();
                txtEmpID.Text = emp_id.ToString();
                txtOrdID.Text = obj.ord_id.ToString();
                txtAmount.Text = amount.ToString();
                //MessageBox.Show(obj.ord_type.ToString());
                cboOrdType.Text = obj.ord_type.ToString();
                guna2HtmlLabel1.Text = "แก้ไข Order";
                cboMaterial.SelectedValue = obj.material_id;
                txtBatch.Text = obj.ord_batch;
                this.Text = "แก้ไข Order";
                //MessageBox.Show(obj.ord_date);
                DateTime dateInBuddhistEra = DateTime.ParseExact(obj.ord_date, "d/M/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                DateTime dateInChristianEra = dateInBuddhistEra.AddYears(-543); // แปลงเป็นคริสต์ศักราช

                Console.WriteLine("---------------------->>>" + dateInChristianEra);

                //DateTime myDate = DateTime.ParseExact(obj.ord_date.ToString(), "dd/MM/yyyy HH:mm:ss",
                //                       System.Globalization.CultureInfo.InvariantCulture);
                guna2DateTimePicker1.Value = dateInBuddhistEra;
                //Console.WriteLine("============================>>>>>"+obj.ord_date.ToString());
                }
                else
                {
                    cboMaterial.Enabled = false;
                    cboPosition.Enabled = false;

                txtOrdID.Text = obj.ord_id.ToString();
                cboOrdType.Text = obj.ord_type.ToString();
                guna2HtmlLabel1.Text = "เปลี่ยน batch";
                cboMaterial.SelectedValue = obj.material_id;
                txtBatch.Text = obj.ord_batch;
                txtSumCount.Text = sum_count.ToString();
                txtEmpID.Text = emp_id.ToString();
                txtOrderDate.Text = ord_date_start;

                DateTime dateInBuddhistEra = DateTime.ParseExact(obj.ord_date, "dd/M/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                DateTime dateInChristianEra = dateInBuddhistEra.AddYears(-543); // แปลงเป็นคริสต์ศักราช

                Console.WriteLine("---------------------->>>" + dateInChristianEra);

                DateTime myDate = DateTime.ParseExact(obj.ord_date.ToString(), "dd/MM/yyyy hh:mm",
                                     System.Globalization.CultureInfo.InvariantCulture);
                    guna2DateTimePicker1.Value = myDate;
                    guna2DateTimePicker1.Enabled = false;

                }
            
        }

        private void AddEmegencyOrder_Load(object sender, EventArgs e)
        {
            string inkjet_local = LocalStorage.ReadInkjetData();
            string location_local = LocalStorage.ReadLocationData();
            txtLineFull.Text = location_local;
            txtInkjet.Text = inkjet_local;

            //get_product();
            get_order_position();
            get_old_10_digit();
        }

        public void get_product()
        {
            List<Material> records = Material.ListMaterial();
            records.Insert(0, new Material() { material_id = "0", material_des = "เลือก" });
            cboMaterial.DataSource = records;
        }
        public void get_order_position()
        {
            string inkjet_local = LocalStorage.ReadInkjetData();
            string location_local = LocalStorage.ReadLocationData();
            List<Order> records = Order.ListAndUpdateOrderByInkjetLocation(location_local, inkjet_local);
            Console.WriteLine("----"+records.Count);
            if (records.Count == 0)
            {
                records.Insert(0, new Order() { ord_id = 0, ord_position = 1 });
                cboPosition.DataSource = records;
            }
            else
            {
                // Find the highest ord_position in the existing records
                int maxPosition = records.Max(o => o.ord_position);
                // Add a new order with ord_position set to maxPosition + 1
                records.Add(new Order() { ord_id = 0, ord_position = maxPosition + 1 });

                cboPosition.DataSource = records;
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

        private void cboMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //gen10number();
        }

        private void batchnumberbox_TextChanged(object sender, EventArgs e)
        {
            gen10number();
        }

        public void gen10number()
        {
            DateTime order_date_test = guna2DateTimePicker1.Value;
            string batch = txtBatch.Text;
            string formula = txtFormula.Text;
            string line = txtLine.Text;
            string slife = txtSLife.Text;

            Console.WriteLine(order_date_test);

            string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife);

            txtTenDigit.Text = tenDigit;
            txtBBF.Text = BBF;
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

            //string ord_date = guna2DateTimePicker1.Value.ToString();

            //DateTime st1 = guna2DateTimePicker1.Value.AddYears(-543);
            //string date = st1.AddSeconds(-st1.Second).ToString();
            string date = guna2DateTimePicker1.Value.AddYears(-543).ToString("dd/MM/yyyy hh:mm");
            //DateTime st1 = guna2DateTimePicker1.Value.AddYears(-543);
            //string date_emegen = st1.AddSeconds(-st1.Second).ToString();

            //DateTime dateInBuddhistEra = DateTime.ParseExact(guna2DateTimePicker1.Value.ToString(), "dd/M/yyyy H:mm:ss", CultureInfo.InvariantCulture);
            //DateTime dateInChristianEra = dateInBuddhistEra.AddYears(-543); // แปลงเป็นคริสต์ศักราช

            DateTime st1 = guna2DateTimePicker1.Value.AddYears(-543);
            string date_now = st1.AddSeconds(-st1.Second).ToString();
            Console.WriteLine("--->" + date_now);

            int ord_position;
            if (!int.TryParse(cboPosition.Text, out ord_position))
            {
                MessageBox.Show("กรุณาระบุลําดับออร์เดอร์ที่ต้องการแทรก");
                return;
            }

            if (material_selected == "0" ) 
            {
                MessageBox.Show("กรุณาเลือก Material");
            }
            else if(string.IsNullOrEmpty(batch))
            {
                MessageBox.Show("กรุณาใส่ batch");
            }
            else if (amount == "0" || amount == null)
            {
                MessageBox.Show("กรุณาใส่จํานวนผลิต");
            }
            else
            {
                if (form == "1") // emegency order
                {
                    Order.Add_OrderEmergency(material_selected, Int32.Parse(line), batch, Int32.Parse(inkjet), type, ord_position, 0, "0", date_now , amount , ord_type_print);
                    DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(txtEmpID.Text), DateTime.Now.AddYears(-543).AddSeconds(DateTime.Now.AddYears(-543).Second).ToString(), "เพิ่มงานด่วน", 1, txtTenDigit.Text);
                    DialogResult = DialogResult.OK;
                }
                else if(form == "2") // update order
                {
                    string emp_id = Authorized.authorized_level_2(txtEmpcode.Text, txtEmppass.Text);
                    if (!string.IsNullOrEmpty(emp_id))
                    {
                        Order.Update_Order(ord_id, line, inkjet, material_selected, batch, type, date_now , ord_type_print , amount);
                        DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(emp_id), DateTime.Now.AddYears(-543).AddSeconds(DateTime.Now.AddYears(-543).Second).ToString(), "แก้ไขวันที่/เปลี่ยนbatch", 2, txtTenDigit.Text);
                        DialogResult = DialogResult.OK;
                    }
                }
                else if (form == "3") // end batch
                {
                    DateTime st = DateTime.Now.AddYears(-543);
                    string start_date = st.AddSeconds(-st.Second).ToString();
                    //string end_date = DateTime.Now.AddYears(-543).ToString("dd/MM/yyyy hh:mm");
                    DialogResult confrim_startjet = MessageBox.Show("คุณแน่ใจที่จะจบ batch : "+ txtTenDigitOld.Text + " หรือไม่", "Comfrim End Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confrim_startjet == DialogResult.Yes)
                    {
                        Order.Update_Order(ord_id, line, inkjet, material_selected, batch, type, date , ord_type_print , amount);
                        //Order.Update_Order_Status(ord_id, batch, "จบ batch");
                        DataLog.Update_DateLog(Int32.Parse(ord_id), Int32.Parse(txtSumCount.Text), start_date, Int32.Parse(txtEmpID.Text), txtTenDigitOld.Text, txtOrderDate.Text);

                        //DataLog.Add_DatLog(Int32.Parse(ord_id), txtTenDigit.Text, 0, start_date, end_date, Int32.Parse(txtEmpID.Text));
                        DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(txtEmpID.Text), start_date, "จบ batch", 2, txtTenDigitOld.Text);

                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            gen10number();
        }

        public void get_old_10_digit()
        {
            DateTime order_date_test = guna2DateTimePicker1.Value;
            string batch = txtBatch.Text;
            string formula = txtFormula.Text;
            string line = txtLine.Text;
            string slife = txtSLife.Text;

            Console.WriteLine(order_date_test);

            string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
            string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife);

            txtTenDigitOld.Text = tenDigit;


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

        private void guna2DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            gen10number();
        }
    }
}
