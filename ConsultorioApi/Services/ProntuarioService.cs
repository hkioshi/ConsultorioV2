using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Data.Dtos.ProntuarioDto;
using ConsultorioApi.Models;
using ConsultorioApi.Repositories;

namespace ConsultorioApi.Services;

public class ProntuarioService
{
    ProntuarioRepository _repos;
    public ProntuarioService(ProntuarioRepository repos)
    {
        _repos = repos;
    }
    public async Task<Prontuario> Add(AddProntuarioDto dto)
    {
        var prontuario = await _repos.Add(dto);


        return prontuario;
    }

    public async Task<IEnumerable<GetProntuarioDto>> GetAll() =>
        await _repos.GetAll();

    public async Task<GetProntuarioDto> GetById(int id) =>
        await _repos.GetById(id);

}



