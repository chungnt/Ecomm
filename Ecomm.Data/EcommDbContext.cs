using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Ecomm.Data
{
    public class EcommDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EcommDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EcommDbConnection");
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
