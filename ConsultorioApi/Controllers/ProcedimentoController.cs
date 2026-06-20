using AutoMapper;
using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedimentoController : ControllerBase
{
    private readonly ConsultorioContext _context;
    private readonly IMapper _mapper;
    
    public ProcedimentoController(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }
    
    [HttpGet]
    public IActionResult ExibirTodosProcedimentos()
    {
        try
        {
            return Ok(_mapper.Map<List<ReadProcedimentoDto>>(_context.Procedimentos.ToList()));
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
        
    }
    [HttpPost]
    public IActionResult AdicionarProcedimento([FromBody] CreateProcedimentoDto procedimentoDto)
    {
        try
        {
            var procedimento = _mapper.Map<Procedimento>(procedimentoDto);
            _context.Procedimentos.Add(procedimento);
            Console.WriteLine(procedimento.Id);

            _context.SaveChanges();
            return CreatedAtAction(nameof(ExibirTodosProcedimentos), new { id = procedimento.Id }, procedimento);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
        
        
    }
    [HttpDelete("{id}")]
    public IActionResult DeletaProcedimento(int id)
    {
        var procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
        if (procedimento == null) return NotFound();
        _context.Remove(procedimento);
        _context.SaveChanges();
        return NoContent();
    }
}