using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Enums;

namespace Infrastructure.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VeiculoVendaContext _context;

        public VendaRepository(VeiculoVendaContext context)
        {
            _context = context;
        }

        public async Task<Guid> AdicionarVendaAsync(Domain.Entities.Venda venda)
        {
            var result = await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<Venda?> ObterVendaPorIdAsync(Guid vendaId)
        {
            return await _context.Vendas
                .FirstOrDefaultAsync(v => v.Id == vendaId);
        }

        public async Task<Venda?> ObterVendaPorCodigoPagamentoAsync(string codigoPagamento)
        {
            return await _context.Vendas
                .FirstOrDefaultAsync(v => v.CodigoPagamento == codigoPagamento);
        }

        public async Task AtualizarStatusVendaAsync(Guid vendaId, StatusVenda novoStatus)
        {
            var venda = await _context.Vendas.FirstOrDefaultAsync(v => v.Id == vendaId);
            if (venda == null) return;

            venda.StatusPagamento = novoStatus;
            await _context.SaveChangesAsync();
        }
    }
}
