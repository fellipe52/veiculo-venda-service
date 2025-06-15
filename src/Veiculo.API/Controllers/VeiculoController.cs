using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;
using System.Net;
using Veiculo.Application;

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

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AdicionarVeiculo([FromBody] VeiculoDTORequest request)
        {
            var id = await _veiculoApplication.AdicionarVeiculoApplicationApplicationAsync(request);

            return Ok(id);
        }

        [HttpPut("atualizar/dados")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AtualizarDadosVeiculo([FromQuery] AtualizarVeiculoDTORequest request)
        {
            await _veiculoApplication.AtualizarVeiculoApplicationApplicationAsync(request);

            return NoContent();
        }


        [HttpGet("Preco")]
        [ProducesResponseType(typeof(List<VeiculoDTOResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVeiculoPorPreco([FromQuery] decimal preco)
        {
            var venda = await _veiculoApplication.ObterVeiculoPorPrecoApplicationAsync(preco);
            if (venda is null) return NotFound();
            return Ok(venda);
        }

        [HttpGet("ordenados/baratos")]
        [ProducesResponseType(typeof(List<VeiculoDTOResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVeiculoDisponiveisOrdenadoPorPreco()
        {
            var venda = await _veiculoApplication.ObterVeiculosDisponiveisOrdenadosApplicationAsync();
            if (venda is null) return NotFound();
            return Ok(venda);
        }

        [HttpGet("vendidos/ordenados/baratos")]
        [ProducesResponseType(typeof(List<VeiculoDTOResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterVeiculoVendidosOrdenadosPorPreco()
        {
            var venda = await _veiculoApplication.ObterVeiculosVendidosOrdenadosApplicationAsync();
            if (venda is null) return NotFound();
            return Ok(venda);
        }
    }
}