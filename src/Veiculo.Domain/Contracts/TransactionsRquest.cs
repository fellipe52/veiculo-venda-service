namespace Domain.Contracts
{
    public class TransactionsRquest
    {
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
}