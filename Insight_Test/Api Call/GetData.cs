using Insight_Test.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insight_Test.Api_Call
{
    class GetData
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task getData(SqlConnection sqlConnection)
        {
            //GetData from API
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            //Parse data using Post Model
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(response);
            //Console.WriteLine(response);

            foreach (var item in posts)
            {
                string insertQuery = "INSERT into posts(id,userID,title,body) VALUES(" + item.id + " , " + item.userId + ",'" + item.title + "','" + item.body + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                try
                {
                    insertCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
            sqlConnection.Close();
            Console.WriteLine("Data inserted Sucessfully");
        }
    }
}
