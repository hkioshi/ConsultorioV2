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
    public Task<ActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetPacienteDto>>> GetAll() =>
       Ok(await _service.GetAll());
    

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetPacienteDto>> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public Task<ActionResult> Modify(int id, [FromBody] ModifyPacienteDto obj)
    {
        throw new NotImplementedException();
    }

    
}

