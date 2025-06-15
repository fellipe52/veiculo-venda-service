using Domain.DTOs;

namespace Domain.Interfaces.UseCase.Veiculo
{
    public interface IVeiculoUseCase
    {
        public Task<Guid> AdicionarVeiculoAsync(VeiculoDTORequest request);

        public Task AtualizarVeiculoAsync(AtualizarVeiculoDTORequest request);     

        public Task<IEnumerable<VeiculoDTOResponse>> ObterVeiculosAsync();

        public Task<VeiculoDTOResponse> ObterVeiculoPorIdAsync(Guid id);

        public Task<VeiculoDTOResponse> ObterVeiculoPorMarcaAsync(string marca);

        public Task<VeiculoDTOResponse> ObterVeiculoPorModeloAsync(string modelo);

        public Task<VeiculoDTOResponse> ObterVeiculoPorAnoAsync(int ano);

        public Task<VeiculoDTOResponse> ObterVeiculoPorCorAsync(string cor);

        public Task<List<VeiculoDTOResponse>> ObterVeiculoPorPrecoAsync(decimal preco);

        public Task DeleteVeiculoAsync(Domain.Entities.Veiculo veiculo);

        public Task<List<VeiculoDTOResponse>> ObterVeiculosDisponiveisOrdenadosAsync();

        public Task<List<VeiculoDTOResponse>> ObterVeiculosVendidosOrdenadosAsync();
    }
}
