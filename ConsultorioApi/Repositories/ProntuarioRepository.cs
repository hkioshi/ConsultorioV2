using ConsultorioApi.Data;
using ConsultorioApi.Data.Dtos.ProntuarioDto;
using ConsultorioApi.Data.Mappers;
using ConsultorioApi.Models;
using ConsultorioApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApi.Repositories;

public class ProntuarioRepository
{
    private readonly ConsultorioContext _context;



    public ProntuarioRepository(ConsultorioContext context)
    {
        _context = context;
    }

    public async Task<Prontuario> Add(AddProntuarioDto dto)
    {
        var prontuario = await dto.ToProntuario();
        await _context.Prontuarios.AddAsync(prontuario);
        await _context.SaveChangesAsync();
        return prontuario;
    }

    internal async Task<IEnumerable<GetProntuarioDto>> GetAll()
    {
       var prontuarios = await _context.Prontuarios.ToListAsync();
        return await Task.WhenAll(
            prontuarios.Select(x => x.ToGetDto()).ToArray());
    }

    internal async Task<GetProntuarioDto> GetById(int id)
    {
        Prontuario? prontuario = await _context.Prontuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (prontuario is null) throw new NotFoundException();

        return await prontuario.ToGetDto();
    }

    internal async Task SetProntuario(Prontuario prontuario)
    {
        int id = prontuario.PacienteId;
        Paciente? paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        if(paciente is not null)
        {
            paciente.Prontuario = prontuario;
            await _context.SaveChangesAsync();
            
        }
        
        throw new NotFoundException();

    }
}
