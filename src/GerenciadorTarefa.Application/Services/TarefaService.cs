using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorTarefa.Application.Interfaces;
using GerenciadorTarefa.Domain.Entities;
using GerenciadorTarefa.Domain.Interfaces;

namespace GerenciadorTarefa.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Tarefa> CreateTarefaAsync(Tarefa tarefa)
        {
            return await _repository.CreateTarefaAsync(tarefa);
        }
        public async Task DeleteTarefaAsync(int id)
        {
            await _repository.DeleteTarefaAsync(id);
        }
        public async Task<List<Tarefa>> GetAllTarefasAsync()
        {
            return await _repository.GetAllTarefasAsync();
        }
        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
           return await _repository.GetTarefaByIdAsync(id);
        }
        public Task UpdateTarefaAsync(int id, Tarefa tarefa)
        {
            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao < tarefa.DataCriacao)
                throw new ArgumentException("Data de conclusão não pode ser anterior à data de criação.");

            return _repository.UpdateTarefaAsync(id, tarefa);
        }
    }
}
