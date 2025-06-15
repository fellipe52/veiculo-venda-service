#  Veiculo-Venda API

API RESTful para efetuação de vendas de veiculo, Cooperados e seus cadastros de veiculo **.NET 8**, **Entity Framework Core**, **PostgreSQL** e arquitetura baseada em **DDD / Clean Architecture**.

---


# Pré-requisitos
- [. NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started/)
- [Azure Cloud](https://portal.azure.com/)
  - Grupo de Recursos
  - Container Registry
  - AKS
  - Azure Cosmos DB for PostgreSQL Cluster
#  Rodando com Docker
    Pasta src -> docker-compose up -d

#  Deploy
    #  Deploy
    Criar perfil Git:
    
    az ad sp create-for-rbac --name "my-github-actions" --role contributor --scopes /subscriptions/{sua-subscription}/resourceGroups/veiculo --query "{client_id: appId, client_secret: password, tenant_id: tenant}"

    Variáveis Git:
    
    AZURE_CREDENTIALS

    Deployment:
    deploy -> Contém arquivos deployment, service e secrets

    WorkFlows:
    .github/workflows -> Contém arquivos build .net e execução dos arquivos de deploy no azure cloud.
