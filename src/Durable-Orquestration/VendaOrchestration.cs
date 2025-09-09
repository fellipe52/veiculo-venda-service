using Domain.Contracts;
using Domain.DTOs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace VeiculoVenda.Orchestration
{
    public static class VendaOrchestration
    {
        // Orquestrador da Saga
        [Function(nameof(VendaOrchestrator))]
        public static async Task<string> VendaOrchestrator(
    [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            var logger = context.CreateReplaySafeLogger(nameof(VendaOrchestrator));

            try
            {
                var request = context.GetInput<VendaRequest>();

                // 1. Criar/validar cliente
                var clienteId = await context.CallActivityAsync<string>(
                    nameof(AtividadeCriarCliente), request.Cliente);

                // 2. Reservar veículo
                var reservaId = await context.CallActivityAsync<string>(
                    nameof(AtividadeReservarVeiculo), request.VeiculoId);

                // 3. Processar pagamento
                var pagamentoId = await context.CallActivityAsync<string>(
                    nameof(AtividadeProcessarPagamento), new { ClienteId = clienteId, VeiculoId = request.VeiculoId });


                return $"Venda concluída: Cliente={clienteId}, Veículo={request.VeiculoId}, Pagamento={pagamentoId}";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro no fluxo de venda, iniciando compensação...");

                // Compensações
                await context.CallActivityAsync(nameof(AtividadeCancelarReserva), null);
                await context.CallActivityAsync(nameof(AtividadeEstornarPagamento), null);

                throw;
            }
        }



        [Function(nameof(AtividadeCriarCliente))]
        public static async Task<Guid> AtividadeCriarCliente(
            [ActivityTrigger] ClienteDto cliente,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(AtividadeCriarCliente));
            var httpClientFactory = executionContext.InstanceServices.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();

            try
            {
                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.PostAsJsonAsync("http://clientes-service/api/clientes", cliente);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Guid>();
                logger.LogInformation("Cliente criado com ID {Id}", result);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao criar cliente");
                throw;
            }
        }

        [Function(nameof(AtividadeReservarVeiculo))]
        public static async Task<Guid> AtividadeReservarVeiculo(
            [ActivityTrigger] VendaDTORequest vendaRequest,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(AtividadeReservarVeiculo));
            var httpClientFactory = executionContext.InstanceServices.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();

            try
            {
                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.PostAsJsonAsync("http://veiculo-venda-api/api/venda/ComprarVeiculo", vendaRequest);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Guid>();
                logger.LogInformation("Veículo reservado com ID {Id}", result);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao reservar veículo");
                throw;
            }
        }

        [Function(nameof(AtividadeProcessarPagamento))]
        public static async Task<TransactionsResponse> AtividadeProcessarPagamento(
            [ActivityTrigger] TransactionsRquest transactionsRequest,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(AtividadeProcessarPagamento));
            var httpClientFactory = executionContext.InstanceServices.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();

            try
            {
                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.PostAsJsonAsync("http://pagamento-service/api/pagamentos", transactionsRequest);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<TransactionsResponse>();
                logger.LogInformation("Pagamento processado com ID {Id}", result);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao processar pagamento");
                throw;
            }
        }


        [Function(nameof(AtividadeCancelarReserva))]
        public static async Task AtividadeCancelarReserva([ActivityTrigger] object _, FunctionContext context)
        {
            var logger = context.GetLogger(nameof(AtividadeCancelarReserva));
            var httpClientFactory = context.InstanceServices.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();

            logger.LogWarning("Cancelando reserva do veículo...");
            await client.PostAsync("http://veiculo-venda-api/api/veiculos/cancelar-reserva", null);
        }

        [Function(nameof(AtividadeEstornarPagamento))]
        public static async Task AtividadeEstornarPagamento([ActivityTrigger] object _, FunctionContext context)
        {
            var logger = context.GetLogger(nameof(AtividadeEstornarPagamento));
            var httpClientFactory = context.InstanceServices.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();

            logger.LogWarning("Estornando pagamento...");
            await client.PostAsync("http://pagamento-service/api/pagamentos/estornar", null);
        }
    }

    public record VendaRequest(string VeiculoId, ClienteDto Cliente);
    public record ClienteDto(string Nome, string Documento, string Email);
}
