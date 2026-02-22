using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;


namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController: ControllerBase
{
    private ConsultorioContext _context;
    private IMapper _mapper;
    public PacienteController(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
       
    }

    [HttpGet]
    public IActionResult ExibirTodosPacientes()
    {
        try
        {
            return Ok(_mapper.Map<List<ReadPacienteDto>>(_context.Pacientes.ToList()));
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AdicionarPaciente([FromBody] CreatePacienteDto pacienteDto)
    {
        try
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ExibirTodosPacientes), new { id = paciente.Id }, paciente);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPaciente(int id,
    [FromBody] UpdatePacienteDto pacienteDto)
    {
        var paciente = _context.Pacientes.FirstOrDefault(
            paciente => paciente.Id == id);
        if (paciente == null) return NotFound();
        _mapper.Map(pacienteDto, paciente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(
           paciente => paciente.Id == id);
        if (paciente == null) return NotFound();
        _context.Remove(paciente);
        _context.SaveChanges();
        return NoContent();
    }
}



