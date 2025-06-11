namespace Domain.Contracts
{
    public class TransactionsResponse
    {
        public string NumeroPedido { get; set; }
        public string IdTransacao { get; set; }
        public string Nsu { get; set; }
        public string CodigoAutorizacao { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
    }
}