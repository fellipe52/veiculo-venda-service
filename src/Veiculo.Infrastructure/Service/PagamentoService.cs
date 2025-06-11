using System.Text;
using Domain.Contracts;
using Newtonsoft.Json;
using Veiculo.Domain.Interfaces.Service;

namespace Veiculo.Infrastructure.Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PagamentoService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<TransactionsResponse> CriarTransacaoAsync(TransactionsRquest request)
        {
            TransactionsResponse? response = null;
            var url = $"{_baseUrl}/Pagamento/Efeturar/Transacao";
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(url, content);
            var responseBody = await result.Content.ReadAsStringAsync();

            response = JsonConvert.DeserializeObject<TransactionsResponse>(responseBody);

            if (!result.IsSuccessStatusCode)
            {
                return response;
            }

            return response;
        }
    }
}