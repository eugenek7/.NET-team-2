using Npgsql;

namespace EasyRestProjectNetTeam2.Helpers
{
    class DatabaseManager
    {
        public static void SendNonQuery(string query)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                //string query = "DELETE FROM users WHERE email='eugene@test.com';";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=admin;Password=12345678;database=easyrest;");
        }
    }
}
