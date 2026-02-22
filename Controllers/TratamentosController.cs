using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class TratamentosController : ControllerBase
{
    private ConsultorioContext _context;
    private IMapper _mapper;
    public TratamentosController(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult AdicionarTratamento([FromBody] CreateTratamentoDto tratamentoDto)
    {
        try
        {
            var tratamento = _mapper.Map<Tratamento>(tratamentoDto);
            _context.Tratamentos.Add(tratamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AdicionarTratamento), new { id = tratamento.Id }, tratamento);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
    }

    [HttpGet]
    public ActionResult ExibirTratamentos()
    {

        try
        {
            var tratamentos = _mapper.Map<List<ReadTratamentosDto>>(_context.Tratamentos.ToList());
            return Ok(tratamentos);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaTratamento(int id,
    [FromBody] UpdateTratamentoDto tratamentoDto)
    {
        var tratamento = _context.Tratamentos.FirstOrDefault(
            tratamento => tratamento.Id == id);
        if (tratamento == null) return NotFound();
        _mapper.Map(tratamentoDto, tratamento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaTratamento(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(
           paciente => paciente.Id == id);
        if (paciente == null) return NotFound();
        _context.Remove(paciente);
        _context.SaveChanges();
        return NoContent();
    }

}
