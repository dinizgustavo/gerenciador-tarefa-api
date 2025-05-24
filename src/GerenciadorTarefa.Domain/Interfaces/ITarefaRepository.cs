using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorTarefa.Domain.Entities;

namespace GerenciadorTarefa.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        Task<Tarefa> CreateTarefaAsync(Tarefa tarefa);
        Task UpdateTarefaAsync(int id, Tarefa tarefa);
        Task DeleteTarefaAsync(int id);
    }
}
