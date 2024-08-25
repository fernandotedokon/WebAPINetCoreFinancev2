using Questao5.Infrastructure.Services.Model;

namespace Questao5.Infrastructure.Services.Repository
{
    public interface IMovimentoRepository
    {
        public IEnumerable<Movimento> GetMovimento();
        public IEnumerable<Movimento> GetMovimentoById(int conta);
        public Movimento InsereMovimentoById(int conta, string data, string tipoOperacao, decimal valor);
    }
}
