using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IVendaApplication
    {
        public Task<Guid> AdicionarVeiculoAVendaApplicationAsync(VendaDTORequest vendaDTORequest);

        public Task<VendaDTOResponse> ObterVendaPorIdApplicationAsync(Guid vendaId);

        public Task<VendaDTOResponse> ObterVendaPorCodigoPagamentoApplicationAsync(string codigoPagamento);

        public Task AtualizarStatusVendaApplicationAsync(AtualizarVendaDTORequest request);
    }
}
