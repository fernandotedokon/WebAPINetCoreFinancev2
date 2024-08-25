using Questao5.Infrastructure.Services.Model;

namespace Questao5.Infrastructure.Services.Repository
{
    public interface IContaCorrenteRepository
    {
        public IEnumerable<ContaCorrente> GetContaCorrente();
        public ContaCorrente GetContaCorrenteById(int conta);
    }
}

