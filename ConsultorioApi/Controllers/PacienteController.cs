using ConsultorioApi.Controllers.Interfaces;
using ConsultorioApi.Data.Dtos.Pacientes;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase, IController<Paciente, GetPacienteDto, AddPacienteDto, ModifyPacienteDto>
{
    PacienteService _service;
    public PacienteController(PacienteService service)
    {
        _service = service;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Paciente>> Add([FromBody] AddPacienteDto obj) 
    {   
        var paciente = await _service.Add(obj);
        return CreatedAtAction(
            nameof(GetById),
            new { id = paciente.Id },
            paciente
        );
        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch(NotFoundException)
        {
            return BadRequest();
        }
        
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetPacienteDto>>> GetAll() =>
       Ok(await _service.GetAll());
    

    [HttpGet("byCpf/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetPacienteDto>> GetByCpf(string cpf)
    {
        try
        {
            return Ok(await _service.GetByCpf(cpf));
        }
        catch(NotFoundException)
        {
            return BadRequest();
        }
        
    }
    [HttpGet("byName/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetPacienteDto>>> GetByName(string name)
    {
        try
        {
            return Ok(await _service.GetByName(name));
        }
        catch(NotFoundException)
        {
            return BadRequest();
        }
        
    }

    [HttpGet("by{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetPacienteDto>> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch(NotFoundException)
        {
            return BadRequest();
        }
        
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Modify(int id, ModifyPacienteDto obj)
    {
         Console.WriteLine($"ID: {id}");
        Console.WriteLine($"DTO: {obj}");

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState)
            {
                Console.WriteLine($"Campo: {error.Key}");

                foreach (var e in error.Value!.Errors)
                    Console.WriteLine($"Erro: {e.ErrorMessage}");
            }

            return BadRequest(ModelState);
        }

        await _service.Modify(id, obj);

        return NoContent();
    }
}

