using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
