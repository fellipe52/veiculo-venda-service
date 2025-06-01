using Domain.DTOs;

namespace Domain.Interfaces.UseCase.Venda
{
    public interface IVendaUseCase
    {
        public Task<Guid> AdicionarVeiculoAVendaAsync(VendaDTORequest vendaDTORequest);

        public Task<VendaDTOResponse> ObterVendaPorIdAsync(Guid vendaId);

        public Task<VendaDTOResponse> ObterVendaPorCodigoPagamentoAsync(string codigoPagamento);

        public Task AtualizarStatusVendaAsync(AtualizarVendaDTORequest request);
    }
}
