using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using ConsultorioV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConsultorioV2.Controllers;
[ApiController]
[Route("[controller]")]
public class  ProntuarioController : ControllerBase
{
    private readonly ProntuarioService _service;
    public ProntuarioController(ProntuarioService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> AdicionarProntuarioAsync([FromBody] CreateProntuarioDto ProntuarioDto)
    {
        var paciente = await _service.AdicionarProntuarioServiceAsync(ProntuarioDto);

        return paciente is null ?
            BadRequest("Nenhum paciente encontrado") :
            CreatedAtAction(
                nameof(ExibirPagamentosPorId),
                new
                {
                    id = paciente.Id
                },
                paciente);

    }

    [HttpGet("{id}/Pagamentos")]
    public async Task<IActionResult> ExibirPagamentosPorId(int id)
    {
       var pagamentos = await _service.ExibirPagamentosPorIdServiceAsync(id);
       return pagamentos is null ?
            BadRequest("Nenhum Pagamento encontrado") :
            Ok(pagamentos);    
    }   

    [HttpGet("{id}/Tratamentos")]
    public async Task<IActionResult> ExibirTratamentosPorId(int id)
    {
        var tratamentos = await _service.ExibirTratamentosPorIdServiceAsync(id);
        return tratamentos is null ?
             BadRequest("Nenhum Pagamento encontrado") :
             Ok(tratamentos);
    }

    [HttpGet]
    public async Task<IActionResult> ExibirProntuario()
    {

        var prontuario = await _service.ExibirProntuariosServiceAsync();
        return prontuario is null ?
             BadRequest("Nenhum Prontuario encontrado") :
             Ok(prontuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ExibirProntuarioPorId(int id)
    {
        var prontuario = await _service.ExibirProntuarioPorIdServiceAsync(id);
        return prontuario is null ?
             BadRequest("Nenhum Prontuario encontrado neste id") :
             Ok(prontuario);

    }       

    [HttpGet("porNome/{nome}")]
    public async Task<IActionResult> ExibirProntuarioPorNome(string nome)
    {
        var prontuario = await _service.ExibirProntuarioPorNomeServiceAsync(nome);
        return prontuario is null ?
             BadRequest("Nenhum Prontuario encontrado neste nome") :
             Ok(prontuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaProntuario(int id) =>
        await _service.DeletarProntuarioServiceAsync(id) ?
            NoContent() :
            BadRequest(); 
            

    [HttpGet("{id}/valorDevido")]
    public async Task<IActionResult> ExibirValorDevido(int id)
    {           
        double? valorDevido = await _service.ExibirValoresServiceAsync(id);
        return valorDevido is null ?
            BadRequest("Nenhum Prontuario encontrado neste nome") :
            Ok(new { ValorDevido = valorDevido});

    }
}
