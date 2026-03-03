using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using ConsultorioV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Controllers;
[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private readonly PagamentoService _service;

    public PagamentoController(PagamentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> ExibirPagamentos()
    {
        var pagamentos = await _service.GetAllPagamentos();

        return pagamentos == null || !pagamentos.Any() ?
            NotFound("Nenhum paciente encontrado") :
            Ok(pagamentos);            
    }

    [HttpPost]
    public ActionResult AdicionarPagamento([FromBody] CreatePagamentoDto pagamentoDto)
    {
        var pagamento = _service.AddPagamentosAsync(pagamentoDto);
        return pagamento is null ?
        NotFound("Nenhum paciente encontrado") :
        CreatedAtAction(
            nameof(AdicionarPagamento),
            new
            {
                id = pagamento.Id
            },
            pagamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaPagamento(int id,
    [FromBody] UpdatePagamentoDto pagamentoDto) =>
        await _service.UpdatePagamentosAsync(id, pagamentoDto) ? 
            NoContent() :
            NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaPagamento(int id) =>
        await _service.DeletePagamentosAsync(id) ?
            NoContent() :
            NotFound();

}
