using Domain.Enums;

namespace Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }
        public Guid VeiculoId { get; set; }
        public string ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public string CodigoPagamento { get; set; }
        public StatusVenda StatusPagamento { get; set; }
        public Domain.Entities.Veiculo Veiculo { get; set; }
    }
}
