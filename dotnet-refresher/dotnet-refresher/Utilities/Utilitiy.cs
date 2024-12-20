using System;
using System.Data;
using System.Data.SqlClient;
using dotnet_refresher.Models;
using dotnet_refresher.Utilities.Interfaces;

namespace dotnet_refresher.Utilities
{
    public class Utilitiy : IUtilities
    {
        private readonly string _connStr = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=AnupamDB; Integrated Security=true";
        public Utilitiy()
        {
            
        }

        public SqlConnection GetConncetion() => new SqlConnection(_connStr);

        public void WorkWithTblData()
        {
            Person person = new Person() { PName = "Test6", Age = 34, Sex = "F" };

            #region Queries
            string query = "SELECT * FROM[AnupamDB].[dbo].[Person]";
            string query2 = "SELECT COUNT(personID) from [AnupamDB].[dbo].Person";
            string query3 = $"insert into [AnupamDB].[dbo].[Person] values ('{person.PName}', '{person.Age}', '{person.Sex}')";
            #endregion Queries

            using (SqlConnection conn = GetConncetion())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                
                // open the connection
                conn.Open();

                // Store the response
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), 
                        dataReader.GetString(3));
                }

                // Close the SqlDataReader
                dataReader.Close();

                #region Query 2
                cmd = new SqlCommand(query2, conn);
                int totalRows = (int) cmd.ExecuteScalar();
                Console.WriteLine($"Total number of rows in the table {totalRows}");
                #endregion Query 2

                #region Query 3: Insert into the tbl
                cmd = new SqlCommand(query3, conn);
                int totalRowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Number of rows affected: {totalRowsAffected}");
                #endregion Query 3: Insert into the tbl
            }
        }

        public void WorkWithStoredProcs()
        {
            // get person by id -> sp_GetById
            using (SqlConnection conn = GetConncetion())
            {
                #region sp for getting person details with person ID
                /*SqlCommand cmd = new SqlCommand("person.sp_GetById", conn);
                // Set up the command type
                cmd.CommandType = CommandType.StoredProcedure;

                // Set the parameter value for the sp
                cmd.Parameters.AddWithValue("@personId", 3);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Person person = new Person()
                    {
                        PName = reader.GetString(1),
                        Age = reader.GetInt32(2),
                        Sex = reader.GetString(3)
                    };
                    Console.WriteLine($"PersonID: {reader.GetInt32(0)} || Persona Name: {person.PName} || " +
                        $"Age: {person.Age} || Gender: {person.Sex}");
                }
                else
                {
                    Console.WriteLine("No data found");
                }

                reader.Close();
                conn.Close();*/
                #endregion

                #region sp for inserting data into the db and getting the Id from it.
                SqlCommand cmd = new SqlCommand("person.sp_addEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Person person = new Person()
                {
                    PName = "Test11",
                    Age = 29,
                    Sex = "M",
                };
                // parameters that are required for the sp
                cmd.Parameters.AddWithValue("@Name", person.PName);
                cmd.Parameters.AddWithValue("@Age", person.Age);
                cmd.Parameters.AddWithValue("@Sex", person.Sex);

                // prepare output parameter which will store the output of the sp
                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@PersonID";
                outParameter.DbType = DbType.Int32;
                // By default it is Input.
                // Here we need to have the value returned from the sp, hence changing the default one.
                outParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                string personID = outParameter.Value.ToString();
                Console.WriteLine($"Generated Person ID: {personID}");
                #endregion
            }
        }
    }
}
