using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers;
[ApiController]
[Route("[controller]")]
public class ProntuarioController : ControllerBase
{
    private ConsultorioContext _context;
    private IMapper _mapper;
    public ProntuarioController(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarProntuario([FromBody] CreateProntuarioDto ProntuarioDto)
    {
        try
        {
            var prontuario = _mapper.Map<Prontuario>(ProntuarioDto);
            _context.Prontuarios.Add(prontuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AdicionarProntuario), new { id = prontuario.Id }, prontuario);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }

    }

    [HttpGet]
    public IActionResult ExibirProntuario()
    {
        try
        {
            var Prontuario = _mapper.Map<List<ReadProntuarioDto>>(_context.Prontuarios.ToList());
            return Ok(Prontuario);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult ExibirProntuarioPorId(int id)
    {
        try
        {
            var Prontuario = _mapper.Map<ReadProntuarioDto>(_context.Prontuarios.FirstOrDefault(p => p.Id.Equals(id)));
            return Ok(Prontuario);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
        
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaProntuario(int id)
    {
        var prontuario = _context.Prontuarios.FirstOrDefault(
           prontuario => prontuario.Id == id);
        if (prontuario == null) return NotFound();
        _context.Remove(prontuario);
        _context.SaveChanges();
        return NoContent();
    }

}
