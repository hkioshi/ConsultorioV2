using Microsoft.AspNetCore.Mvc;
using ConsultorioApi.Controllers.Interfaces;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using ConsultorioApi.Data.Dtos.ProntuarioDto;

namespace ConsultorioApi.Controllers;

public class ProntuarioController : ControllerBase, IController<Prontuario,GetProntuarioDto, AddProntuarioDto, ModifyProntuarioDto>
{
    ProntuarioService _service;
    public ProntuarioController(ProntuarioService service)
    {
        _service = service;
    }
    public Task<ActionResult<Prontuario>> Add(AddProntuarioDto obj)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IEnumerable<GetProntuarioDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<GetProntuarioDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> Modify(int id, ModifyProntuarioDto obj)
    {
        throw new NotImplementedException();
    }
}
