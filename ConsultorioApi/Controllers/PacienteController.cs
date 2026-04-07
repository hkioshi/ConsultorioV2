using AutoMapper;
using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase
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

    [HttpGet("BuscarPorId/{id}")]
    public IActionResult PacientePorId(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadPacienteDto>(_context.Pacientes.FirstOrDefault(i => i.Id.Equals(id))));
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }


    }

    [HttpGet("BuscarPorNome/{Nome}")]
    public IActionResult AcharPorNome(string Nome)
    {
        try
        {
            return Ok(_mapper.Map<List<ReadPacienteDto>>(_context.Pacientes.Where(i => i.Nome.Contains(Nome))));
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
    }

    [HttpGet("BuscarPorCPF/{CPF}")]
    public IActionResult AcharPorCPF(string CPF)
    {
        try
        {
            return Ok(_mapper.Map<List<ReadPacienteDto>>(_context.Pacientes.Where(i => i.Cpf.Contains(CPF))));
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
            Console.WriteLine(paciente.Id);

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
    public IActionResult DeletaPaciente(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(
           paciente => paciente.Id == id);
        if (paciente == null) return NotFound();
        _context.Remove(paciente);
        _context.SaveChanges();
        return NoContent();
    }
}



