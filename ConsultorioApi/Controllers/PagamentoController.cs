using AutoMapper;
using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private ConsultorioContext _context;
    private IMapper _mapper;
    public PagamentoController(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult AdicionarPagamento([FromBody] CreatePagamentoDto pagamentoDto)
    {
        try
        {
            var pagamento = _mapper.Map<Pagamentos>(pagamentoDto);
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AdicionarPagamento), new { id = pagamento.Id }, pagamento);

        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
    }

    [HttpGet]
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

    [HttpPut("{id}")]
    public IActionResult AtualizaPagamento(int id,
    [FromBody] UpdatePagamentoDto pagamentoDto)
    {
        var pagamento = _context.Pagamentos.FirstOrDefault(
            pagamento => pagamento.Id == id);
        if (pagamento == null) return NotFound();
        _mapper.Map(pagamentoDto, pagamento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPagamento(int id)
    {
        var pagamento = _context.Pagamentos.FirstOrDefault(
           pagamento => pagamento.Id == id);
        if (pagamento == null) return NotFound();
        _context.Remove(pagamento);
        _context.SaveChanges();
        return NoContent();
    }

}
