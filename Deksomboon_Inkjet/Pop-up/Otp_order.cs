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
    public partial class Otp_order : Form
    {
        private string generatedOTP1; // กำหนดตัวแปรเก็บรหัส OTP ที่สร้างขึ้น

        public Otp_order()
        {
            InitializeComponent();
        }

        static string GenerateOTP()
        {
            // สร้างรหัส OTP สุ่ม
            Random random = new Random();
            int otpNumber = random.Next(100000, 999999); // OTP 6 หลัก
            return otpNumber.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string location_name = LocalStorage.ReadLocationData();
            List<location> records = location.ListLocationByID(location_name);
            Console.WriteLine(records[0].emp_email);

            if (records.Count > 0)
            {
                EmailService email = new EmailService();
                string otp = GenerateOTP(); // สร้าง OTP ใหม่
                generatedOTP1 = otp;
                Console.WriteLine(generatedOTP1);
                string name = records[0].emp_email;
                string subject = "Your One-Time Password (OTP)";
                string detail = "Your OTP is:" + otp;
                email.send(name, subject, detail);
            }
            else
            {
                MessageBox.Show("ไม่สามารถส่ง email ให้ manager ได้ เนื่องจาก ในไลน์ผลิต " + location_name + " ยังไม่มีพนักงาน ตําแหน่ง manager");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // สร้างอ็อบเจ็กต์ของคลาส OTPVerification
            OTPVerification otpVerification = new OTPVerification();

            string otp = GenerateOTP(); // สร้าง OTP ใหม่
            // รหัส OTP ที่ระบบสร้างขึ้นและส่งไปยังผู้ใช้
            string generatedOTP = generatedOTP1;

            bool isOTPVerified = otpVerification.VerifyOTP(txtOTP.Text, generatedOTP);

            // ตรวจสอบผลลัพธ์จากการตรวจสอบรหัส OTP
            if (isOTPVerified)
            {
                Console.WriteLine("OTP verification successful. Access granted.");
                MessageBox.Show("OTP ถูกส่งไปให้ Manager เรียบร้อยแล้ว", " OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                Console.WriteLine("OTP verification failed. Access denied.");
                MessageBox.Show("OTP ไม่ถูกต้อง กรุณากรอกใหม่", " OTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }

        public void get_detail_manager()
        {
            string location_name = LocalStorage.ReadLocationData();
            List<location> records = location.ListLocationByID(location_name);
            Console.WriteLine(records[0].emp_email);

            txtManagerName.Text = records[0].emp_name;
            txtManagerEmail.Text = records[0].emp_email;

        }

        private void Otp_order_Load(object sender, EventArgs e)
        {
            get_detail_manager();
        }
    }
}
