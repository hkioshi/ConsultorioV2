using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Data.Dtos.ProcedimentosDto;
using ConsultorioApi.Models;
using ConsultorioApi.Repositories;

namespace ConsultorioApi.Services;

public class ProcedimentoService
{
    ProcedimentoRepository _repos;

    public ProcedimentoService(ProcedimentoRepository repos)
    {
        _repos = repos;
    }

    public async Task<Procedimento> Add(AddProcedimentoDto dto) =>
        await _repos.Add(dto);

    public async Task<IEnumerable<GetProcedimentoDto>> GetAll() =>
        await _repos.GetAll();

    public async Task<GetProcedimentoDto> GetById(int id) =>
        await _repos.GetById(id);

    public async Task Delete(int id) =>
        await _repos.Delete(id);

    public async Task Modify(int id, ModifyProcedimentoDto obj) =>
        await _repos.Modify(id, obj);
}
