using Npgsql;
using System;

namespace EasyRestProjectNetTeam2.Helpers
{
    internal class DatabaseManager
    {
        public static void SendNonQuery(string query, string queryVariable)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string formatQuery = String.Format(query, queryVariable);
                NpgsqlCommand cmd = new NpgsqlCommand(formatQuery, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void SendNonQuery(string query)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static object SendQuery(string query, string queryVariable)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string formatQuery = String.Format(query, queryVariable);
                NpgsqlCommand cmd = new NpgsqlCommand(formatQuery, con);
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                return result;
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            OperatingSystem os = Environment.OSVersion;
            string windowsConnection = @"Server=localhost;Port=5432;User Id=admin;Password=12345678;database=easyrest;";
            string macConnection = @"Server=localhost;Port=6544;User Id=admin;Password=12345678;database=easyrest;";
            
            if (os.Platform.ToString().Equals("Win32NT"))
            {
                return new NpgsqlConnection(windowsConnection);
            }
            return new NpgsqlConnection(macConnection);
        }
    }
}
