using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Services;

public class TratamentoService
{
    private readonly ConsultorioContext _context;
    private readonly IMapper _mapper;

    public TratamentoService(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Tratamento> AdicionarTratamentoServiceAsync(CreateTratamentoDto tratamentoDto)
    {
        var tratamento = _mapper.Map<Tratamento>(tratamentoDto);
        _context.Tratamentos.Add(tratamento);
        await _context.SaveChangesAsync();
        return tratamento;
    }

    public async Task<List<ReadTratamentosDto>> ExibirTratamentosServiceAsync() =>
        _mapper.Map<List<ReadTratamentosDto>>(
            await _context.Tratamentos.ToListAsync());

    public async Task<bool> AtualizarTratamentoServiceAsync(int id, UpdateTratamentoDto tratamentoDto)
    {
        var tratamento = await _context.Tratamentos
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tratamento == null) return false;

        _mapper.Map(tratamentoDto, tratamento);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarTratamentoServiceAsync(int id)
    {
        var tratamento = await _context.Tratamentos
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tratamento == null) return false;

        _context.Remove(tratamento);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ReadTratamentosDto?> ExibirTratamentoPorIdServiceAsync(int id)
    {
        var tratamento = await _context.Tratamentos.FirstOrDefaultAsync(
        tratamento => tratamento.Id.Equals(id));
        return tratamento is null ?
            null :
            _mapper.Map<ReadTratamentosDto>(tratamento);
    }

}