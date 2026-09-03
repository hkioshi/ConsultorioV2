using Microsoft.AspNetCore.Mvc;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using ConsultorioApi.Data.Dtos.ProntuarioDto;
using ConsultorioApi.Data.Mappers;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProntuarioController : ControllerBase
{
    ProntuarioService _service;
    public ProntuarioController(ProntuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProntuarioDto>> Add([FromBody] AddProntuarioDto obj)
    {
        var prontuario = await _service.Add(obj);
        var dto = await prontuario.ToGetDto();

        return CreatedAtAction(
            nameof(GetById),
            new { id = dto.Id },
            dto
        );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetProntuarioDto>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProntuarioDto>> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch
        {
            return BadRequest();
        }
    }
}
