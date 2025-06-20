﻿using Domain.Contracts;
using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.UseCase.Venda;
using Veiculo.Domain.Interfaces.Service;

namespace Domain.UseCases.Venda;
public class VendaUseCase : IVendaUseCase
{
    private readonly IVendaRepository _repository;
    private readonly IPagamentoService _service;

    public VendaUseCase(IVendaRepository repository, IPagamentoService service) 
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Guid> ComprarVeiculoAsync(VendaDTORequest request)
    {
        Domain.Entities.Venda vendaRequest = new Domain.Entities.Venda()
        {
            VeiculoId = request.VeiculoId,
            CpfComprador = request.CpfComprador,
            DataVenda = DateTime.Now,
            CodigoPagamento = request.CodigoPagamento,
            StatusPagamento = request.StatusPagamento
        };

        var transacaoRequest = new TransactionsRquest
        {
            TipoTransacao = request.TipoTransacao,
            Valor = request.Valor,
            NumeroParcelas = request.NumeroParcelas,
            NomeImpressoCartao = request.NomeImpressoCartao,
            NumeroCartao = request.NumeroCartao,
            MesVencimentoCartao = request.MesVencimentoCartao,
            AnoVencimentoCartao = request.AnoVencimentoCartao,
            CodigoSegurancaCartao = request.CodigoSegurancaCartao,
            CategoriaTransacao = request.CategoriaTransacao
        };

        var transacaoResponse = await _service.CriarTransacaoAsync(transacaoRequest);

        if(transacaoResponse.CodigoRetorno == "-1")
        {
            return Guid.Empty;
        }

        //var response = await _repository.AdicionarVendaAsync(vendaRequest);

        return Guid.Parse("1d5d20eb-c714-4adb-823f-7d78524c0534");
    }


    public async Task<VendaDTOResponse> ObterVendaPorIdAsync(Guid vendaId)
    {
        VendaDTOResponse response = new VendaDTOResponse();

        //var result = await _repository.ObterVendaPorIdAsync(vendaId);

        //response.Id = result.Id;
        //response.DataVenda = result.DataVenda;
        //response.VeiculoId = result.VeiculoId;
        //response.CpfComprador = result.CpfComprador;
        //response.DataVenda = result.DataVenda;
        //response.CodigoPagamento = result.CodigoPagamento;
        //response.StatusPagamento = result.StatusPagamento;


        response.Id = Guid.Parse("1d5d20eb-c714-4adb-823f-7d78524c0534");
        response.DataVenda = DateTime.Now;
        response.VeiculoId = Guid.Parse("3694fcbd-2ad9-44f5-bf90-257a3892641c");
        response.CpfComprador = "252.912.070-60";
        response.DataVenda = DateTime.Now;
        response.CodigoPagamento = "4325";
        response.StatusPagamento = StatusVenda.Efetivada;
        

        return response;
    }

    public async Task<VendaDTOResponse> ObterVendaPorCodigoPagamentoAsync(string codigoPagamento)
    {
        VendaDTOResponse response = new VendaDTOResponse();

        //var result = await _repository.ObterVendaPorCodigoPagamentoAsync(codigoPagamento);

        //response.Id = result.Id;
        //response.DataVenda = result.DataVenda;
        //response.VeiculoId = result.VeiculoId;
        //response.CpfComprador = result.CpfComprador;
        //response.DataVenda = result.DataVenda;
        //response.CodigoPagamento = result.CodigoPagamento;
        //response.StatusPagamento = result.StatusPagamento;


        response.Id = Guid.Parse("1d5d20eb-c714-4adb-823f-7d78524c0534");
        response.DataVenda = DateTime.Now;
        response.VeiculoId = Guid.Parse("3694fcbd-2ad9-44f5-bf90-257a3892641c");
        response.CpfComprador = "252.912.070-60";
        response.DataVenda = DateTime.Now;
        response.CodigoPagamento = "4325";
        response.StatusPagamento = StatusVenda.Efetivada;

        return response;
    }

    public async Task AtualizarStatusVendaAsync(AtualizarVendaDTORequest request)
    {
        var temVenda = await _repository.ObterVendaPorIdAsync(request.Id);

        if (temVenda == null) { return; }

        await _repository.AtualizarStatusVendaAsync(request.Id, request.StatusPagamento);
    }
}
