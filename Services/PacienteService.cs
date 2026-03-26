using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Services;

public class PacienteService
{
    private ConsultorioContext _context;
    private IMapper _mapper;
    public PacienteService(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<List<ReadPacienteDto>> ExibirPacientesServiceAsync() =>
        _mapper.Map<List<ReadPacienteDto>>(await _context.Pacientes.ToListAsync());          
    
    public async Task<Paciente> AdicionarPacienteServiceAsync(CreatePacienteDto pacienteDto)
    {
        var paciente = _mapper.Map<Paciente>(pacienteDto);
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<bool> AtualizarPacienteServiceAsync(int id, UpdatePacienteDto pacienteDto)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(
        paciente => paciente.Id.Equals(id));
        if (paciente is null) return false;
        _mapper.Map(pacienteDto, paciente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarPacienteServiceAsync(int id)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(
        paciente => paciente.Id == id);
        if (paciente is null) return false;
        _context.Remove(paciente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ReadPacienteDto?> ExibirPacientePorIdServiceAsync(int id)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(
        paciente => paciente.Id.Equals(id));
        return paciente is null ? 
            null : 
            _mapper.Map<ReadPacienteDto>(paciente);
        
    }
}
