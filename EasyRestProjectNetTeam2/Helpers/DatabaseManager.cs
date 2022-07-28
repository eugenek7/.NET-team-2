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
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=admin;Password=12345678;database=easyrest;");
        }
    }
}
