using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Domain.Interfaces.Repository;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly VeiculoVendaContext _context;

        public VeiculoRepository(VeiculoVendaContext context)
        {
            _context = context;
        }

        public async Task<Guid> AdicionarVeiculoAsync(Domain.Entities.Veiculo veiculo)
        {
            var result = await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task AtualizarVeiculoAsync(Domain.Entities.Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Veiculo>> ObterVeiculosAsync()
        {
            return await _context.Veiculos
              .AsQueryable().Where(v => v.Status == StatusVeiculo.Disponivel && v.Ativo == true).ToListAsync();
        }

        public async Task<Domain.Entities.Veiculo> ObterVeiculoPorIdAsync(Guid id)
        {
            return await _context.Veiculos
                .FirstOrDefaultAsync(v => v.Id == id && v.Status == StatusVeiculo.Disponivel && v.Ativo == true);
        }

        public async Task<Domain.Entities.Veiculo> ObterVeiculoPorMarcaAsync(string marca)
        {
            return await _context.Veiculos
                .FirstOrDefaultAsync(v => v.Marca == marca && v.Status == StatusVeiculo.Disponivel && v.Ativo == true);
        }

        public async Task<Domain.Entities.Veiculo> ObterVeiculoPorModeloAsync(string modelo)
        {
            return await _context.Veiculos
                .FirstOrDefaultAsync(v => v.Modelo == modelo && v.Status == StatusVeiculo.Disponivel && v.Ativo == true);
        }

        public async Task<Domain.Entities.Veiculo> ObterVeiculoPorAnoAsync(int ano)
        {
            return await _context.Veiculos
                .FirstOrDefaultAsync(v => v.Ano == ano && v.Status == StatusVeiculo.Disponivel && v.Ativo == true);
        }

        public async Task<Domain.Entities.Veiculo> ObterVeiculoPorCorAsync(string cor)
        {
            return await _context.Veiculos
                .FirstOrDefaultAsync(v => v.Cor == cor && v.Status == StatusVeiculo.Disponivel && v.Ativo == true);
        }

        public async Task<List<Domain.Entities.Veiculo>> ObterVeiculoPorPrecoAsync(decimal preco)
        {
            return await _context.Veiculos
                .Where(v => v.Preco == preco && v.Status == StatusVeiculo.Disponivel && v.Ativo == true)
                .OrderBy(v => v.Preco)
                .ToListAsync();
        }

        public async Task DeleteVeiculoAsync(Domain.Entities.Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.Veiculo>> ObterVeiculosDisponiveisOrdenadosAsync()
        {
            return await _context.Veiculos
                .Where(v => v.Status == StatusVeiculo.Disponivel && v.Ativo == true)
                .OrderBy(v => v.Preco)
                .ToListAsync();
        }

        public async Task<List<Domain.Entities.Veiculo>> ObterVeiculosVendidosOrdenadosAsync()
        {
            return await _context.Veiculos
                .Where(v => v.Status == StatusVeiculo.Vendido && v.Ativo == true)
                .OrderBy(v => v.Preco)
                .ToListAsync();
        }
    }
}
