using GerenciadorTarefa.Application.DTOs;
using GerenciadorTarefa.Application.Interfaces;
using GerenciadorTarefa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefasController(ITarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tarefas = await _service.GetAllTarefasAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var tarefa = await _service.GetTarefaByIdAsync(id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTarefaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var tarefa = new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
        };

        var novaTarefa = await _service.CreateTarefaAsync(tarefa);

        return CreatedAtAction(nameof(Get), new { id = novaTarefa.Id }, novaTarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateTarefaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var tarefaExistente = await _service.GetTarefaByIdAsync(id);
        if (tarefaExistente == null) return NotFound();

        tarefaExistente.Titulo = dto.Titulo;
        tarefaExistente.Descricao = dto.Descricao;
        tarefaExistente.DataConclusao = dto.DataConclusao;
        tarefaExistente.Status = dto.Status;

        await _service.UpdateTarefaAsync(id, tarefaExistente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tarefaExistente = await _service.GetTarefaByIdAsync(id);
        if (tarefaExistente == null) return NotFound();

        await _service.DeleteTarefaAsync(id);
        return NoContent();
    }
}
