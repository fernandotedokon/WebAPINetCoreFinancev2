using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Model;
using System.Data;

namespace Questao5.Infrastructure.Services.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public MovimentoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DatabaseName");
        }


        public IEnumerable<Movimento> GetMovimento()
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            //var connection = GetConnection();
            string sql = "select * from movimentoTED";
            var contas = connection.Query<Movimento>(sql);
            return contas;
        }

        public IEnumerable<Movimento> GetMovimentoById(int conta)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            string sql = "select * from movimentoTED where idcontacorrente = @conta";
            var contas = connection.Query<Movimento>(sql, new { conta });

            return contas;


        }




        public Movimento InsereMovimentoById(int conta, string data, string tipoOperacao, decimal valor)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            string sqlConta = "SELECT numero FROM contacorrente WHERE numero = @conta";
            var temConta = connection.QueryFirstOrDefault<Movimento>(sqlConta, new { conta });

            if (temConta != null)
            {
                var idmovimento = Guid.NewGuid();

                string newsql = "INSERT INTO movimentoTED(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) \r\n" +
                                "VALUES(@idmovimento, @conta, @data, @tipoOperacao, @valor)";

                var newcMovto = connection.QueryFirstOrDefault<Movimento>(newsql, new { conta, data, tipoOperacao, valor, idmovimento });

            }
            return temConta;

        }


    }
}
