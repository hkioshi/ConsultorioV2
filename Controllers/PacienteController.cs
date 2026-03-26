using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Services;
using Microsoft.AspNetCore.Mvc;
namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController: ControllerBase
{
    private readonly PacienteService _service;
    public PacienteController(PacienteService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> ExibirTodosPacientesAsync()
    {
        var pacientes = await _service.ExibirPacientesServiceAsync();

        return pacientes == null || !pacientes.Any() ?
            NotFound("Nenhum paciente encontrado"):
            Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ExibirPacientePorId(int id)
    {
        var paciente = await _service.ExibirPacientePorIdServiceAsync(id);

        return paciente is null ?
            NotFound() :
            Ok(paciente);
    }

    [HttpPost]
    public  async Task<IActionResult> AdicionarPacienteAsync ([FromBody] CreatePacienteDto pacienteDto)
    {
        try
        {
            var paciente = await _service.AdicionarPacienteServiceAsync(pacienteDto);

            return CreatedAtAction(
               nameof(ExibirPacientePorId),
                new { 
                    id = paciente.Id 
                },
                paciente
            );
        }
        catch
        {
            return BadRequest("Nenhum paciente encontrado");
        } 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPacienteAsync(int id, [FromBody] UpdatePacienteDto pacienteDto) => 
        await _service.AtualizarPacienteServiceAsync(id, pacienteDto) ? 
            NoContent() : 
            NotFound();
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPacienteAsync(int id) =>
        await _service.DeletarPacienteServiceAsync(id) ?
            NoContent() : 
            NotFound();

}



