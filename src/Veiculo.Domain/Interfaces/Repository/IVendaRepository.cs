using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces.Repository
{
    public interface IVendaRepository
    {
        public Task<Guid> AdicionarVendaAsync(Domain.Entities.Venda venda);

        public Task<Venda?> ObterVendaPorIdAsync(Guid vendaId);

        public Task<Venda?> ObterVendaPorCodigoPagamentoAsync(string codigoPagamento);

        public Task AtualizarStatusVendaAsync(Guid vendaId, StatusVenda novoStatus);
    }
}