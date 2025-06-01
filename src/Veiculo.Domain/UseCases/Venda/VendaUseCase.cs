using System.Xml;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.UseCase.Venda;

namespace Domain.UseCases.Venda;
public class VendaUseCase : IVendaUseCase
{
    private readonly IVendaRepository _repository;

    public VendaUseCase(IVendaRepository repository) 
    {
        _repository = repository;
    }

    public async Task<Guid> AdicionarVeiculoAVendaAsync(VendaDTORequest vendaDTORequest)
    {
        Domain.Entities.Venda vendaRequest = new Domain.Entities.Venda();

        vendaRequest.DataVenda = vendaDTORequest.DataVenda;
        vendaRequest.VeiculoId = vendaDTORequest.VeiculoId;
        vendaRequest.CpfComprador = vendaDTORequest.CpfComprador;
        vendaRequest.DataVenda = vendaDTORequest.DataVenda;
        vendaRequest.CodigoPagamento = vendaDTORequest.CodigoPagamento;
        vendaRequest.StatusPagamento = vendaDTORequest.StatusPagamento;

        var response = await _repository.AdicionarVendaAsync(vendaRequest);

        return response;
    }

    public async Task<VendaDTOResponse> ObterVendaPorIdAsync(Guid vendaId)
    {
        VendaDTOResponse response = new VendaDTOResponse();

        var result = await _repository.ObterVendaPorIdAsync(vendaId);

        response.Id = result.Id;
        response.DataVenda = result.DataVenda;
        response.VeiculoId = result.VeiculoId;
        response.CpfComprador = result.CpfComprador;
        response.DataVenda = result.DataVenda;
        response.CodigoPagamento = result.CodigoPagamento;
        response.StatusPagamento = result.StatusPagamento;

        return response;
    }

    public async Task<VendaDTOResponse> ObterVendaPorCodigoPagamentoAsync(string codigoPagamento)
    {
        VendaDTOResponse response = new VendaDTOResponse();

        var result = await _repository.ObterVendaPorCodigoPagamentoAsync(codigoPagamento);

        response.Id = result.Id;
        response.DataVenda = result.DataVenda;
        response.VeiculoId = result.VeiculoId;
        response.CpfComprador = result.CpfComprador;
        response.DataVenda = result.DataVenda;
        response.CodigoPagamento = result.CodigoPagamento;
        response.StatusPagamento = result.StatusPagamento;

        return response;
    }

    public async Task AtualizarStatusVendaAsync(AtualizarVendaDTORequest request)
    {
        var temVenda = await _repository.ObterVendaPorIdAsync(request.Id);

        if (temVenda == null) { return; }

        await _repository.AtualizarStatusVendaAsync(request.Id, request.StatusPagamento);
    }
}
