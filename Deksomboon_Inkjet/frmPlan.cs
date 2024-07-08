using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;
using Deksomboon_Inkjet.Pop_up;
using Npgsql;
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deksomboon_Inkjet
{
    public partial class frmPlan : Form
    {
        private frmSetting frmSettingInstance;
        private frmConnection frmConnectionInstance;
        private SerialPortManager serialPortManager;
        private Timer timer;
        private DatabaseManager databaseManager;

        public static List<string> bytesCount_list = new List<string>();
        public static List<string> bytesStatus_list = new List<string>();
        public static List<string> bytesJETstart_list = new List<string>();
        public static List<string> bytesJETstop_list = new List<string>();
        public static List<string> bytesJETstartPrint_list = new List<string>();


        public frmPlan()
        {
            InitializeComponent();
            InitializeDatabaseManager();
            InitializeTimer();
            serialPortManager = SerialPortManager.Instance;
            serialPortManager.DataReceived += SerialPortManager_DataReceived;
        }

        private void InitializeDatabaseManager()
        {
            databaseManager = new DatabaseManager(); // ใช้ constructor ที่กำหนด connection string โดยตรงในคลาส
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
            //bool isConnected = await databaseManager.CheckDatabaseConnectionAsync();
            bool isConnected = await DatabaseManager.CheckDataBaseAsync();
            string[] jetStatus = await command_status();
            UpdateStatus(isConnected, jetStatus[0], jetStatus[1]);
        }

        private void UpdateStatus(bool isConnected,string jetStatus, string PrintStatus)
        {
            string message = isConnected == true ? "Database is available" : "Database is not available";
            // อัพเดท UI ด้วยข้อความสถานะและสีตัวอักษร
            txtDBStatus.Text = message;
            txtDBStatus.ForeColor = isConnected == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            indicationDB.BorderColor = isConnected == true ? Color.Green : Color.FromArgb(192, 0, 0);
            indicationDB.FillColor = isConnected == true ? Color.FromArgb(0, 192, 0) : Color.Red;

            if (isConnected)
            {
                Console.WriteLine("Database is available");
            }
            else
            {
                Console.WriteLine("Database Not available");
            }

            if (jetStatus == "Jet Running")
            {
                txtJetState.Text = "Jet State : " + jetStatus;
                indicationJet.BorderColor = Color.Green;
                indicationJet.FillColor = Color.FromArgb(0, 192, 0);
                txtJetState.ForeColor =  System.Drawing.Color.Green;
            }
            else if (jetStatus == "Jet StartUp")
            {
                txtJetState.Text = "Jet State : " + jetStatus;
                indicationJet.BorderColor = Color.Orange;
                indicationJet.FillColor = Color.OrangeRed;
                txtJetState.ForeColor = System.Drawing.Color.Orange;
            }
            else if (jetStatus == "Jet Shuttdown")
            {
                txtJetState.Text = "Jet State : " + jetStatus;
                indicationJet.BorderColor = Color.Orange;
                indicationJet.FillColor = Color.OrangeRed;
                txtJetState.ForeColor = System.Drawing.Color.Orange;
            }
            else if (jetStatus == "Jet Stopped")
            {
                txtJetState.Text = "Jet State : " + jetStatus;
                indicationJet.BorderColor = Color.FromArgb(192, 0, 0);
                indicationJet.FillColor = Color.Red;
                txtJetState.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtJetState.Text = "Jet State : " + jetStatus;
                indicationJet.BorderColor = Color.FromArgb(192, 0, 0);
                indicationJet.FillColor = Color.Red;
                txtJetState.ForeColor = System.Drawing.Color.Red;
            }

            if (PrintStatus == "Printing")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.Green;
                indicationPrintStates.FillColor = Color.FromArgb(0, 192, 0);
                txtPrintState.ForeColor = System.Drawing.Color.Green;
            }
            else if (PrintStatus == "Undefined")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            else if (PrintStatus == "Idle")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            else if (PrintStatus == "Generating Pixels")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            else if (PrintStatus == "Waiting")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.Green;
                indicationPrintStates.FillColor = Color.FromArgb(0, 192, 0);
                txtPrintState.ForeColor = System.Drawing.Color.Green;
            }
            else if (PrintStatus == "Last")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            else if (PrintStatus == "Printing/Generating Pixels")
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtPrintState.Text = "Print States : " + PrintStatus;
                indicationPrintStates.BorderColor = Color.FromArgb(192, 0, 0);
                indicationPrintStates.FillColor = Color.Red;
                txtPrintState.ForeColor = System.Drawing.Color.Red;
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
        }

        private void SerialPortManager_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                string dataIN = e.Data;
                byte[] dataBytes = Encoding.GetEncoding(28591).GetBytes(dataIN);
                int dataInLength = dataIN.Length;
                string stringbyte = ByteArrayToString(dataBytes);

                bytesCount_list.Add(stringbyte);
                bytesStatus_list.Add(stringbyte);
                bytesJETstart_list.Add(stringbyte);
                bytesJETstop_list.Add(stringbyte);
            })); 
        }
        private string ByteArrayToString(byte[] byteArray)
        {
            //return BitConverter.ToString(byteArray).Replace("-", " ");
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                hex.AppendFormat("{0:X2}", b);
                //Console.WriteLine(b);
            }
            return hex.ToString();
        }

        public void open_rs232_setting()
        {
            // ตรวจสอบว่าฟอร์มถูกสร้างแล้วหรือยัง
            if (frmSettingInstance == null || frmSettingInstance.IsDisposed)
            {
                frmSettingInstance = new frmSetting();
            }

            // แสดงฟอร์มการตั้งค่า
            if (frmSettingInstance.ShowDialog() == DialogResult.OK)
            {
                indicationRS232Status.BorderColor = Color.Green;
                indicationRS232Status.FillColor = Color.FromArgb(0, 192, 0);
                txtRS232S.ForeColor = System.Drawing.Color.Green;
                txtRS232S.Text = "RS-232 : Connect";
            }
            else
            {
                indicationRS232Status.BorderColor = Color.FromArgb(192, 0, 0);
                indicationRS232Status.FillColor = Color.Red;
                txtRS232S.ForeColor = System.Drawing.Color.Red;
                txtRS232S.Text = "RS-232 : Not Connect";
            }
        }

        public void open_line_setting()
        {
            DateTime st = DateTime.Now.AddYears(-543);
            string start_date = st.AddSeconds(-st.Second).ToString();
            string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);

            if (!string.IsNullOrEmpty(emp_id))
            {
                // ตรวจสอบว่าฟอร์มถูกสร้างแล้วหรือยัง
                if (frmConnectionInstance == null || frmConnectionInstance.IsDisposed)
                {
                    frmConnectionInstance = new frmConnection();
                    refreash_order();
                }

                // แสดงฟอร์มการตั้งค่า
                if (frmConnectionInstance.ShowDialog() == DialogResult.OK)
                {

                    string inkjet_local = LocalStorage.ReadInkjetData();
                    string location_local = LocalStorage.ReadLocationData();
                    txtLineSetting.Text = location_local;
                    txtInkjetSetting.Text = inkjet_local;
                    Console.WriteLine("----------------<<<"+txtOrdID.Text+ txtTenDigit.Text);
                    if (string.IsNullOrEmpty(txtOrdID.Text) || string.IsNullOrEmpty(txtTenDigit.Text))
                    {
                        DataLog.Add_Authorized_Log(0, Int32.Parse(emp_id), start_date, "เปลี่ยนไลน์ผลิต/เครื่องพิมพ์", 1, txtTenDigit.Text);
                    }
                    else
                    {
                        DataLog.Add_Authorized_Log(Int32.Parse(txtOrdID.Text), Int32.Parse(emp_id), start_date, "เปลี่ยนไลน์ผลิต/เครื่องพิมพ์", 1, txtTenDigit.Text);
                    }                   
                        refreash_order();
                }
            }
        }
        private void frmPlan_Shown(object sender, EventArgs e)
        {
            //open_rs232_setting();
            frmSettingInstance = new frmSetting();
            frmSettingInstance.rs232_connect();

            if (serialPortManager.IsOpen())
            {
                indicationRS232Status.BorderColor = Color.Green;
                indicationRS232Status.FillColor = Color.FromArgb(0, 192, 0);
                txtRS232S.ForeColor = System.Drawing.Color.Green;
                txtRS232S.Text = "RS-232 : Connect";
            }
            else
            {
                indicationRS232Status.BorderColor = Color.FromArgb(192, 0, 0);
                indicationRS232Status.FillColor = Color.Red;
                txtRS232S.ForeColor = System.Drawing.Color.Red;
                txtRS232S.Text = "RS-232 : Not Connect";
            }
        }
        private async void btnHome_Click(object sender, EventArgs e)
        {


            bool isConnected = await DatabaseManager.CheckDataBaseAsync();
            btnHome.Enabled = false;           
                if (isConnected == true)
                {
                    open_line_setting();
                }
                else
                {
                    MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnHome.Enabled = true;
                refreash_order();
            

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            open_rs232_setting();
        }

        private void frmPlan_Load_1(object sender, EventArgs e)
        {
            refreash_order();
        }

        public void refreash_order()
        {
            get_order();
            get_setting();
            get_order_detail_first_row();
            gen_10_number();
            clear_authroized();
        }
        public void clear_authroized()
        {
            txtEmployeeCode.Text = "";
            txtEmployeepass.Text = "";
        }

        public async void get_order()
        {
                string inkjet_local = LocalStorage.ReadInkjetData();
                string location_local = LocalStorage.ReadLocationData();
                List<Order> records = Order.ListAndUpdateOrderByInkjetLocation(location_local, inkjet_local);
                orderBindingSource.DataSource = records;           
        }

        public void get_setting()
        {
            string inkjet_local = LocalStorage.ReadInkjetData();
            string location_local = LocalStorage.ReadLocationData();
            txtLineSetting.Text = location_local;
            txtInkjetSetting.Text = inkjet_local;
        }

        public void gen_10_number()
        {
            if (OrderGrid.RowCount > 0)
            {
                string date_order = txtDate.Text;
                DateTime order_date_test = DateTime.Parse(date_order).AddYears(+543);
                //DateTime order_date = dateTimePicker1.Value;
                //Console.WriteLine(order_date.ToString());
                //Console.WriteLine(order_date_test.ToString());
                string batch = txtBatch.Text;
                string formula = txtFormula.Text;
                string line = locationprefixtextbox.Text;
                string slife = txtSLife.Text;

                string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date_test, batch, formula, line);
                string BBF = GenerateBatchNumber.order_bbf_generate(order_date_test, slife);

                txtTenDigit.Text = tenDigit;
                txtBBF.Text = "" + BBF;
                //row1order.Text = tenDigit;
                //row2order.Text = BBF;
            }
        }

        public void get_order_detail_first_row()
        {
            //Console.WriteLine(OrderGrid.RowCount);
            if (OrderGrid.RowCount > 0)
            {

                System.Drawing.Color customColor = System.Drawing.Color.FromArgb(231, 229, 255);
                OrderGrid.Rows[0].DefaultCellStyle.BackColor = customColor;
                OrderGrid.Rows[0].Selected = true;
                OrderGrid.Enabled = false;

                // รับข้อมูลจากแถวที่เลือก
                DataGridViewRow selectedRow = OrderGrid.SelectedRows[0];

                // ตรวจสอบว่ามีข้อมูลในแถวหรือไม่
                if (selectedRow != null)
                {
                    // รับค่าข้อมูลจากเซลล์แต่ละเซลล์ในแถวที่เลือก
                    string columnBatch = selectedRow.Cells["ordbatchDataGridViewTextBoxColumn"].Value.ToString();
                    string columnDate = selectedRow.Cells["ord_date"].Value.ToString();
                    string columnMaterial = selectedRow.Cells["materialdesDataGridViewTextBoxColumn"].Value.ToString();
                    string columnFormula = selectedRow.Cells["formulaDataGridViewTextBoxColumn"].Value.ToString();
                    string columnOrderStaus = selectedRow.Cells["ord_status"].Value.ToString();
                    string columnSlife = selectedRow.Cells["slifeDataGridViewTextBoxColumn"].Value.ToString();
                    string columnLocationPrefix = selectedRow.Cells["location_prefix"].Value.ToString();
                    string columnOrderID = selectedRow.Cells["ord_id"].Value.ToString();
                    //string columnLineID = selectedRow.Cells["location_id"].Value.ToString();
                    //string columnInkjetID = selectedRow.Cells["inkjet_id"].Value.ToString();

                    //// นำข้อมูลไปแสดงใน TextBox หรือคอนโทรลที่ต้องการ
                    txtBatch.Text = columnBatch;
                    txtDate.Text = columnDate;
                    txtMaterialDes.Text = columnMaterial;
                    txtFormula.Text = columnFormula;
                    txtOrderStatus.Text = columnOrderStaus;
                    txtSLife.Text = columnSlife;
                    locationprefixtextbox.Text = columnLocationPrefix;
                    txtOrdID.Text = columnOrderID;
                    //txtLineID.Text = columnLineID;
                    //txtInkjetID.Text = columnInkjetID;

                    //string tenDigit = GenerateBatchNumber.order_batch_number_generate(order_date, batch, formula, line);
                    //string BBF = GenerateBatchNumber.order_bbf_generate(order_date, slife);

                    //row1orderOLD.Text = tenDigit;

                }
            }
            else
            {
                txtBatch.Text = "";
                txtDate.Text = "";
                txtMaterialDes.Text = "";
                txtFormula.Text = "";
                txtOrderStatus.Text = "";
                txtSLife.Text = "";
                locationprefixtextbox.Text = "";
                txtOrdID.Text = "";

            }
            OrderGrid.ClearSelection();
        }




        public async Task<string[]> command_status()
        {
            string status = "not available";
            string status_printing = "not available";
            string inkjet_name = txtInkjetSetting.Text;
            byte[] commandBytes = { 0x1B, 0x02, 0x14, 0x1B, 0x03 }; // total count 0x6E
            //serialPortManager.SendCommand(commandBytes);

            await serialPortManager.SendCommandAsync(commandBytes);

            string[] array_bytes = bytesStatus_list.ToArray();

            //Console.WriteLine("Start");
            //foreach (var item in array_bytes)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("End");

            string byte_con_string = String.Join("", array_bytes);
            string recive_string = StringHelper.AddSpacesEveryTwoCharacters(byte_con_string);

            //Console.WriteLine("recive string  :" + recive_string);
            bool check_send_success = StringHelper.CheckIfSecondElementIs06(recive_string);

            if (check_send_success)
            {
                string count_byte = StringHelper.ExtractSubstringBetween(recive_string, "14", "1B");
                //Console.WriteLine("Sub String Status :" + count_byte);
                string status_code = StringHelper.GetFirstString(count_byte);
                string status_code_printing = StringHelper.GetSecondString(count_byte);
                //Console.WriteLine("---->" + status_code_printing);
                

                if (status_code == "00")
                {
                    status = "Jet Running";
                }
                else if (status_code == "01")
                {
                    status = "Jet StartUp";
                }
                else if (status_code == "02")
                {
                    status = "Jet Shuttdown";
                }
                else if (status_code == "03")
                {
                    status = "Jet Stopped";
                }
                else if(status_code == "04")
                {
                    status = "Fault";
                }
                else
                {
                    status = "not available";
                }


                if (status_code_printing == "00")
                {
                    status_printing = "Printing";
                }
                else if (status_code_printing == "01")
                {
                    status_printing = "Undefined";
                }
                else if (status_code_printing == "02")
                {
                    status_printing = "Idle";
                }
                else if (status_code_printing == "03")
                {
                    status_printing = "Generating Pixels";
                }
                else if (status_code_printing == "04")
                {
                    status_printing = "Waiting";
                }
                else if (status_code_printing == "05")
                {
                    status_printing = "Last";
                }
                else if(status_code_printing == "06")
                {
                    status_printing = "Printing/Generating Pixels";
                }else
                {
                    status_printing = "not available";
                }

                Console.WriteLine($"Status Jet is : {status}");
                Console.WriteLine($"Print Jet is : {status_printing}");
                Inkjet.Update_Inkjet_status(inkjet_name, status);
            }
            else
            {
                //MessageBox.Show("ส่ง command ล้มเหลม โปรดตรวจสอบการเชื่อมต่อ inkjet");
                Console.WriteLine("ส่ง command ล้มเหลม โปรดตรวจสอบการเชื่อมต่อ inkjet");
            }

            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();
            //return status;
            return new string[] { status, status_printing };
        }

        public async Task<bool> command_start_jet()
        {
            byte[] commandBytes = { 0x1B, 0x02, 0x0F, 0x1B, 0x03 }; // command start jet

            // ส่งคำสั่งและตรวจสอบสถานะ
            bool start_jet = await SendCommandAndCheckStatusAsync(commandBytes);

            string[] array_bytes = bytesJETstart_list.ToArray();

            //Console.WriteLine("Start");
            //foreach (var item in array_bytes)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("End");

            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();
            return start_jet;
        }

        public async Task<bool> command_stop_print()
        {
            byte[] commandBytes = { 0x1B, 0x02, 0x12, 0x1B, 0x03 }; // command start jet

            bool stop_print = await SendCommandAndCheckStatusAsync(commandBytes);

            string[] array_bytes = bytesJETstop_list.ToArray();

            //Console.WriteLine("Start");
            //foreach (var item in array_bytes)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("End");

            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();
            return stop_print;
        }

        public async Task<bool> command_start_print()
        {
            byte[] commandBytes = { 0x1B, 0x02, 0x11, 0x1B, 0x03 }; // command start jet

            bool start_print = await SendCommandAndCheckStatusAsync(commandBytes);

            string[] array_bytes = bytesJETstop_list.ToArray();

            //Console.WriteLine("Start");
            //foreach (var item in array_bytes)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("End");

            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();
            return start_print;
        }

        public async Task<int> command_count()
        {
            int count_command = 0;

            byte[] commandBytes_Count = { 0x1B, 0x02,0x8D, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x1B,
                0x03 }; // command request count

           
            await serialPortManager.SendCommandAsync(commandBytes_Count);

            string[] array_bytes = bytesCount_list.ToArray();

            //Console.WriteLine("Start");
            //foreach (var item in array_bytes)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("End");

            string byte_con_string = String.Join("", array_bytes);
            string recive_string = StringHelper.AddSpacesEveryTwoCharacters(byte_con_string);

            Console.WriteLine("recive string  :" + recive_string);
            bool check_send_success = StringHelper.CheckIfSecondElementIs06(recive_string);

            if (check_send_success)
            {
                string count_byte = StringHelper.ExtractSubstringBetween(recive_string, "8D", "1B");
                Console.WriteLine("Sub String Count :" + count_byte);

                string[] subArray = count_byte.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int sum = 0;
                for (int i = 0; i < subArray.Length; i++)
                {
                    sum += (Convert.ToInt32(subArray[i], 16) * Convert.ToInt32(Math.Pow(16, i * 2)));
                }
                // Print the sum
                Console.WriteLine($"Sum of the values: {sum}");
                count_command = sum;
            }
            else
            {
                MessageBox.Show("ส่ง command ล้มเหลม โปรดตรวจสอบการเชื่อมต่อ inkjet");
            }
            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();
            return count_command;
        }

        public async Task<bool> command_send_text()
        {
            bool send_text = false;
            string tenDigit = txtTenDigit.Text;
            string bbf = "BBF "+txtBBF.Text;

            byte[] messageBytes = Encoding.UTF8.GetBytes(tenDigit);
            byte[] messageBytes2 = Encoding.UTF8.GetBytes(bbf);

            // สร้างไบต์คำสั่งทั้งหมด
            List<byte> commandBytesList = new List<byte> { 0x1B, 0x02, 0x9E, 0x01 };
            commandBytesList.AddRange(Encoding.UTF8.GetBytes("SERIALNUMBER"));
            commandBytesList.Add(0x00);
            commandBytesList.AddRange(messageBytes);
            commandBytesList.Add(0x00);
            commandBytesList.Add(0x1B);
            commandBytesList.Add(0x03);

            List<byte> commandBytesList2 = new List<byte> { 0x1B, 0x02, 0x9E, 0x01 };
            commandBytesList2.AddRange(Encoding.UTF8.GetBytes("BBF"));
            commandBytesList2.Add(0x00);
            commandBytesList2.AddRange(messageBytes2);
            commandBytesList2.Add(0x00);
            commandBytesList2.Add(0x1B);
            commandBytesList2.Add(0x03);

            byte[] commandBytes = commandBytesList.ToArray();
            byte[] commandBytes2 = commandBytesList2.ToArray();

            // ส่งคำสั่งแรกและตรวจสอบสถานะ
            send_text = await SendCommandAndCheckStatusAsync(commandBytes);
            if (!send_text)
            {
                return false; // ส่งคำสั่งไม่สำเร็จ
            }

            // ล้างสถานะ
            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();

            // ส่งคำสั่งที่สองและตรวจสอบสถานะ
            send_text = await SendCommandAndCheckStatusAsync(commandBytes2);
            if (!send_text)
            {
                return false; // ส่งคำสั่งไม่สำเร็จ
            }

            // ล้างสถานะ
            bytesCount_list.Clear();
            bytesStatus_list.Clear();
            bytesJETstart_list.Clear();
            bytesJETstop_list.Clear();
            bytesJETstartPrint_list.Clear();

            return send_text; // ส่งคำสั่งสำเร็จ
        }

        private async Task<bool> SendCommandAndCheckStatusAsync(byte[] commandBytes)
        {
            try
            {
                await serialPortManager.SendCommandAsync(commandBytes);

                // ที่นี่คุณสามารถเพิ่มการตรวจสอบสถานะการส่งคำสั่งเพิ่มเติมได้
                // ตัวอย่างเช่น: ตรวจสอบว่าได้รับการตอบกลับที่คาดหวังจากอุปกรณ์

                return true; // ส่งคำสั่งสำเร็จ
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send error: " + ex.Message);
                return false; // ส่งคำสั่งไม่สำเร็จ
            }
        }

        //private async void StartButton_Click(object sender, EventArgs e)
        //{
        //    if (serialPortManager.IsOpen())
        //    {
        //        bool isConnected = await DatabaseManager.CheckDataBaseAsync();

        //        if (isConnected == true)
        //        {
        //            MessageBox.Show("Start");

        //            bool start_print = await command_start_print();
        //            if (start_print)
        //            {
        //                // ดีเลย์ 6 วินาที
        //                StartButton.Enabled = false;
        //                await Task.Delay(6000);

        //                string[] status = await command_status();
        //                txtJetState.Text = "Jet State : " + status[0];
        //                Console.WriteLine(status[0]);

        //                if (status[0] == "Jet Running")
        //                {
        //                    if (status[1] == "Waiting" || status[1] == "Printing")
        //                    {
        //                        string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);
        //                        //Console.WriteLine(emp_id);
        //                        if (!string.IsNullOrEmpty(emp_id))
        //                        {
        //                            int count_inkjet = await command_count();
        //                            txtCount.Text = count_inkjet.ToString();

        //                            DialogResult confrim_send_text = MessageBox.Show("คุณต้องการส่งข้อความไปที่ inkjet หรือไม่ ", "Comfirm Send Text", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                            if (confrim_send_text == DialogResult.Yes) 
        //                            {
        //                                bool check_send_text = await command_send_text();
        //                                if (check_send_text == true)
        //                                {
        //                                    MessageBox.Show("ส่งข้อความไปที่ inkjet เรียบร้อยแล้ว");
        //                                    Order.Update_Order_Status(txtOrdID.Text, txtBatch.Text, "กำลังผลิต");
        //                                    refreash_order();
        //                                }
        //                                else
        //                                {
        //                                    MessageBox.Show("ส่งข้อความล้มเหลม", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                            }
        //                                //bool check_send_text = await command_send_text();
        //                            //if (check_send_text == true)
        //                            //{
        //                            //    MessageBox.Show("ส่งข้อความไปที่ inkjet เรียบร้อยแล้ว");
        //                            //    int count_inkjet = await command_count();
        //                            //    txtCount.Text = count_inkjet.ToString();

        //                            //    Order.Update_Order_Status(txtOrdID.Text, txtBatch.Text, "กำลังผลิต");
        //                            //    clear_authroized();
        //                            //    refreash_order();
        //                            //}
        //                            //else
        //                            //{
        //                            //    MessageBox.Show("ส่งข้อความล้มเหลม", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            //}
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Printing State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                }
        //                else if (status[0] == "Jet Stopped")
        //                {
        //                    DialogResult confrim_startjet = MessageBox.Show("Jet State is " + status[0] + " คุณต้องการที่จะส่งคําสั่งไป Start Jet หรือไม่ ", "Start Jet หรือไม่", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (confrim_startjet == DialogResult.Yes)
        //                    {
        //                        bool jet_start = await command_start_jet();
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Jet State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("ส่งคำสั่ง start print ล้มเหลว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Serial Port is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    StartButton.Enabled = true;
        //}

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBatch.Text))
            {
                if (serialPortManager.IsOpen())
                {
                    bool isConnected = await DatabaseManager.CheckDataBaseAsync();

                    if (isConnected == true)
                    {
                        string[] status = await command_status();
                        txtJetState.Text = "Jet State : " + status[0];
                        Console.WriteLine(status[0]);

                        if (status[0] == "Jet Running")
                        {
                            //if (status[1] == "Waiting" || status[1] == "Printing")
                            //{
                            string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);

                            if (!string.IsNullOrEmpty(emp_id))
                            {
                                DialogResult confrim_start_print = MessageBox.Show("คุณต้องการเริ่มผลิต Formula : " + txtFormula.Text + " , batch : " + txtBatch.Text + " หรือไม่ ", "คุณต้องการเริ่มต้นการผลิตหรือไม่ ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (confrim_start_print == DialogResult.Yes)
                                {
                                    bool start_print = await command_start_print();
                                    StartButton.Enabled = false;

                                    if (start_print == true)
                                    {
                                        //MessageBox.Show("Start Jet สําเร็จ");
                                        int count_inkjet = await command_count();
                                        txtCount.Text = count_inkjet.ToString();

                                        StartButton.Visible = false;
                                        EmegencyButton.Visible = false;
                                        UpdateButton.Visible = false;

                                        StopButton.Visible = true;
                                        EndBatchButton.Visible = true;
                                        EndOrderButton.Visible = true;

                                        DateTime st = DateTime.Now.AddYears(-543);
                                        string start_date = st.AddSeconds(-st.Second).ToString();
                                        txtOrderDateStart.Text = start_date;

                                        Order.Update_Order_Status(txtOrdID.Text, txtBatch.Text, "กำลังผลิต");
                                        DataLog.Add_DatLog(Int32.Parse(txtOrdID.Text), txtTenDigit.Text, 0, start_date, "", Int32.Parse(emp_id));
                                        DataLog.Add_Authorized_Log(Int32.Parse(txtOrdID.Text), Int32.Parse(emp_id), start_date, "กำลังผลิต", 1, txtTenDigit.Text);
                                        refreash_order();

                                        //DialogResult confrim_send_text = MessageBox.Show("คุณต้องการส่งข้อความไปที่ inkjet หรือไม่ ", "Comfirm Send Text", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        //if (confrim_send_text == DialogResult.Yes)
                                        //{
                                        bool check_send_text = await command_send_text();

                                        if (check_send_text == true)
                                        {
                                            MessageBox.Show("ส่งข้อความไปที่เครื่องอินเจ็กเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            refreash_order();
                                        }
                                        else
                                        {
                                            MessageBox.Show("ส่งข้อความล้มเหลว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        //}
                                    }
                                    else
                                    {
                                        MessageBox.Show("Start Jet ไม่สําเร็จ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Printing State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                        else if (status[0] == "Jet Stopped")
                        {
                            DialogResult confrim_startjet = MessageBox.Show("อินเจ็กของคุณยังไม่เริ่มทํางาน คุณต้องการส่งคําสั่งไปเริ่มอินเจ็กหรือไม่ ?", "Comfrim Start Jet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (confrim_startjet == DialogResult.Yes)
                            {
                                bool jet_start = await command_start_jet();
                                if (jet_start == true)
                                {
                                    MessageBox.Show("กําลังเริ่มอินเจ็กกรุณารอสักครู่", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("ไม่สามารถส่งคําสั่ง start jet โปรดตรวจสอบอินเจ็กว่าพร้อมใช้งานหรือไม่", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                refreash_order();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Jet State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Serial Port is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ batch ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            StartButton.Enabled = true;
        }



        private async void StopButton_Click(object sender, EventArgs e)
        {
            string ord_id = txtOrdID.Text;
            string batch = txtBatch.Text;

            if (serialPortManager.IsOpen())
            {
                bool isConnected = await DatabaseManager.CheckDataBaseAsync();

                if (isConnected == true)
                {
                    string[] status = await command_status();
                    txtJetState.Text = "Jet State : " + status[0];
                    Console.WriteLine(status[0]);
                    if (status[0] == "Jet Running")
                    {
                        //if (status[1] == "Waiting" || status[1] == "Printing")
                        //{
                            string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);
                            if (!string.IsNullOrEmpty(emp_id))
                            {
                                DialogResult confrim_startjet = MessageBox.Show("คุณต้องการหยุดการผลิตหรือไม่ ", "Comfrim Stop Jet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (confrim_startjet == DialogResult.Yes)
                                {
                                    bool jet_stop = await command_stop_print();
                                    if (jet_stop == true)
                                    {
                                        MessageBox.Show("Stop Print สําเร็จ");

                                        int count_inkjet = await command_count();
                                        txtCountEnd.Text = count_inkjet.ToString();

                                        int sum_count = Int32.Parse(txtCountEnd.Text) - Int32.Parse(txtCount.Text);
                                        DateTime st = DateTime.Now.AddYears(-543);
                                        string end_date = st.AddSeconds(-st.Second).ToString();

                                        StartButton.Visible = true;
                                        EmegencyButton.Visible = true;
                                        UpdateButton.Visible = true;

                                        StopButton.Visible = false;
                                        EndBatchButton.Visible = false;
                                        EndOrderButton.Visible = false;

                                        Order.Update_Order_Status(ord_id, batch, "หยุดผลิตชั่วคราว");
                                        if (sum_count == 0)
                                        {
                                            DataLog.Delete_DataLog(Int32.Parse(ord_id), txtOrderDateStart.Text);
                                        }
                                        else
                                        {
                                            DataLog.Update_DateLog(Int32.Parse(ord_id), sum_count, end_date, Int32.Parse(emp_id), txtTenDigit.Text, txtOrderDateStart.Text);
                                        }
                                        DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(emp_id), end_date, "หยุดผลิตชั่วคราว", 1, txtTenDigit.Text);
                                        refreash_order();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Stop Print ไม่สําเร็จ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Jet State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Jet State is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial Port is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void EndBatchButton_Click(object sender, EventArgs e)
        {
            string ord_status = txtOrderStatus.Text;

            if (serialPortManager.IsOpen())
            {
                bool isConnected = await DatabaseManager.CheckDataBaseAsync();

                if (isConnected == true)
                {
                    if (ord_status.Trim() == "กำลังผลิต")
                    {
                        string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);
                        if (!string.IsNullOrEmpty(emp_id))
                        {
                            Order obj = orderBindingSource.Current as Order;
                            string form = "3";

                            int count_inkjet = await command_count();
                            txtCountEnd.Text = count_inkjet.ToString();

                            int sum_count = Int32.Parse(txtCountEnd.Text) - Int32.Parse(txtCount.Text);

                            using (ChangeBatch frm = new ChangeBatch(obj, form, txtEmployeeCode.Text, txtEmployeepass.Text, sum_count, emp_id, txtOrderDateStart.Text))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    MessageBox.Show("เปลี่ยน batch เรียบร้อยแล้ว");
                                    StartButton.Visible = true;
                                    EmegencyButton.Visible = true;
                                    UpdateButton.Visible = true;

                                    StopButton.Visible = false;
                                    EndBatchButton.Visible = false;
                                    EndOrderButton.Visible = false;
                                    await command_stop_print();
                                    refreash_order();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถจบ batch สถานะ " + ord_status, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial Port is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void EmegencyButton_Click(object sender, EventArgs e)
        {
            bool isConnected = await DatabaseManager.CheckDataBaseAsync();

            if (isConnected == true)
            {
                string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);

                if (!string.IsNullOrEmpty(emp_id))
                {

                    Order obj = orderBindingSource.Current as Order;
                    string form = "1";

                    using (AddEmegencyOrder frm = new AddEmegencyOrder(obj, form, txtEmployeeCode.Text, txtEmployeepass.Text, 0, emp_id, txtOrderDateStart.Text))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            refreash_order();
                        }
                        else
                        {
                            refreash_order();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            bool isConnected = await DatabaseManager.CheckDataBaseAsync();

            if (isConnected == true)
            {
                Order obj = orderBindingSource.Current as Order;
                if (obj != null)
                {
                    string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);
                    if (!string.IsNullOrEmpty(emp_id))
                    {
                        string form = "2";

                        using (AddEmegencyOrder frm = new AddEmegencyOrder(obj, form, txtEmployeeCode.Text, txtEmployeepass.Text, 0, emp_id, txtOrderDateStart.Text))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                refreash_order();
                            }
                            else
                            {
                                refreash_order();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void EndOrderButton_Click(object sender, EventArgs e)
        {
            string ord_id = txtOrdID.Text;
            string batch = txtBatch.Text;
            string ord_status = txtOrderStatus.Text;

            if (serialPortManager.IsOpen())
            {
                bool isConnected = await DatabaseManager.CheckDataBaseAsync();

                if (isConnected == true)
                {
                    if (ord_status == "จบ batch" || ord_status == "กำลังผลิต")
                    {
                        string emp_id = Authorized.authorized_level_1(txtEmployeeCode.Text, txtEmployeepass.Text);
                        if (!string.IsNullOrEmpty(emp_id))
                        {
                            DialogResult confrim = MessageBox.Show("คุณแน่ใจที่จบออร์เดอร์ ", "Comfrim Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (confrim == DialogResult.Yes)
                            {
                                StartButton.Visible = true;
                                EmegencyButton.Visible = true;
                                UpdateButton.Visible = true;

                                StopButton.Visible = false;
                                EndBatchButton.Visible = false;
                                EndOrderButton.Visible = false;

                                int count_inkjet = await command_count();
                                //string end_date = DateTime.Now.AddYears(-543).ToString("dd/MM/yyyy hh:mm");
                                DateTime st = DateTime.Now.AddYears(-543);
                                string end_date = st.AddSeconds(-st.Second).ToString();
                                txtCountEnd.Text = count_inkjet.ToString();

                                int sum_count = Int32.Parse(txtCountEnd.Text) - Int32.Parse(txtCount.Text);
                                
                                MessageBox.Show("จบออร์เดอร์สําเร็จ");
                                Order.Update_Order_Status(ord_id, batch, "จบออร์เดอร์");
                                DataLog.Update_DateLog(Int32.Parse(ord_id), sum_count, end_date, Int32.Parse(emp_id), txtTenDigit.Text, txtOrderDateStart.Text);
                                DataLog.Add_Authorized_Log(Int32.Parse(ord_id), Int32.Parse(emp_id), end_date, "จบออร์เดอร์", 1, txtTenDigit.Text);
                                refreash_order();
                                await command_stop_print();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถจบออร์เดอร์สถานะ "+ ord_status, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Database is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial Port is Disconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            string inkjet_name = txtInkjetSetting.Text;

            Inkjet.Update_Inkjet_status(inkjet_name, "Disconnect");
        }
    }
}
