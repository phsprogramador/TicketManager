# Ticket Manager API

## 📝 Descrição

Este projeto é uma **API para gerenciamento de tickets**, desenvolvida como parte de um estudo sobre boas práticas de desenvolvimento de software, arquitetura de sistemas e integração contínua. O objetivo principal é explorar tecnologias modernas e práticas como **Domain-Driven Design (DDD)**, **Test-Driven Development (TDD)**, **Docker**, **GitHub Actions** e **Entity Framework Core**.

---

## 🚀 Funcionalidades

- **Gerenciamento de Tickets**:
  - Criar, consultar, atualizar e excluir tickets.
  - Associar tickets a usuários e responsáveis.
  - Definir status para os tickets.

- **Gerenciamento de Usuários**:
  - Criar, consultar, atualizar e excluir usuários.
  - Associar usuários a tickets (criador e responsável).

- **Testes**:
  - Testes unitários e de integração com **xUnit** e **Moq**.
  - Cobertura de testes monitorada com **SonarCloud**.

---

## 🛠 Tecnologias Utilizadas

### Backend
- **.NET 8**: Framework principal para desenvolvimento da API.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **SQL Server**: Banco de dados relacional para armazenamento de dados.
- **Docker**: Containerização da aplicação e do banco de dados.
- **GitHub Actions**: Automação de CI/CD (Integração Contínua/Entrega Contínua).
- **xUnit**: Framework para testes unitários.
- **Moq**: Biblioteca para mockar dependências em testes.
- **SonarCloud**: Geração de relatórios de cobertura de código.

### Ferramentas
- **Visual Studio 2022**: IDE para desenvolvimento.
- **Postman**: Testes de endpoints da API.
- **Git**: Controle de versão.

---

## 🏗 Estrutura do Projeto

O projeto está organizado em camadas seguindo o **Domain-Driven Design (DDD)**:

- **Domain**:
  - Contém as entidades, interfaces de repositório e regras de negócio.
  - Exemplo: `Status`, `Ticket`, `User`.

- **Infrastructure**:
  - Implementação de repositórios, configuração do `DbContext` e migrações.
  - Exemplo: `StatusRepository`, `TicketRepository`, `UserRepository`, `AppDbContext`.

- **Application**:
  - Contém os serviços, DTOs e casos de uso.
  - Exemplo: `StatusService`, `TicketService`, `UserService`.

- **API**:
  - Camada de apresentação, com controllers e endpoints.
  - Exemplo: `StatusController`, `TicketsController`, `UsersController`.

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ou use o contêiner Docker)

### Passos para Execução

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/phsprogramador/TicketManager.git
   cd ticket-manager-api# TicketManager
