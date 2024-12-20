using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace dotnet_refresher.Utilities
{
    public class DbManipulations
    {
        private readonly string serverName = "(localdb)\\MSSQLLocalDB";
        private readonly string dbName = "AnupamDB";
        public SqlConnection SqlConn { get; set; }
        public DbManipulations()
        {

        }

        public void GetAllFromDB()
        {
            string connStr = $"Data Source={serverName}; Initial Catalog={dbName}; Integrated Security=true";
            SqlConn = new SqlConnection(connStr);
            try
            {
                string sqlQuery = "SELECT * FROM [AnupamDB].[dbo].[Person]";
                SqlCommand cmd = new SqlCommand(sqlQuery, SqlConn);
                SqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                reader.Close();
                SqlConn.Close();
            }
        }
    }
}
