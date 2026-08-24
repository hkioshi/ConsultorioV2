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

    public async Task Delete(int id) =>
        await _repos.Delete(id);

    public async Task Modify(int id, ModifyPacienteDto obj) =>
        await _repos.Modify(id, obj);

    internal async Task<IEnumerable<GetPacienteDto>> GetByName(string name) =>
        await _repos.GetByName(name);


    internal async Task<GetPacienteDto?> GetByCpf(string cpf)=>
        await _repos.GetByCpf( cpf);
}
