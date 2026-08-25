using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos.TratamentoDto;
using ConsultorioApi.Data.Mappers;
using ConsultorioApi.Models;
using ConsultorioApi.Services;

namespace ConsultorioApi.Repositories;

public class TratamentoRepository
{
 private readonly ConsultorioContext _context;

    public TratamentoRepository(ConsultorioContext context)
    {
        _context = context;
    }

    public async Task<Tratamento> Add(AddTratamentoDto dto)
    {
        var tratamento = await dto.ToTratamento();

        await _context.Tratamentos.AddAsync(tratamento);
        await _context.SaveChangesAsync();

        return tratamento;
    }

    public async Task<IEnumerable<GetTratamentoDto>> GetAll()
    {
        var tratamentos = _context.Tratamentos.ToList();

        return await Task.WhenAll(
            tratamentos.Select(x => x.ToGetDto()).ToArray());
    }

    public async Task<GetTratamentoDto> GetById(int id)
    {
        Tratamento? tratamento =  _context.Tratamentos
            .FirstOrDefault(x => x.Id == id);

        if (tratamento is null)
            throw new NotFoundException();

        return await tratamento.ToGetDto();
    }

    public async Task<Tratamento> GetByIdInternal(int id)
    {
        Tratamento? tratamento =  _context.Tratamentos
            .FirstOrDefault(tratamento => tratamento.Id == id);

        if (tratamento is null)
            throw new NotFoundException();

        return tratamento;
    }

    internal async Task Delete(int id)
    {
        var tratamento = _context.Tratamentos
            .FirstOrDefault(tratamento => tratamento.Id == id);

        if (tratamento == null)
            throw new NotFoundException();

        _context.Remove(tratamento);

        await _context.SaveChangesAsync();
    }

    internal async Task Modify(int id, ModifyTratamentoDto obj)
    {
        var tratamento = _context.Tratamentos
            .FirstOrDefault(t => t.Id == id);

        if (tratamento == null)
            throw new NotFoundException();

        tratamento.ToPutDto(obj);

        await _context.SaveChangesAsync();
    }
}
