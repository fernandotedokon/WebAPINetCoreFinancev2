using Questao5.Infrastructure.Services.Model;

namespace Questao5.Infrastructure.Services.Repository
{
    public interface ISaldoContaRepository
    {
        public SaldoConta GetSaldoContaById(int conta);
    }
}
