using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace SportsTeamManagementData.Data
{
    public class DbDataAccess : IDbDataAccess
    {
        private readonly IConfiguration _configuration;

        public DbDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetDataAsync<T, P>(
            string storedProcedure, P parameters, string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            return await dbConnection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveDataAsync<T>(
            string storedProcedure,
            T parameters,
            string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            await dbConnection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
