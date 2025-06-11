using Domain.Contracts;

namespace Veiculo.Domain.Interfaces.Service
{
    public interface IPagamentoService
    {
        public Task<TransactionsResponse> CriarTransacaoAsync(TransactionsRquest request);
    }
}