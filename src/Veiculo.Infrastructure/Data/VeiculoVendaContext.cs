using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class VeiculoVendaContext : DbContext
{
    public VeiculoVendaContext(DbContextOptions<VeiculoVendaContext> options)
        : base(options) { }

    public DbSet<Domain.Entities.Veiculo> Veiculos => Set<Domain.Entities.Veiculo>();

    public DbSet<Domain.Entities.Venda> Vendas => Set<Domain.Entities.Venda>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeiculoVendaContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
