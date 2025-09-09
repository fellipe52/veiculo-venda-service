using Domain.Enums;

namespace Domain.DTOs
{
    public class VendaDTORequest
    {
        public Guid VeiculoId { get; set; }
        public string ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public string CodigoPagamento { get; set; }
        public StatusVenda StatusPagamento { get; set; }
    }

    public class VendaDTOResponse
    {
        public Guid Id { get; set; }
        public Guid VeiculoId { get; set; }
        public string CpfComprador { get; set; }
        public DateTime DataVenda { get; set; }
        public string CodigoPagamento { get; set; }
        public StatusVenda StatusPagamento { get; set; }
    }

    public class AtualizarVendaDTORequest
    {
        public Guid Id { get; set; }
        public StatusVenda StatusPagamento { get; set; }
    }
}
