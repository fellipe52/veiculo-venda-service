using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class VeiculoNotFoundException : Exception
    {
        public VeiculoNotFoundException(Guid id)
            : base($"Veiculo com ID {id} não encontrado.") { }
    }
}
