using GerenciadorTarefa.Domain.Entities;
using GerenciadorTarefa.Domain.Enums;
using Xunit;

namespace GerenciadorTarefa.Tests
{
    public class TarefaTests
    {
        [Fact]
        public void Deve_Criar_Tarefa_Com_Valores_Padrao()
        {
            var tarefa = new Tarefa
            {
                Titulo = "Teste",
                Descricao = "Descrição de teste"
            };

            Assert.Equal("Teste", tarefa.Titulo);
            Assert.Equal("Descrição de teste", tarefa.Descricao);
            Assert.Equal(TarefaStatus.Pendente, tarefa.Status);
            Assert.True((DateTime.UtcNow - tarefa.DataCriacao).TotalSeconds < 5);
            Assert.Null(tarefa.DataConclusao);
        }
    }
}
