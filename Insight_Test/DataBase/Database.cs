using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Insight_Test.DataBase
{
    class Database
    {

        public static SqlConnection establishConnection()
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-E2271HF;Initial Catalog=Posts;Integrated Security=True"; //Connection to Database

            //try to establkish connection with Database
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection Established Successfully");
                return sqlConnection;
            



            }
            //Catch if any exception occurs while establishing connection
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
                
                
            }

        }


   





    }
}
