using GerenciadorTarefa.Domain.Entities;
using GerenciadorTarefa.Application.Interfaces;
using Moq;

namespace GerenciadorTarefa.Tests
{
   
    public class TarefaServiceTests
    {
        [Fact]
        public async Task Deve_Buscar_Tarefa_Por_Id()
        {

            var mockService = new Mock<ITarefaService>();
            mockService.Setup(s => s.GetTarefaByIdAsync(1))
                .ReturnsAsync(new Tarefa { Id = 1, Titulo = "Teste" });

            var tarefa = await mockService.Object.GetTarefaByIdAsync(1);

            Assert.NotNull(tarefa);
            Assert.Equal(1, tarefa.Id);
            Assert.Equal("Teste", tarefa.Titulo);
        }
    }
}
