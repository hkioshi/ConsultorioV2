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

    [HttpPost("Tratamento")]
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
     
    [HttpGet("Tratamento")]
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


    [HttpPost("Pagamento")]
    public ActionResult AdicionarPagamento([FromBody] CreatePagamentoDto pagamentoDto)
    {
        try
        {
            var pagamento = _mapper.Map<Pagamentos>(pagamentoDto);
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AdicionarTratamento), new { id = pagamento.Id }, pagamento);

        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
    }

    [HttpGet("Pagamento")]
    public ActionResult ExibirPagamento()
    {

        try
        {
            var pagamento = _mapper.Map<List<ReadPagamentosDto>>(_context.Pagamentos.ToList());
            return Ok(pagamento);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return NotFound(e.Message);
        }
    }



}
