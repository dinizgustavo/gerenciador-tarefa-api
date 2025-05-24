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
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllTarefasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetTarefaByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.CreateTarefaAsync(tarefa);
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest("ID não confere.");
        await _service.UpdateTarefaAsync(id, tarefa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteTarefaAsync(id);
        return NoContent();
    }
}