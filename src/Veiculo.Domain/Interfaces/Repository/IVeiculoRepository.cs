using Domain.Enums;

namespace Domain.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        public Task<Guid> AdicionarVeiculoAsync(Domain.Entities.Veiculo veiculo);

        public Task AtualizarVeiculoAsync(Domain.Entities.Veiculo veiculo);

        public Task<IEnumerable<Domain.Entities.Veiculo>> ObterVeiculosAsync();

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorIdAsync(Guid id);

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorMarcaAsync(string marca);

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorModeloAsync(string modelo);

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorAnoAsync(int ano);

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorCorAsync(string cor);

        public Task<Domain.Entities.Veiculo> ObterVeiculoPorPrecoAsync(decimal preco);

        public Task DeleteVeiculoAsync(Domain.Entities.Veiculo veiculo);

        public Task<List<Domain.Entities.Veiculo>> ObterVeiculosDisponiveisOrdenadosAsync();

        public Task<List<Domain.Entities.Veiculo>> ObterVeiculosVendidosOrdenadosAsync();
    }
}
