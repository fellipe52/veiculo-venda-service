# Axis Challenge Backend Developer

<p align="center">
   <a href="#-introducao">Introdução</a> •
   <a href="#-cenario">Cenário</a> •
   <a href="#-regras-do-negocio">Regras do Negócio</a> •
   <a href="#-funcionalidades">Funcionalidades</a> •
   <a href="#-instrucoes-e-sugestoes">Instruções & Sugestões</a> •
   <a href="#-diferenciais">Diferenciais</a> •
   <a href="#-documentacao-organizacao-e-entrega">Documentação, Organização & Entrega</a> •
   <a href="#-duvidas">Dúvidas</a>
</p>

## 📚 Introdução

Este é um desafio `Hands-On` que tem como objetivo testar suas habilidades como `Backend Developer` com conhecimentos intermediários em `DevOps`. O desafio faz parte do processo seletivo da [Axis Mobfintech](https://axis-mobfintech.com/).

## 🚀 Cenário

Você deverá desenvolver uma `REST API` que permita que cooperados de uma Cooperativa de Crédito mantenham uma lista de **Contatos Favoritos** associados à conta corrente da cooperativa.

## 🎯 Regras do Negócio

Cada contato favorito deve conter:

- Identificação do registro;
- Nome do contato;
- Tipo de chave Pix:
  - Apenas: CPF, CNPJ, E-mail, Telefone ou Chave Aleatória;
- Chave Pix.

A cooperativa deve permitir o cadastro de:

- Cooperativas (com nome e código);
- Cooperados (com nome e conta corrente);
- Contatos Favoritos (vinculados a um cooperado e sua conta corrente).

## ⚙️ Funcionalidades

A API deve fornecer serviços REST para:

- CRUD (Create, Read, Update, Delete) de **Cooperativas** (exclusão lógica);
- CRUD de **Cooperados** (exclusão lógica);
  - A pesquisa pode ser feita pelo **número da conta corrente**, **nome do cooperado** ou **filtros combinados**;
- CRUD de **Contatos Favoritos** (exclusão física);
- Implementação de **paginação e ordenação** nas consultas;
- Retorno padronizado de erros e mensagens para o cliente.

## 📌 Instruções e Sugestões

Espera-se que:

- O backend seja desenvolvido em **C# e .NET 8** (ou superior);
- Seja utilizado um **banco de dados relacional** como **PostgreSQL** ou **SQL Server**;
- A persistência seja implementada utilizando **Entity Framework Core** e **migrations**;
- A API seja documentada utilizando **Swagger/OpenAPI 3.0**;
- O sistema utilize **validação de dados** no backend;
- Padronização das mensagens de erro e sucesso da API;
- Os endpoints sigam as boas práticas de **RESTful APIs**;
- Implementação de **autenticação e autorização** utilizando JWT ou OAuth2;
- Aplicação de princípios de **SOLID e Clean Code**;
- A API seja capaz de lidar com **concorrência e transações**.

## 💡 Diferenciais (itens opcionais)

- Utilização de padrões arquiteturais como **DDD, Clean Architecture ou Hexagonal**;
- Implementação de **Testes Unitários, Testes de Integração e Testes de Carga**;
- Uso de **RabbitMQ, Kafka ou outra solução de mensageria** para comunicação assíncrona;
- Configuração de **Docker** e **Docker Compose** para facilitar a execução local;
- Configuração de um pipeline de **CI/CD** básico utilizando GitHub Actions ou outra ferramenta;
- Deploy automatizado para um ambiente cloud (exemplo: AWS, Azure ou GCP);
- Configuração de **monitoramento** com Prometheus, Grafana ou outra ferramenta;
- Implementação de **cache** para otimizar consultas;
- Configuração de logs estruturados e centralizados com ELK Stack, Datadog ou outro serviço.

## ✔️ Documentação, Organização e Entrega
- Para a entrega abra um `Pull Request` para a branch `main` para análise e possível aprovação.
- Crie um arquivo `ENTREGA.md` contendo:
  - Tecnologias utilizadas;
  - Instruções para rodar o projeto localmente;
  - Instruções para rodar o projeto com Docker (se aplicável);
  - Como executar os testes (se houver);
  - Configuração de ambiente para desenvolvimento e produção;
- Adicionar um `.gitignore` adequado para o projeto;
- O **prazo limite para entrega deste desafio termina em 24/04/2025 às 23h59min**.
  - ***Obs.**: as entregas realizadas após este limite não serão validadas. Apenas os commits feitos até o prazo estabelecido.*
  - ***Obs2.**: prazo estendido até 28/04/2025 às 23h59min.*


## ❓ Dúvidas?

Se tiver qualquer dúvida, entre em contato abrindo uma **Issue** no repositório do desafio.

Boa sorte! 🚀
