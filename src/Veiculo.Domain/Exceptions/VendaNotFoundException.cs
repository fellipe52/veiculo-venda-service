namespace Domain.Exceptions
{
    public class VendaNotFoundException : Exception
    {
        public VendaNotFoundException(Guid id)
            : base($"Venda com ID {id} não encontrado.") { }
    }
}
