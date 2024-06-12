using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deksomboon_Inkjet.Class
{
    public class OTPVerification
    {
        // ฟังก์ชันสำหรับตรวจสอบรหัส OTP
        public bool VerifyOTP(string userInputOTP, string generatedOTP)
        {
            // เปรียบเทียบรหัส OTP ที่ผู้ใช้กรอกกับรหัส OTP ที่ระบบสร้างขึ้นและส่งไปยังผู้ใช้
            return userInputOTP.Equals(generatedOTP);
        }
    }
}
