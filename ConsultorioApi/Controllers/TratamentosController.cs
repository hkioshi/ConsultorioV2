using ConsultorioApi.Controllers.Interfaces;
using ConsultorioApi.Data.Dtos.TratamentoDto;

using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TratamentoController : ControllerBase,
    IController<Tratamento, GetTratamentoDto, AddTratamentoDto, ModifyTratamentoDto>
{
    private readonly TratamentoService _service;

    public TratamentoController(TratamentoService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Tratamento>> Add(
        [FromBody] AddTratamentoDto obj)
    {
        var tratamento = await _service.Add(obj);

        return CreatedAtAction(
            nameof(GetById),
            new { id = tratamento.Id },
            tratamento
        );
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetTratamentoDto>>> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetTratamentoDto>> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch (NotFoundException)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Modify(
        int id,
        [FromBody] ModifyTratamentoDto obj)
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"DTO: {obj}");

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState)
            {
                Console.WriteLine($"Campo: {error.Key}");

                foreach (var e in error.Value!.Errors)
                    Console.WriteLine($"Erro: {e.ErrorMessage}");
            }

            return BadRequest(ModelState);
        }

        await _service.Modify(id, obj);

        return NoContent();
    }
}