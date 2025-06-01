using Domain.Enums;

namespace Domain.DTOs
{
    public class VeiculoDTORequest
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }

    public class AtualizarVeiculoDTORequest
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public Decimal Preco { get; set; }
        public StatusVeiculo Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }

    public class VeiculoDTOResponse
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public Decimal Preco { get; set; }
        public StatusVeiculo Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }

}
