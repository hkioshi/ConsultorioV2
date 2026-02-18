using ConsultorioV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsultorioController : ControllerBase
{
    private ConsultorioContext _contexto;
    public ConsultorioController(ConsultorioContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API do Consultório funcionando!");
    }


    
}

/*{
private FilmeContext _contexto;
private IMapper _mapper;

public FilmeController(FilmeContext contexto, IMapper mapper)
{
    _contexto = contexto;
    _mapper = mapper;
}


/// <summary>
/// Adiciona um filme ao banco de dados
/// </summary>
/// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
/// <returns>IActionResult</returns>
/// <response code="201">Caso inserção seja feita com sucesso</response>
[HttpPost] // Indica que este método responde a requisições HTTP POST
[ProducesResponseType(StatusCodes.Status201Created)]
public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDto) // Recebe um objeto Filme do corpo da requisição 
{
    //padrao post: Retornar objeto e o caminho para ser encontrado 

    Filme filme = _mapper.Map<Filme>(filmeDto);
    _contexto.Filmes.Add(filme);
    _contexto.SaveChanges();
    return CreatedAtAction(nameof(ExibirFilmesPorId),
        new { id = filme.Id },
        filme);


}

[HttpGet]
public IEnumerable<ReadFilmeDTO> ExibirFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
{
    return _mapper.Map<List<ReadFilmeDTO>>(_contexto.Filmes.Skip(skip).Take(take).ToList());
}


[HttpGet("{id}")]//Filmes/id
public IActionResult ExibirFilmesPorId(int id)
{
    var filme = _contexto.Filmes.FirstOrDefault(a => id.Equals(a.Id));
    if (filme is null) return NotFound();
    var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
    return Ok(filmeDto);
}

[HttpPut("{id}")]
public IActionResult AtualizaFilme(int id,
[FromBody] UpdateFilmeDTO filmeDto)
{
    var filme = _contexto.Filmes.FirstOrDefault(
        filme => filme.Id == id);
    if (filme == null) return NotFound();
    _mapper.Map(filmeDto, filme);
    _contexto.SaveChanges();
    return NoContent();
}

//put - Atualização completa
//patch - atualização parcial

[HttpPatch("{id}")]
public IActionResult AtualizaFilmeParcial(int id,
JsonPatchDocument<UpdateFilmeDTO> patch)
{
    var filme = _contexto.Filmes.FirstOrDefault(
        filme => filme.Id == id);
    if (filme == null) return NotFound();

    var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);
    patch.ApplyTo(filmeParaAtualizar, ModelState);
    if (!TryValidateModel(filmeParaAtualizar))
    {
        return ValidationProblem(ModelState);
    }

    _mapper.Map(filmeParaAtualizar, filme);
    _contexto.SaveChanges();
    return NoContent();
    //Como fazer a modificação no postman
    //        [
    //    {
    //        "op":"replace",
    //        "path": "/Titulo",
    //        "value":"O Senhor dos Anéis: A Sociedade do Anel"
    //    }
    //        ]

        }
[HttpDelete("{id}")]
public IActionResult DeletaFilme(int id)
{
    var filme = _contexto.Filmes.FirstOrDefault(
       filme => filme.Id == id);
    if (filme == null) return NotFound();
    _contexto.Remove(filme);
    _contexto.SaveChanges();
    return NoContent();
}
}*/
