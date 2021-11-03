#nullable enable
using System.Data;
using System.Threading.Tasks;

namespace FruitApi.Configuration.Database
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}