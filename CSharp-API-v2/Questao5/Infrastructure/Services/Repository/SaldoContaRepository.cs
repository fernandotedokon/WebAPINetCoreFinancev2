using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Model;
using System.Data;

namespace Questao5.Infrastructure.Services.Repository
{
    public class SaldoContaRepository : ISaldoContaRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public SaldoContaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DatabaseName");
        }


        public SaldoConta GetSaldoContaById(int conta)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            string sql = "SELECT DISTINCT idcontacorrente\r\n           " +
                                ",ifnull((SELECT SUM(C.valor)\r\n       " +
                                   "FROM movimentoTED C\r\n             " +
                                  "WHERE C.idcontacorrente = @conta\r\n " +
                                    "AND C.tipomovimento = 'C'\r\n      " +
                               "GROUP BY C.idcontacorrente),0) credito_total\r\n  " +
                               ",ifnull((SELECT SUM(D.valor)\r\n                  " +
                                   "FROM movimentoTED D\r\n                       " +
                                  "WHERE D.idcontacorrente = @conta\r\n           " +
                                    "AND D.tipomovimento = 'D'\r\n                " +
                               "GROUP BY D.idcontacorrente),0) debito_total\r\n   " +
                               ",ifnull((SELECT SUM(C.valor)\r\n                  " +
                                   "FROM movimentoTED C\r\n                       " +
                                  "WHERE C.idcontacorrente = @conta\r\n           " +
                                    "AND C.tipomovimento = 'C'\r\n                " +
                               "GROUP BY C.idcontacorrente),0) - \r\n             " +
                                "ifnull((SELECT SUM(D.valor)\r\n                  " +
                                   "FROM movimentoTED D\r\n                       " +
                                  "WHERE D.idcontacorrente = @conta\r\n           " +
                                    "AND D.tipomovimento = 'D'\r\n                " +
                               "GROUP BY D.idcontacorrente),0) saldo\r\n          " +
                            "FROM movimentoTED\r\n                                " +
                           "WHERE idcontacorrente = @conta";
            var saldo = connection.QueryFirstOrDefault<SaldoConta>(sql, new { conta });
            return saldo;

        }



    }
}
