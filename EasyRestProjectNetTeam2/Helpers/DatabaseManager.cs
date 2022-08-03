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

        //public static string SendQuery(string query, string queryVariable)
        //{
        //    using (NpgsqlConnection con = GetConnection())
        //    {
        //        string formatQuery = String.Format(query, queryVariable);
        //        NpgsqlCommand cmd = new NpgsqlCommand(formatQuery, con);
        //        con.Open();
        //        string result = string.Empty;
        //        var getValue = cmd.ExecuteScalar();
        //        if (getValue != null)
        //        {
        //            result = getValue.ToString();
        //        }
        //        con.Close();
        //        return result;
        //    }
        //}
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
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=admin;Password=12345678;database=easyrest;");
        }

    }
}
