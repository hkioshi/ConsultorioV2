using ConsultorioApi.Controllers.Interfaces;
using ConsultorioApi.Data.Dtos.ProcedimentosDto;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedimentoController : ControllerBase,
    IController<Procedimento, GetProcedimentoDto, AddProcedimentoDto, ModifyProcedimentoDto>
{
    private readonly ProcedimentoService _service;

    public ProcedimentoController(ProcedimentoService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Procedimento>> Add(
        [FromBody] AddProcedimentoDto obj)
    {
        var procedimento = await _service.Add(obj);

        return CreatedAtAction(
            nameof(GetById),
            new { id = procedimento.Id },
            procedimento
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
    public async Task<ActionResult<IEnumerable<GetProcedimentoDto>>> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProcedimentoDto>> GetById(int id)
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
        [FromBody] ModifyProcedimentoDto obj)
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