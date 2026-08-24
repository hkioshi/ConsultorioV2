using ConsultorioApi.Data.Dtos.TratamentoDto;
using ConsultorioApi.Models;
using ConsultorioApi.Repositories;

namespace ConsultorioApi.Services;

public class TratamentoService
{
    TratamentoRepository _repos;
    public TratamentoService(TratamentoRepository repos)
    {
        _repos = repos;
    }
    public async Task<Tratamento> Add(AddTratamentoDto dto) =>
        await _repos.Add(dto);

    public async Task<IEnumerable<GetTratamentoDto>> GetAll() =>
        await _repos.GetAll();

    public async Task<GetTratamentoDto> GetById(int id) =>
        await _repos.GetById(id);

    public async Task Delete(int id) =>
        await _repos.Delete(id);

    public async Task Modify(int id, ModifyTratamentoDto obj) =>
        await _repos.Modify(id, obj);
}
