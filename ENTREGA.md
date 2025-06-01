# 🚀 Cooperativa.API

API RESTful para gerenciamento de Cooperativas de Crédito, Cooperados e seus Contatos Favoritos, construída com **.NET 8**, **Entity Framework Core**, **PostgreSQL**, **RabbitMQ** e arquitetura baseada em **DDD / Clean Architecture**.

---

## 📚 Tecnologias

- .NET 8
- Entity Framework Core
- PostgreSQL
- RabbitMQ
- Docker + Docker Compose
- GitHub Actions (CI/CD)
- Swagger (OpenAPI)
- JWT Authentication
- Clean Architecture (Domain-Driven)

---

## 📂 Estrutura do Projeto

```plaintext
src/
  ├── Cooperativa.API/               # API Web (camada de apresentação)
  ├── Cooperativa.Application/       # Orquestração de Casos de uso
  ├── Cooperativa.Domain/            # Casos de uso, Entidades, Aggregates, Use Cases
  ├── Cooperativa.Infrastructure/    # Banco de Dados, RabbitMQ, Serviços externos
```

# 🛠️ Pré-requisitos
- [. NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started/)

# 🐳 Rodando com Docker
    docker-compose up -d

# ⚙️ Deploy

    Variáveis:
    
    AWS_ACCESS_KEY_ID
    AWS_SECRET_ACCESS_KEY
    AWS_REGION
    AWS_ACCOUNT_ID
    ECR_REPOSITORY

# 👥 Usuario 

    Email: teste@teste.com
    Senha: senha123




