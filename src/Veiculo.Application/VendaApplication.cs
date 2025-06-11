using Application.Interfaces;
using Domain.DTOs;
using Domain.Interfaces.UseCase.Veiculo;
using Domain.Interfaces.UseCase.Venda;

namespace Veiculo.Application
{
    public class VendaApplication : IVendaApplication
    {
        private readonly IVendaUseCase _vendaUseCase;
        public VendaApplication(IVendaUseCase vendaUseCase)
        {
            _vendaUseCase = vendaUseCase;
        }

        public async Task<Guid> ComprarVeiculoAsyncApplicationAsync(VendaDTORequest vendaDTORequest)
        {
            return await _vendaUseCase.ComprarVeiculoAsync(vendaDTORequest);
        }

        public async Task AtualizarStatusVendaApplicationAsync(AtualizarVendaDTORequest request)
        {
            await _vendaUseCase.AtualizarStatusVendaAsync(request);
        }

        public async Task<VendaDTOResponse> ObterVendaPorCodigoPagamentoApplicationAsync(string codigoPagamento)
        {
            return await _vendaUseCase.ObterVendaPorCodigoPagamentoAsync(codigoPagamento);
        }

        public async Task<VendaDTOResponse> ObterVendaPorIdApplicationAsync(Guid vendaId)
        {
            return await _vendaUseCase.ObterVendaPorIdAsync(vendaId);
        }
    }
}
