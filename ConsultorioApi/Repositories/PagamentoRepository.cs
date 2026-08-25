using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos.PagamentoDto;
using ConsultorioApi.Data.Mappers;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApi.Repositories;

public class PagamentoRepository
{
    private readonly ConsultorioContext _context;

    public PagamentoRepository(ConsultorioContext context)
    {
        _context = context;
    }

    public async Task<Pagamento> Add(AddPagamentoDto dto)
    {
        var pagamento = await dto.ToPagamento();

        await _context.Pagamentos.AddAsync(pagamento);
        await _context.SaveChangesAsync();

        return pagamento;
    }

    public async Task<IEnumerable<GetPagamentoDto>> GetAll()
    {
        var pagamentos = await _context.Pagamentos.ToListAsync();

        return await Task.WhenAll(
            pagamentos.Select(x => x.ToGetDto()).ToArray());
    }

    public async Task<GetPagamentoDto> GetById(int id)
    {
        Pagamento? pagamento = await _context.Pagamentos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pagamento is null)
            throw new NotFoundException();

        return await pagamento.ToGetDto();
    }

    public async Task<Pagamento> GetByIdInternal(int id)
    {
        Pagamento? pagamento = await _context.Pagamentos
        .FirstOrDefaultAsync(pagamento => pagamento.Id == id);

        if (pagamento is null)
            throw new NotFoundException();

        return pagamento;
    }

    internal async Task Delete(int id)
    {
        var pagamento = _context.Pagamentos
            .FirstOrDefault(pagamento => pagamento.Id == id);

        if (pagamento == null)
            throw new NotFoundException();

        _context.Remove(pagamento);

        await _context.SaveChangesAsync();
    }

    internal async Task Modify(int id, ModifyPagamentoDto obj)
    {
        var pagamento = await _context.Pagamentos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pagamento == null)
            throw new NotFoundException();

        pagamento.ToPutDto(obj);

        await _context.SaveChangesAsync();
    }
}
