using Application.Interfaces;
using Domain.DTOs;
using Domain.Interfaces.UseCase.Veiculo;

namespace Application
{
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IVeiculoUseCase _veiculoUseCase;
        public VeiculoApplication(IVeiculoUseCase veiculoUseCase)
        {
            _veiculoUseCase = veiculoUseCase;
        }

        public async Task<Guid> AdicionarVeiculoApplicationApplicationAsync(VeiculoDTORequest request)
        {
            return await _veiculoUseCase.AdicionarVeiculoAsync(request);
        }

        public async Task AtualizarVeiculoApplicationApplicationAsync(AtualizarVeiculoDTORequest request)
        {
            await _veiculoUseCase.AtualizarVeiculoAsync(request);
        }

        public async Task DeleteVeiculoApplicationAsync(Domain.Entities.Veiculo veiculo)
        {
            await _veiculoUseCase.DeleteVeiculoAsync(veiculo);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorAnoApplicationAsync(int ano)
        {
            return await _veiculoUseCase.ObterVeiculoPorAnoAsync(ano);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorCorApplicationAsync(string cor)
        {
            return await _veiculoUseCase.ObterVeiculoPorCorAsync(cor);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorIdApplicationAsync(Guid id)
        {
            return await _veiculoUseCase.ObterVeiculoPorIdAsync(id);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorMarcaApplicationAsync(string marca)
        {
            return await _veiculoUseCase.ObterVeiculoPorMarcaAsync(marca);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorModeloApplicationAsync(string modelo)
        {
            return await _veiculoUseCase.ObterVeiculoPorModeloAsync(modelo);
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorPrecoApplicationAsync(decimal preco)
        {
            return await _veiculoUseCase.ObterVeiculoPorPrecoAsync(preco);
        }

        public async Task<IEnumerable<VeiculoDTOResponse>> ObterVeiculosApplicationAsync()
        {
            return await _veiculoUseCase.ObterVeiculosAsync();
        }

        public async Task<List<VeiculoDTOResponse>> ObterVeiculosDisponiveisOrdenadosApplicationAsync()
        {
            return await _veiculoUseCase.ObterVeiculosDisponiveisOrdenadosAsync();
        }

        public async Task<List<VeiculoDTOResponse>> ObterVeiculosVendidosOrdenadosApplicationAsync()
        {
            return await _veiculoUseCase.ObterVeiculosVendidosOrdenadosAsync();
        }
    }
}