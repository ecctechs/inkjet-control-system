using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using Npgsql;

namespace Deksomboon_Inkjet.Class
{
    public class DataLogAuth
    {

        public int log_authorized_id { get; set; }


        public int ord_id { get; set; }


        public int emp_id { get; set; }

        [Name(name: "วันที่")]
        public string date_authorized { get; set; }

        [Name(name: "Action")]
        public string action { get; set; }

        [Name(name: "Level authorized")]
        public int level_authorized { get; set; }

        [Name(name: "ข้อความที่ยิง")]
        public string batch_number { get; set; }

        [Name(name: "พนักงาน")]
        public string emp_name { get; set; }

        public static List<DataLogAuth> ListDataLogAuth()
        {
            List<DataLogAuth> ListDatalog = new List<DataLogAuth>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    string query = @"SELECT * FROM authorized_log
                    LEFT JOIN order_detail
                    ON order_detail.ord_id = authorized_log.ord_id
                    LEFT JOIN employee
                    ON employee.emp_id = authorized_log.emp_id Order by log_authorized_id;";


                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataLogAuth datalog = new DataLogAuth
                            {
                                ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                date_authorized = reader.GetString(reader.GetOrdinal("date_authorized")),
                                action = reader.GetString(reader.GetOrdinal("action")),
                                level_authorized = reader.GetInt32(reader.GetOrdinal("level_authorized")),
                                batch_number = reader.GetString(reader.GetOrdinal("batch_number")),
                                // เพิ่ม properties อื่น ๆ ตามต้องการ
                            };

                            ListDatalog.Add(datalog);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ListDatalog;
        }


        //public static List<DataLogAuth> Search_DataLogAuth(string action , string level ,string emp_id, string start_date, string end_date)
        //{
        //    List<DataLogAuth> listDataLogAuth = new List<DataLogAuth>();

        //    try
        //    {
        //        using (var dbManager = new DatabaseManager())
        //        {
        //            dbManager.OpenConnection();

        //            string query;


        //            query = @"SELECT * FROM authorized_log
        //            LEFT JOIN order_detail
        //            ON order_detail.ord_id = authorized_log.ord_id
        //            LEFT JOIN employee
        //            ON employee.emp_id = authorized_log.emp_id ;";

        //            //Console.WriteLine(query);

        //            using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
        //            using (NpgsqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    DataLogAuth datalogauth = new DataLogAuth
        //                    {
        //                        ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
        //                        emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
        //                        date_authorized = reader.GetString(reader.GetOrdinal("date_authorized")),
        //                        action = reader.GetString(reader.GetOrdinal("action")),
        //                        level_authorized = reader.GetInt32(reader.GetOrdinal("level_authorized")),
        //                        batch_number = reader.GetString(reader.GetOrdinal("batch_number")),

        //                        // เพิ่ม properties อื่น ๆ ตามต้องการ
        //                    };
        //                    var date_records = DateTime.Parse(datalogauth.date_authorized);
        //                    var date_records_start = DateTime.Parse(start_date);
        //                    var date_records_end = DateTime.Parse(end_date);

        //                    if (date_records >= date_records_start && date_records <= date_records_end)
        //                    {
        //                        if (action == "เลือก")
        //                        {
        //                             if (level == "เลือก")
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                            else if(datalogauth.level_authorized == Int32.Parse(level))
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }

        //                            else if(emp_id == "0")
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                            else if (datalogauth.emp_id == Int32.Parse(emp_id))
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                        }
        //                        else if(action == datalogauth.action)
        //                        {
        //                            if (level == "เลือก")
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                            else if (datalogauth.level_authorized == Int32.Parse(level))
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }

        //                            else if(emp_id == "0")
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                            else if (datalogauth.emp_id == Int32.Parse(emp_id))
        //                            {
        //                                listDataLogAuth.Add(datalogauth);
        //                            }
        //                        }
        //                        //else if (datalogauth.action == action)
        //                        //{
        //                        //    listDataLogAuth.Add(datalogauth);
        //                        //}

        //                        //else if (level == "เลือก")
        //                        //{
        //                        //    listDataLogAuth.Add(datalogauth);
        //                        //}
        //                        //else if (datalogauth.level_authorized == Int32.Parse(level))
        //                        //{
        //                        //    listDataLogAuth.Add(datalogauth);
        //                        //}

        //                        //else if(emp_id == "0")
        //                        //{
        //                        //    listDataLogAuth.Add(datalogauth);
        //                        //}
        //                        //else if (datalogauth.emp_id == Int32.Parse(emp_id))
        //                        //{
        //                        //    listDataLogAuth.Add(datalogauth);
        //                        //}
        //                    }


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }

        //    return listDataLogAuth;
        //}

        public static List<DataLogAuth> Search_DataLogAuth(string action, string level, string emp_id, string start_date, string end_date)
        {
            List<DataLogAuth> listDataLogAuth = new List<DataLogAuth>();

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    dbManager.OpenConnection();

                    var query = new StringBuilder(@"SELECT * FROM authorized_log
                                            LEFT JOIN order_detail ON order_detail.ord_id = authorized_log.ord_id
                                            LEFT JOIN employee ON employee.emp_id = authorized_log.emp_id
                                            WHERE 1=1");

                    var parameters = new List<NpgsqlParameter>();

                    if (!string.IsNullOrEmpty(action) && action != "เลือก")
                    {
                        query.Append(" AND authorized_log.action = @action Order by authorized_log.log_authorized_id");
                        parameters.Add(new NpgsqlParameter("action", action));
                    }

                    if (!string.IsNullOrEmpty(level) && level != "เลือก")
                    {
                        query.Append(" AND authorized_log.level_authorized = @level Order by authorized_log.log_authorized_id");
                        parameters.Add(new NpgsqlParameter("level", Int32.Parse(level)));
                    }

                    if (!string.IsNullOrEmpty(emp_id) && emp_id != "0")
                    {
                        query.Append(" AND authorized_log.emp_id = @emp_id Order by authorized_log.log_authorized_id");
                        parameters.Add(new NpgsqlParameter("emp_id", Int32.Parse(emp_id)));
                    }

                    //Console.WriteLine(query.ToString());



                    using (NpgsqlCommand command = new NpgsqlCommand(query.ToString(), dbManager.connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataLogAuth datalogauth = new DataLogAuth
                                {
                                    ord_id = reader.GetInt32(reader.GetOrdinal("ord_id")),
                                    emp_name = reader.GetString(reader.GetOrdinal("emp_name")),
                                    date_authorized = reader.GetString(reader.GetOrdinal("date_authorized")),
                                    action = reader.GetString(reader.GetOrdinal("action")),
                                    level_authorized = reader.GetInt32(reader.GetOrdinal("level_authorized")),
                                    batch_number = reader.GetString(reader.GetOrdinal("batch_number")),
                                    // Add other properties as needed
                                };
                                var date_records = DateTime.Parse(datalogauth.date_authorized);
                                var date_records_start = DateTime.Parse(start_date);
                                var date_records_end = DateTime.Parse(end_date);

                                if (date_records >= date_records_start && date_records <= date_records_end)
                                {
                                    listDataLogAuth.Add(datalogauth);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return listDataLogAuth;
        }

    }
}
