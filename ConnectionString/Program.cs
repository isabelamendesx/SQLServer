using Microsoft.Data.SqlClient;

namespace ConnectionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";

            // Package = Microsoft.Data.SqlClient
            // var connection = new SqlConnection();
            // connection.Open();
            // connection.Close(); // Fecha a conexão
            // connection.Dispose(); - Destrói a conexão, preciso dar um new para uma nova

            // Otimizando com o using (garante que a conexão vai ser fechada quando terminar)

            using(var connection = new SqlConnection(ConnectionString))
            {

            }
        }

    }
}
