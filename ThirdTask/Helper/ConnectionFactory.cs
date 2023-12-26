
using Microsoft.Data.SqlClient;
using System.Data;

namespace ThirdTask.Helper
{

    public class ConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory()
        {
            _connectionString = Environment.GetEnvironmentVariable("MY_DATABASE_CONNECTION");
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Database connection string is not set in environment variables.");
            }
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }


}
