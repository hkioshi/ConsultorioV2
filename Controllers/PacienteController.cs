using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<ReadPacienteDto> ExibirTodosPacientes()
    {
        return _mapper.Map<List<ReadPacienteDto>>(_context.Pacientes.ToList());
    }
    [HttpPost]
    public IActionResult AdicionarPaciente([FromBody] CreatePacienteDto pacienteDto)
    {
        var paciente = _mapper.Map<Paciente>(pacienteDto);
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirTodosPacientes), new { id = paciente.Id }, paciente);
    }

}
