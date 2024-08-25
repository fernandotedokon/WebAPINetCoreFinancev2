using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Model;
using System.Data;

namespace Questao5.Infrastructure.Services.Repository
{
    public sealed class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public ContaCorrenteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DatabaseName");
        }


        public IEnumerable<ContaCorrente> GetContaCorrente()
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            string sql = "select * from contacorrente";
            var contas = connection.Query<ContaCorrente>(sql);
            return contas;
        }


        public ContaCorrente GetContaCorrenteById(int conta)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            string sql = "select * from contacorrente where numero = @conta";
            var contas = connection.QueryFirstOrDefault<ContaCorrente>(sql, new { conta });
            return contas;
        }


    }
}
