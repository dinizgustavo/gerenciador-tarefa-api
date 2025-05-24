using GerenciadorTarefa.Application.Interfaces;
using Moq;
using Xunit; 

namespace GerenciadorTarefa.Tests
{
    public class DeletarTarefaTest
    {
        [Fact]
        public async Task Deve_Deletar_Tarefa()
        {
            var mockService = new Mock<ITarefaService>();
            mockService.Setup(s => s.DeleteTarefaAsync(1)).Returns(Task.CompletedTask);

            await mockService.Object.DeleteTarefaAsync(1);

            mockService.Verify(s => s.DeleteTarefaAsync(1), Times.Once);
        }
    }
}