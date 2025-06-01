using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IVeiculoApplication
    {
        public Task<Guid> AdicionarVeiculoApplicationApplicationAsync(VeiculoDTORequest request);

        public Task AtualizarVeiculoApplicationApplicationAsync(AtualizarVeiculoDTORequest request);

        public Task<IEnumerable<VeiculoDTOResponse>> ObterVeiculosApplicationAsync();

        public Task<VeiculoDTOResponse> ObterVeiculoPorIdApplicationAsync(Guid id);

        public Task<VeiculoDTOResponse> ObterVeiculoPorMarcaApplicationAsync(string marca);

        public Task<VeiculoDTOResponse> ObterVeiculoPorModeloApplicationAsync(string modelo);

        public Task<VeiculoDTOResponse> ObterVeiculoPorAnoApplicationAsync(int ano);

        public Task<VeiculoDTOResponse> ObterVeiculoPorCorApplicationAsync(string cor);

        public Task<VeiculoDTOResponse> ObterVeiculoPorPrecoApplicationAsync(decimal preco);

        public Task DeleteVeiculoApplicationAsync(Domain.Entities.Veiculo veiculo);

        public Task<List<VeiculoDTOResponse>> ObterVeiculosDisponiveisOrdenadosApplicationAsync();

        public Task<List<VeiculoDTOResponse>> ObterVeiculosVendidosOrdenadosApplicationAsync();
    }
}
