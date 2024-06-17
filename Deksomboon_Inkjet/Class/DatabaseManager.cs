using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;

namespace Deksomboon_Inkjet.Class
{
    public class DatabaseManager : IDisposable
    {
        public NpgsqlConnection connection;
        private readonly string connString;

        public DatabaseManager()
        {
            string ip = LocalStorage.ReadIPaddress();
            // เชื่อมต่อกับฐานข้อมูล PostgreSQL
            string connString = "Host="+ ip + ";Username=postgres;Password=123456;Database=deksomboon_local;Timeout=1";
            connection = new NpgsqlConnection(connString);
            connString = "Host=192.168.0.2;Username=postgres;Password=123456;Database=deksomboon_local";
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                // Console.WriteLine("Connected to PostgreSQL database.");
            }
            catch (NpgsqlException ex)
            {
                // จัดการกับ NpgsqlException ซึ่งรวมถึงปัญหา timeout
                Console.WriteLine($"ไม่สามารถเชื่อมต่อกับฐานข้อมูล: {ex.Message}");
                //throw;
            }
        }
        public async Task<bool> CheckDatabaseConnectionAsync()
        {
            using (var connection = new NpgsqlConnection("Host=192.168.0.2;Username=postgres;Password=123456;Database=deksomboon_local"))
            {
                try
                {
                    await connection.OpenAsync();
                    string cmdText = "SELECT 1"; // ทดสอบการเชื่อมต่อด้วยคำสั่งง่ายๆ
                    using (var cmd = new NpgsqlCommand(cmdText, connection))
                    {
                        await cmd.ExecuteScalarAsync();
                    }
                    return true; // การเชื่อมต่อสำเร็จและรันคำสั่ง SQL สำเร็จ
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ไม่สามารถเชื่อมต่อกับฐานข้อมูล: {ex.Message}");
                    return false; // การเชื่อมต่อล้มเหลว
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open || connection.State == System.Data.ConnectionState.Connecting)
                    {
                        await connection.CloseAsync();
                    }
                }
            }
        }
        public void CloseConnection()
        {
            try
            {
                connection.Close();
                // Console.WriteLine("Disconnected from PostgreSQL database.");
            }
            catch (NpgsqlException ex)
            {
                // จัดการกับข้อยกเว้นที่อาจเกิดขึ้นระหว่างการปิดการเชื่อมต่อ
                Console.WriteLine($"ไม่สามารถปิดการเชื่อมต่อ: {ex.Message}");
            }
        }
     
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }
        }

        public async Task OpenConnectionAsync()
        {
            await connection.OpenAsync();
        }

        public static async Task<bool> CheckDataBaseAsync()
        {
            var check = false;

            try
            {
                using (var dbManager = new DatabaseManager())
                {
                    await dbManager.OpenConnectionAsync(); // Assuming OpenConnectionAsync() is an async method

                    string query = "SELECT * FROM database where database_name = 'deksomboon'";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, dbManager.connection))
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        check = true;
                        //Console.WriteLine("Database is available");
                    }
                }
            }
            catch (Exception e)
            {
                check = false;
                //Console.WriteLine(e.ToString());
                //Console.WriteLine("Database Not available");
            }

            return check;
        }

    }
}
