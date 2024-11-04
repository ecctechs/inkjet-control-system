using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class StringHelper
    {
        public static string AddSpacesEveryTwoCharacters(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i += 2)
            {
                if (i > 0)
                {
                    result.Append(' ');
                }
                if (i + 2 <= input.Length)
                {
                    result.Append(input.Substring(i, 2));
                }
                else
                {
                    result.Append(input.Substring(i));
                }
            }
            return result.ToString();
        }

        public static string ExtractSubstringBetween(string input, string start, string end)
        {
            int startIndex = input.IndexOf(start);
            int endIndex = input.IndexOf(end, startIndex + start.Length);

            if (startIndex == -1 || endIndex == -1 || endIndex <= startIndex)
            {
                return string.Empty; // คืนค่าว่างถ้าไม่พบหรืออยู่ในรูปแบบที่ไม่ถูกต้อง
            }

            // คำนวณความยาวของสตริงที่ต้องการดึง
            int length = endIndex - (startIndex + start.Length);

            // ดึงสตริงระหว่าง start และ end
            string result = input.Substring(startIndex + start.Length, length).Trim();
            return result;
        }

        public static bool CheckIfSecondElementIs06(string input)
        {
            // แยกสตริงโดยใช้ช่องว่างเป็นตัวแบ่ง
            string[] parts = input.Split(' ');

            // ตรวจสอบว่ามีอย่างน้อย 2 องค์ประกอบในอาร์เรย์
            if (parts.Length >= 2)
            {
                // ตรวจสอบว่าองค์ประกอบที่ 2 คือ "06" หรือไม่
                return parts[1] == "06";
            }

            // ถ้าอาร์เรย์มีน้อยกว่า 2 องค์ประกอบ ให้คืนค่าเป็น false
            return false;
        }
        public static string GetFirstString(string input)
        {
            // แยกสตริงโดยใช้ช่องว่างเป็นตัวแบ่ง
            string[] parts = input.Split(' ');

            // ตรวจสอบว่ามีอย่างน้อย 1 องค์ประกอบในอาร์เรย์
            if (parts.Length > 0)
            {
                // คืนค่าองค์ประกอบแรก
                return parts[0];
            }

            // คืนค่าว่างถ้าไม่มีองค์ประกอบในอาร์เรย์
            return string.Empty;
        }

        //public static string GetSecondString(string input)
        //{
        //    // แยกสตริงโดยใช้ช่องว่างเป็นตัวแบ่ง
        //    string[] parts = input.Split(' ');

        //    // ตรวจสอบว่ามีอย่างน้อย 1 องค์ประกอบในอาร์เรย์
        //    if (parts.Length > 0)
        //    {
        //        // คืนค่าองค์ประกอบแรก
        //        try
        //        {
        //            return parts[1];
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString());
        //            return parts[0];
        //        }
        //    }

        //    // คืนค่าว่างถ้าไม่มีองค์ประกอบในอาร์เรย์
        //    return string.Empty;
        //}

        public static string GetSecondString(string input)
        {
            // แยกสตริงโดยใช้ช่องว่างเป็นตัวแบ่ง
            string[] parts = input.Split(' ');

            // ตรวจสอบว่ามีอย่างน้อย 2 องค์ประกอบในอาร์เรย์
            if (parts.Length > 1)
            {
                // คืนค่าองค์ประกอบที่สอง
                return parts[1];
            }

            // คืนค่าว่างถ้าไม่มีองค์ประกอบที่สอง
            return string.Empty;
        }
    }
}
