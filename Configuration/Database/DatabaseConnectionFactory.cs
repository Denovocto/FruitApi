using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FruitApi.Configuration.Database
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            return connection; 
        }
    }
}