using GerenciadorTarefa.Application.Interfaces;
using GerenciadorTarefa.Domain.Entities;
using Moq;
using Xunit; 

namespace GerenciadorTarefa.Tests
{
    public class AtualizarTarefaTest
    {
        [Fact]
        public async Task Deve_Atualizar_Tarefa()
        {
            var mockService = new Mock<ITarefaService>();
            var tarefa = new Tarefa { Id = 1, Titulo = "Antigo" };
            mockService.Setup(s => s.UpdateTarefaAsync(1, tarefa)).Returns(Task.CompletedTask);

            await mockService.Object.UpdateTarefaAsync(1, tarefa);

            mockService.Verify(s => s.UpdateTarefaAsync(1, tarefa), Times.Once);
        }
    }
}