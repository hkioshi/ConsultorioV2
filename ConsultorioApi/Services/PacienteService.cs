using ConsultorioApi.Data.Dtos.Pacientes;
using ConsultorioApi.Models;
using ConsultorioApi.Repositories;

namespace ConsultorioApi.Services;

public class PacienteService
{
    PacienteRepository _repos;
    public PacienteService(PacienteRepository repos)
    {
        _repos = repos;
    }
    public async Task<Paciente> Add(AddPacienteDto dto) =>
        await _repos.Add(dto);

    public async Task<IEnumerable<GetPacienteDto>> GetAll() =>
        await _repos.GetAll();

    public async Task<GetPacienteDto> GetById(int id) =>
        await _repos.GetById(id);
}
