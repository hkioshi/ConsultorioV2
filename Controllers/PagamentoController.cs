using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Services;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult> ExibirPagamentosAsync()
    {
        var pagamentos = await _service.ExibirPagamentosServiceAsync();
        return pagamentos is not null ?
            Ok(pagamentos) :
            BadRequest();
    }

    [HttpGet("{id}")]
    [ActionName("ExibirPagamentosPorId")]
    public async Task<IActionResult> ExibirPagamentosPorIdAsync(int id)
    {
        var pagamentosDto = await _service.ExibirPagamentoPorIdServiceAsync(id);

        return pagamentosDto is null ?
            BadRequest() :
            Ok(pagamentosDto);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPagamentoAsync([FromBody] CreatePagamentoDto pagamentoDto)
    {
        try
        {
            var pagamento = await _service.AdicionarPagamentosServiceAsync(pagamentoDto);

            return Created();  
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                erro = ex.Message,
                inner = ex.InnerException?.Message
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaPagamentoAsync(int id,
    [FromBody] UpdatePagamentoDto pagamentoDto) =>
        await _service.AtualizarPagamentoServiceAsync(id, pagamentoDto) ? 
            NoContent() :
            NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaPagamentoAsync(int id) =>
        await _service.DeletarPagamentosServiceAsync(id) ?
            NoContent() :
            NotFound();

}
