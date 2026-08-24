using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Data.Dtos.ProcedimentosDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Repositories;
public class ProcedimentoRepository
{
        internal async Task<Procedimento> Add(AddProcedimentoDto dto)
    {
        throw new NotImplementedException();
    }

    internal async Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    internal async Task<IEnumerable<GetProcedimentoDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    internal async Task<GetProcedimentoDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    internal async Task Modify(int id, ModifyProcedimentoDto obj)
    {
        throw new NotImplementedException();
    }
}
