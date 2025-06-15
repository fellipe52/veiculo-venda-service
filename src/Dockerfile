# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Veiculo.API/Veiculo.API.csproj", "Veiculo.API/"]
COPY ["Veiculo.Application/Veiculo.Application.csproj", "Veiculo.Application/"]
COPY ["Veiculo.Domain/Veiculo.Domain.csproj", "Veiculo.Domain/"]
COPY ["Veiculo.Infrastructure/Veiculo.Infrastructure.csproj", "Veiculo.Infrastructure/"]

# Restaure as dependências
RUN dotnet restore "./Veiculo.API/Veiculo.API.csproj"

# Copiar o restante dos arquivos para o contêiner
COPY . .

# Verifique os arquivos dentro do contêiner (opcional, para depuração)
RUN ls -al /src

# Ajuste o diretório de trabalho para o diretório da API e execute o build
WORKDIR "/src/Veiculo.API"
RUN dotnet build "./Veiculo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build -v detailed

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Veiculo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Veiculo.API.dll"]
