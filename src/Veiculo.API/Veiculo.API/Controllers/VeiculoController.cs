using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Veiculo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly ILogger<VeiculoController> _logger;

        private readonly IVeiculoApplication _veiculoApplication;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoApplication veiculoApplication)
        {
            _logger = logger;
            _veiculoApplication = veiculoApplication;
        }
    }
}
