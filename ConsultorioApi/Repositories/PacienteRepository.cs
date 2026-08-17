using System.Runtime.Remoting;
using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos.Pacientes;
using ConsultorioApi.Data.Mappers;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApi.Repositories;
 
public class PacienteRepository
{
    private readonly ConsultorioContext _context;

    public PacienteRepository(ConsultorioContext context)
    {
        _context = context;
    }

    public async Task<Paciente> Add(AddPacienteDto dto)
    {
        var paciente = await dto.ToPaciente();
        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<IEnumerable<GetPacienteDto>> GetAll()
    {
        var pacientes = await _context.Pacientes.ToListAsync();
        return await Task.WhenAll(
            pacientes.Select(x => x.ToGetDto()).ToArray());
    }
        
    public async Task<GetPacienteDto> GetById(int id)
    {
        Paciente? paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        if (paciente is null) throw new NotFoundException();

        return await paciente.ToGetDto();
    }

    internal async Task Delete(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.Id == id);
        if (paciente == null) throw new NotFoundException();
        _context.Remove(paciente);
        _context.SaveChanges();
    }

    internal async Task Modify(int id, ModifyPacienteDto obj)
    {
        var paciente = await _context.Pacientes
            .FirstOrDefaultAsync(p => p.Id == id);

        if (paciente == null)
            throw new NotFoundException();

        paciente.ToPutDto(obj);

        await _context.SaveChangesAsync();
    }
}
