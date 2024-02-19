using Dapper;
using DapperConnector.Models;
using Microsoft.Data.SqlClient;

namespace DapperConnector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server = localhost,1433; Database = balta; User ID = sa; Password = 1q2w3e4r@#$; TrustServerCertificate=True";
        
            using(var connection = new SqlConnection(ConnectionString))
            {
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                
                foreach (var item in categories) 
                    Console.WriteLine($"Id: {item.Id} | Title: {item.Title}");
            }
        }
    }
}
