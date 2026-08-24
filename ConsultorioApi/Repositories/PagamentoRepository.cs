using ConsultorioApi.Data.Dtos.PagamentoDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Repositories;

public class PagamentoRepository
{
    internal async Task<Pagamento> Add(AddPagamentoDto dto)
        {
            throw new NotImplementedException();
        }
        
    internal async Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    internal async Task<IEnumerable<GetPagamentoDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    internal async Task<GetPagamentoDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    internal async Task Modify(int id, ModifyPagamentoDto obj)
    {
        throw new NotImplementedException();
    }
}
