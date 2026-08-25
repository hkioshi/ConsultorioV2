using ConsultorioApi.Data.Dtos.PagamentoDto;
using ConsultorioApi.Models;
using ConsultorioApi.Repositories;

namespace ConsultorioApi.Services;

public class PagamentoService
{
    
    PagamentoRepository _repos;

    public PagamentoService(PagamentoRepository repos)
    {
        _repos = repos;
    }

    public async Task<Pagamento> Add(AddPagamentoDto dto) =>
        await _repos.Add(dto);

    public async Task<IEnumerable<GetPagamentoDto>> GetAll() =>
        await _repos.GetAll();

    public async Task<GetPagamentoDto> GetById(int id) =>
        await _repos.GetById(id);

    public async Task Delete(int id) =>
        await _repos.Delete(id);

    public async Task Modify(int id, ModifyPagamentoDto obj) =>
        await _repos.Modify(id, obj);
}