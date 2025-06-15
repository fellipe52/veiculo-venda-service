using System.Linq;
using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.UseCase.Veiculo;

namespace Domain.UseCases.Venda
{
    public class VeiculoUseCase : IVeiculoUseCase
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoUseCase(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AdicionarVeiculoAsync(VeiculoDTORequest request)
        {
            Entities.Veiculo veiculo = new Entities.Veiculo();
            veiculo.Marca = request.Marca;
            veiculo.Modelo = request.Modelo;
            veiculo.Ano = request.Ano;
            veiculo.Cor = request.Cor;
            veiculo.Preco = request.Preco;
            veiculo.Status = StatusVeiculo.Disponivel;
            veiculo.DataCadastro = request.DataCadastro;
            veiculo.Ativo = true;

            return await _repository.AdicionarVeiculoAsync(veiculo);
        }

        public async Task AtualizarVeiculoAsync(AtualizarVeiculoDTORequest request)
        {
            Entities.Veiculo veiculo = new Entities.Veiculo();


            var existeVeiculo = await _repository.ObterVeiculoPorIdAsync(request.Id);

            if (existeVeiculo == null) { return; }

            veiculo.Marca = request.Marca;
            veiculo.Modelo = request.Modelo;
            veiculo.Ano = request.Ano;
            veiculo.Cor = request.Cor;
            veiculo.Preco = request.Preco;
            veiculo.Status = request.Status;
            veiculo.DataCadastro = request.DataCadastro;
            veiculo.Ativo = request.Ativo;

            await _repository.AtualizarVeiculoAsync(veiculo);
        }

        public async Task<IEnumerable<VeiculoDTOResponse>> ObterVeiculosAsync()
        {
            var result = await _repository.ObterVeiculosAsync();

            var response = result.Select(v => new VeiculoDTOResponse
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Cor = v.Cor,
                Preco = v.Preco,
                Status = v.Status,
                DataCadastro = v.DataCadastro,
                Ativo = v.Ativo,

            }).ToList();

            return response;
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorIdAsync(Guid id)
        {
            VeiculoDTOResponse response = new VeiculoDTOResponse();

            var result = await _repository.ObterVeiculoPorIdAsync(id);

            response.Id = result.Id;
            response.Marca = result.Marca;
            response.Modelo = result.Modelo;
            response.Ano = result.Ano;
            response.Cor = result.Cor;
            response.Preco = result.Preco;
            response.Status = result.Status;
            response.DataCadastro = result.DataCadastro;
            response.Ativo = result.Ativo;

            return response;
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorMarcaAsync(string marca)
        {
            VeiculoDTOResponse response = new VeiculoDTOResponse();

            var result = await _repository.ObterVeiculoPorMarcaAsync(marca);

            response.Id = result.Id;
            response.Marca = result.Marca;
            response.Modelo = result.Modelo;
            response.Ano = result.Ano;
            response.Cor = result.Cor;
            response.Preco = result.Preco;
            response.Status = result.Status;
            response.DataCadastro = result.DataCadastro;
            response.Ativo = result.Ativo;

            return response;
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorModeloAsync(string modelo)
        {
            VeiculoDTOResponse response = new VeiculoDTOResponse();

            var result = await _repository.ObterVeiculoPorModeloAsync(modelo);

            response.Id = result.Id;
            response.Marca = result.Marca;
            response.Modelo = result.Modelo;
            response.Ano = result.Ano;
            response.Cor = result.Cor;
            response.Preco = result.Preco;
            response.Status = result.Status;
            response.DataCadastro = result.DataCadastro;
            response.Ativo = result.Ativo;

            return response;
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorAnoAsync(int ano)
        {
            VeiculoDTOResponse response = new VeiculoDTOResponse();

            var result = await _repository.ObterVeiculoPorAnoAsync(ano);

            response.Id = result.Id;
            response.Marca = result.Marca;
            response.Modelo = result.Modelo;
            response.Ano = result.Ano;
            response.Cor = result.Cor;
            response.Preco = result.Preco;
            response.Status = result.Status;
            response.DataCadastro = result.DataCadastro;
            response.Ativo = result.Ativo;

            return response;
        }

        public async Task<VeiculoDTOResponse> ObterVeiculoPorCorAsync(string cor)
        {
            VeiculoDTOResponse response = new VeiculoDTOResponse();

            var result = await _repository.ObterVeiculoPorCorAsync(cor);

            response.Id = result.Id;
            response.Marca = result.Marca;
            response.Modelo = result.Modelo;
            response.Ano = result.Ano;
            response.Cor = result.Cor;
            response.Preco = result.Preco;
            response.Status = result.Status;
            response.DataCadastro = result.DataCadastro;
            response.Ativo = result.Ativo;

            return response;
        }

        public async Task<List<VeiculoDTOResponse>> ObterVeiculoPorPrecoAsync(decimal preco)
        {
            var result = await _repository.ObterVeiculoPorPrecoAsync(preco);

            var response = result.Select(v => new VeiculoDTOResponse
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Cor = v.Cor,
                Preco = v.Preco,
                Status = v.Status,
                DataCadastro = v.DataCadastro,
                Ativo = v.Ativo,
            }).ToList();

            return response;
        }

        public async Task DeleteVeiculoAsync(Domain.Entities.Veiculo veiculo)
        {
            var result = await _repository.ObterVeiculoPorIdAsync(veiculo.Id);

            if(result is null) { return; }

            await _repository.DeleteVeiculoAsync(result);
        }

        public async Task<List<VeiculoDTOResponse>> ObterVeiculosDisponiveisOrdenadosAsync()
        {
            var result = await _repository.ObterVeiculosDisponiveisOrdenadosAsync();

            var response = result.Select(v => new VeiculoDTOResponse
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Cor = v.Cor,
                Preco = v.Preco,
                Status = v.Status,
                DataCadastro = v.DataCadastro,
                Ativo = v.Ativo,

            }).ToList();

            return response;
        }

        public async Task<List<VeiculoDTOResponse>> ObterVeiculosVendidosOrdenadosAsync()
        {
            var result = await _repository.ObterVeiculosVendidosOrdenadosAsync();

            var response = result.Select(v => new VeiculoDTOResponse
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Cor = v.Cor,
                Preco = v.Preco,
                Status = v.Status,
                DataCadastro = v.DataCadastro,
                Ativo = v.Ativo,

            }).ToList();

            return response;
        }
    }
}   