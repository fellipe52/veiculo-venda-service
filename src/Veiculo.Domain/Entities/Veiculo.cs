using Domain.Enums;

namespace Domain.Entities
{
    public class Veiculo
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
