using Microsoft.Data.SqlClient;

namespace ConnectionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server = localhost,1433; Database = balta; User ID = sa; Password = 1q2w3e4r@#$; TrustServerCertificate=True";
            // Package = Microsoft.Data.SqlClient
            // var connection = new SqlConnection();
            // connection.Open();
            // connection.Close(); // Fecha a conexão
            // connection.Dispose(); - Destrói a conexão, preciso dar um new para uma nova

            // Otimizando com o using (garante que a conexão vai ser fechada quando terminar)

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Querys sempre dentro do using
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    // SqlDataReader - Objeto mais fácil e rápido para ler do bd
                    // ExecuteNonQuery - Para operações que não são de leitura
                    var reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Console.WriteLine($"Id: {reader.GetGuid(0)} | Title {reader.GetString(1)}");
                    }
                }
            }
        }

    }
}
