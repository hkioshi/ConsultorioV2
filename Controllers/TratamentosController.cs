using AutoMapper;
using ConsultorioV2.Services;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class TratamentosController : ControllerBase
{
    private readonly TratamentoService _service;
    public TratamentosController(TratamentoService service) => _service = service;


    [HttpPost]
    public async Task<IActionResult> AdicionarTratamento([FromBody] CreateTratamentoDto tratamentoDto)
    {
        try
        {
            var tratamento = await _service.AdicionarTratamentoServiceAsync(tratamentoDto);
            return CreatedAtAction(nameof(AdicionarTratamento), new { id = tratamento.Id }, tratamento);
        }
        catch (Exception e)
        {
            //Implementar Erros
            Console.WriteLine($"O erro foi: {e.Message}");
            return Problem(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ExibirTratamentoPorIdAsync(int id)
    {
        var tratamento = await _service.ExibirTratamentoPorIdServiceAsync(id);

        return tratamento is null ?
            NotFound() :
            Ok(tratamento);
    }


    [HttpGet]
    public async Task<IActionResult> ExibirTratamentos() =>
        Ok( await _service.ExibirTratamentosServiceAsync());


    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaTratamentoAsync(int id, [FromBody] UpdateTratamentoDto tratamentoDto) =>
        await _service.AtualizarTratamentoServiceAsync(id, tratamentoDto) ?
            NoContent() :
            NotFound();

 

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaTratamento(int id) =>
        await _service.DeletarTratamentoServiceAsync(id) ?
            NoContent() :
            NotFound();
}

