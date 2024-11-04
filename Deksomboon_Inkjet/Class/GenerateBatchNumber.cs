using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Deksomboon_Inkjet.Class
{
    public class GenerateBatchNumber
    {
        public static string order_batch_number_generate(DateTime date, string batch, string formula, string line)
        {
            string tenDigit = "";

            // Get the year from the selected date
            int year_input = date.Year;
            //Console.WriteLine(year_input);

            // Get the last digit of the year
            int lastDigitOfYear = year_input % 10;

            // Convert the last digit to a string
            string year = lastDigitOfYear.ToString();

            int month = date.Month;

            string monthString;
            if (month == 10)
            {
                monthString = "A";
            }
            else if (month == 11)
            {
                monthString = "B";
            }
            else if (month == 12)
            {
                monthString = "C";
            }
            else
            {
                // If month is not 10, 11, or 12, just use the digit itself
                monthString = month.ToString();
            }

            int daySting = date.Day;

            string day = daySting.ToString("D2");

            //Console.WriteLine("test : >" + day);

            tenDigit = year + monthString + day + batch + formula + line;
            //Console.WriteLine(tenDigit);

            return tenDigit;
        }

        public static string order_bbf_generate(DateTime date, string slife , bool column_ord_type_print_swap , bool column_ord_type_print_time)
        {
            string BBF = "";
            DateTime currentTime = DateTime.Now;
            if (slife != "")
            {
                int numberOfDays = Int32.Parse(slife);

                // บวกจำนวนวันกับวันที่ปัจจุบัน
                DateTime resultDate = date.AddMonths(numberOfDays);
                string resultDateString = "";
                //string resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy"); // รูปแบบสตริงตามที่ต้องการ เช่น "yyyy-MM-dd"
                if (column_ord_type_print_swap == false)
                {
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        //resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy HH:mm");
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy") + " " + currentTime.ToString("HH:mm");
                    }
                }
                else
                {                     
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        //resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd HH:mm");
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd") + " " + currentTime.ToString("HH:mm");
                    }
                }
                // Combine with current time if needed
                //if (column_ord_type_print_time)
                //{
                //    resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd") + " " + currentTime.ToString("HH:mm");
                //}

                //Console.WriteLine(resultDateString);
                BBF = "BBF "+ resultDateString;
            }
            return BBF;
        }

        public static string order_exp_generate(DateTime date, string slife , bool column_ord_type_print_swap, bool column_ord_type_print_time)
        {
            string BBF = "";
            DateTime currentTime = DateTime.Now;

            if (slife != "")
            {
                int numberOfDays = Int32.Parse(slife);

                // บวกจำนวนวันกับวันที่ปัจจุบัน
                DateTime resultDate = date.AddMonths(numberOfDays);

                //string resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd"); // รูปแบบสตริงตามที่ต้องการ เช่น "yyyy-MM-dd"
                string resultDateString = "";
                //string resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy"); // รูปแบบสตริงตามที่ต้องการ เช่น "yyyy-MM-dd"
                if (column_ord_type_print_swap == false)
                {
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        //resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy HH:mm");
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy") + " " + currentTime.ToString("HH:mm");
                    }
                }
                else
                {
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        //resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd HH:mm");
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd") + " " + currentTime.ToString("HH:mm");
                    }
                }

                // Combine with current time if needed
                //if (column_ord_type_print_time)
                //{
                //    resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd") + " " + currentTime.ToString("HH:mm");
                //}

                //Console.WriteLine(resultDateString);
                BBF = "EXP " + resultDateString;
            }
            return BBF;
        }


        public static string order_mfg_generate(DateTime date, string slife , bool column_ord_type_print_swap, bool column_ord_type_print_time)
        {
            string BBF = "";

            if (slife != "")
            {
                int numberOfDays = Int32.Parse(slife);

                // บวกจำนวนวันกับวันที่ปัจจุบัน
                //DateTime resultDate = date.AddMonths(numberOfDays);
                DateTime resultDate = DateTime.Now;

                //string resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd"); // รูปแบบสตริงตามที่ต้องการ เช่น "yyyy-MM-dd"
                string resultDateString = "";
                //string resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy"); // รูปแบบสตริงตามที่ต้องการ เช่น "yyyy-MM-dd"
                if (column_ord_type_print_swap == false)
                {
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("dd/MM/yyyy HH:mm");
                    }
                }
                else
                {
                    if (column_ord_type_print_time == false)
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        resultDateString = resultDate.AddYears(-543).ToString("yyyy/MM/dd HH:mm");
                    }
                }
                //Console.WriteLine(resultDateString);
                BBF = "MFG " + resultDateString;
            }
            return BBF;
        }
    }
}
