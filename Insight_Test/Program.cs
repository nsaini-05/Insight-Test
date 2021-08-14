using Insight_Test.DataBase;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Insight_Test.Api_Call

{
    class Program
    {

        public static async Task Main(string[] args)
        {
            SqlConnection sqlConnection;
            sqlConnection = Database.establishConnection(); //Creating Connection with Database
            await GetData.getData(sqlConnection);   
        }


    }
}
