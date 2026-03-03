using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Services;
using Microsoft.AspNetCore.Mvc;
namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController: ControllerBase
{
    private readonly PacienteService _service;

    public PacienteController(PacienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ExibirTodosPacientesAsync()
    {
        var pacientes = await _service.GetAllPacientesAsync();

        return pacientes == null || !pacientes.Any() ?
            NotFound("Nenhum paciente encontrado"):
            Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ExibirPacientePorId(int id)
    {
        var paciente = await _service.GetPacienteByIdAsync(id);

        return paciente is null ?
            NotFound() :
            Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPacienteAsync ([FromBody] CreatePacienteDto pacienteDto)
    {
        var paciente = await _service.AddPacienteAsync(pacienteDto);

        return paciente is null ? 
            NotFound("Nenhum paciente encontrado") : 
            CreatedAtAction(
                nameof(ExibirTodosPacientesAsync), 
                new {
                    id = paciente.Id 
                }, 
                paciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPacienteAsync(int id, [FromBody] UpdatePacienteDto pacienteDto) => 
        await _service.UpdatePacienteAsync(id, pacienteDto) ? 
            NoContent() : 
            NotFound();
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPacienteAsync(int id) =>
        await _service.DeletePacienteAsync(id) ?
            NoContent() : 
            NotFound();

}



