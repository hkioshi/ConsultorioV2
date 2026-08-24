using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Data.Dtos.TratamentoDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Repositories
{
    public class TratamentoRepository
    {

        
        internal async Task<Tratamento> Add(AddTratamentoDto dto)
        {
            throw new NotImplementedException();
        }
        
        internal async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<IEnumerable<GetTratamentoDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        internal async Task<GetTratamentoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task Modify(int id, ModifyTratamentoDto obj)
        {
            throw new NotImplementedException();
        }
    }
}