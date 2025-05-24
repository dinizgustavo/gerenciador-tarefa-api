# Gerenciador de Tarefas - Backend (.NET 9)

Este é o backend do teste para vaga de desenvolvedor, feito em .NET 9, que permite criar, editar, listar e excluir tarefas, com persistência em SQL Server.

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (pode ser LocalDB, Express ou outro)
- Visual Studio 2022+ ou VS Code

## Como rodar o projeto

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/dinizgustavo/gerenciador-tarefa-api.git
   cd GerenciadorTarefa-api
   ```

2. **Restaure as dependências:**

   ```bash
   dotnet restore
   ```

3. **Configure a string de conexão:**

   - No arquivo `src/GerenciadorTarefa.API/appsettings.json`, ajuste a string de conexão conforme seu ambiente SQL Server:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=TarefaDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```

   - Se necessário, altere usuário, senha ou nome do servidor.

4. **Inicie a API:**

   ```bash
   dotnet run --project src/GerenciadorTarefa.API
   ```

   - O banco de dados será criado automaticamente ao rodar a API pela primeira vez.

5. **Acesse a documentação Swagger:**

   ```
   http://localhost:5173/swagger
   ```

   - Use o Swagger para testar os endpoints diretamente pelo navegador.

## Observações

- Não é necessário rodar comandos de migração manualmente: o banco será criado automaticamente.
- O backend espera que o SQL Server esteja disponível e acessível conforme a string de conexão.
- O projeto já está pronto para uso local, mas pode ser facilmente adaptado para produção.

## Scripts úteis

- `dotnet run --project src/GerenciadorTarefa.API` — inicia a API em modo desenvolvimento
- `dotnet test` — executa os testes unitários

## Estrutura do Projeto

- `src/GerenciadorTarefa.API` — API REST (controllers, middlewares)
- `src/GerenciadorTarefa.Application` — Lógica de aplicação (serviços, DTOs)
- `src/GerenciadorTarefa.Domain` — Entidades e interfaces de domínio
- `src/GerenciadorTarefa.Infrastructure` — Persistência de dados (EF Core, repositórios)
- `GerenciadorTarefa.Tests` — Testes unitários

## Contato

Dúvidas ou problemas? Entre em contato:  
[Gustavo Diniz] — [dinizgustavo92@gmail.com]

---

**Bom teste!**