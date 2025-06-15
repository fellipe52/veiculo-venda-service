using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Net;
using Domain.DTOs;

namespace Veiculo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {

        private readonly IVendaApplication _vendaApplicaton;

        private readonly ILogger<VendaController> _logger;

        public VendaController(ILogger<VendaController> logger, IVendaApplication vendaApplication)
        {
            _vendaApplicaton = vendaApplication;
            _logger = logger;
        }

        [HttpPost("ComprarVeiculo")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AdicionarVeiculoAVenda([FromBody] VendaDTORequest request)
        {
            var id = await _vendaApplicaton.ComprarVeiculoAsyncApplicationAsync(request);

            return Ok(id);
        }

        [HttpGet("{vendaId:guid}")]
        [ProducesResponseType(typeof(VendaDTOResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVendaPorVendaId(Guid vendaId)
        {
            var venda = await _vendaApplicaton.ObterVendaPorIdApplicationAsync(vendaId);
            if (venda is null) return NotFound();
            return Ok(venda);
        }

        [HttpGet("PorCodigoPagamento")]
        [ProducesResponseType(typeof(VendaDTOResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVendaPorCodigoPagamento([FromQuery] string codigoPagamento)
        {
            var venda = await _vendaApplicaton.ObterVendaPorCodigoPagamentoApplicationAsync(codigoPagamento);
            if (venda is null) return NotFound();
            return Ok(venda);
        }

        [HttpPut("")]
        [ProducesResponseType(typeof(VendaDTOResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVendaPorCodigoPagamento([FromQuery] AtualizarVendaDTORequest request)
        {
            await _vendaApplicaton.AtualizarStatusVendaApplicationAsync(request);

            return NoContent();
        }
    }
}