# Gerenciador de Tarefas - Backend (.NET 9)

Este é o backend de um sistema de gerenciamento de tarefas, desenvolvido em .NET 9 como parte de um teste técnico. A API permite criar, listar, editar e excluir tarefas, utilizando persistência em banco de dados SQL Server.

---

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (LocalDB, Express ou outro)
- Visual Studio 2022+ ou VS Code

---

## Como rodar o projeto localmente

### 1. Clone o repositório

```bash
git clone https://github.com/dinizgustavo/gerenciador-tarefa-api.git
cd GerenciadorTarefa-api
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Configure a string de conexão

Abra o arquivo `src/GerenciadorTarefa.API/appsettings.json` e edite a seção abaixo conforme seu ambiente:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TarefaDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Se necessário, adicione `User ID` e `Password`.

### 4. Inicie a API

```bash
dotnet run --project src/GerenciadorTarefa.API
```

- O banco de dados será criado automaticamente na primeira execução, via EF Core.

### 5. Acesse a documentação Swagger

Acesse pelo navegador:

```
http://localhost:5173/swagger
```

---

## Rodando os testes

Execute os testes com:

```bash
dotnet test
```

---

## Scripts úteis

| Comando                                      | Descrição                                  |
|---------------------------------------------|--------------------------------------------|
| `dotnet run --project src/GerenciadorTarefa.API` | Inicia a API em modo desenvolvimento       |
| `dotnet test`                                | Executa os testes unitários                |
| `dotnet ef migrations add NomeDaMigracao`    | Cria uma nova migração (EF Core)           |
| `dotnet ef database update`                  | Aplica a migração no banco de dados        |

> Para usar os comandos do `ef`, instale o pacote `Microsoft.EntityFrameworkCore.Tools`.

---

## Estrutura do Projeto

```
GerenciadorTarefa-api/
├── src/
│   ├── GerenciadorTarefa.API             → Controllers, middlewares e configuração
│   ├── GerenciadorTarefa.Application     → Lógica de aplicação (serviços, DTOs)
│   ├── GerenciadorTarefa.Domain          → Entidades e contratos de domínio
│   └── GerenciadorTarefa.Infrastructure  → Persistência de dados (EF Core)
├── GerenciadorTarefa.Tests/              → Testes unitários
└── README.md
```

---

## Observações

- O banco é criado automaticamente ao iniciar a API (via migrations automáticas).
- A ordem recomendada de execução é: **backend primeiro, frontend depois** — isso garante o uso correto das portas.
- O Swagger oferece uma interface gráfica para testes rápidos dos endpoints.

---

## Contato

Dúvidas ou sugestões?  
Entre em contato por e-mail: dinizgustavo92@gmail.com

---

**Bom teste!**
