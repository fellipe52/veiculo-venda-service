using Domain.Enums;

namespace Domain.DTOs
{
    public class VendaDTORequest
    {
        public Guid VeiculoId { get; set; }
        public string CpfComprador { get; set; }
        public DateTime DataVenda { get; set; }
        public string CodigoPagamento { get; set; }
        public StatusVenda StatusPagamento { get; set; }

        public string TipoTransacao { get; set; }
        public int Valor { get; set; }
        public int NumeroParcelas { get; set; }
        public string NomeImpressoCartao { get; set; }
        public string NumeroCartao { get; set; }
        public int MesVencimentoCartao { get; set; }
        public int AnoVencimentoCartao { get; set; }
        public string CodigoSegurancaCartao { get; set; }
        public string CategoriaTransacao { get; set; }
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
