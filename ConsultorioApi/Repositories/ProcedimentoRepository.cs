using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos.ProcedimentosDto;
using ConsultorioApi.Data.Mappers;
using ConsultorioApi.Models;
using ConsultorioApi.Services;

namespace ConsultorioApi.Repositories;
public class ProcedimentoRepository
{
    private readonly ConsultorioContext _context;

    public ProcedimentoRepository(ConsultorioContext context)
    {
        _context = context;
    }

    public async Task<Procedimento> Add(AddProcedimentoDto dto)
    {
        var procedimento = await dto.ToProcedimento();

        await _context.Procedimentos.AddAsync(procedimento);
        await _context.SaveChangesAsync();

        return procedimento;
    }

    public async Task<IEnumerable<GetProcedimentoDto>> GetAll()
    {
        var procedimentos = _context.Procedimentos.ToList();

        return await Task.WhenAll(
            procedimentos.Select(x => x.ToGetDto()).ToArray());
    }

    public async Task<GetProcedimentoDto> GetById(int id)
    {
        Procedimento? procedimento =  _context.Procedimentos
            .FirstOrDefault(x => x.Id == id);

        if (procedimento is null)
            throw new NotFoundException();

        return await procedimento.ToGetDto();
    }

    public async Task<Procedimento> GetByIdInternal(int id)
    {
        Procedimento? procedimento =  _context.Procedimentos
            .FirstOrDefault(procedimento => procedimento.Id == id);

        if (procedimento is null)
            throw new NotFoundException();

        return procedimento;
    }

    internal async Task Delete(int id)
    {
        var procedimento = _context.Procedimentos
            .FirstOrDefault(procedimento => procedimento.Id == id);

        if (procedimento == null)
            throw new NotFoundException();

        _context.Remove(procedimento);

        await _context.SaveChangesAsync();
    }

    internal async Task Modify(int id, ModifyProcedimentoDto obj)
    {
        var procedimento =  _context.Procedimentos
            .FirstOrDefault(p => p.Id == id);

        if (procedimento == null)
            throw new NotFoundException();

        procedimento.ToPutDto(obj);

        await _context.SaveChangesAsync();
    }
}
