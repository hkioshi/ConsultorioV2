using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Services;
public class ProntuarioService
{
    private readonly ConsultorioContext _context;
    private readonly IMapper _mapper;

    public ProntuarioService(ConsultorioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Prontuario> AdicionarProntuarioServiceAsync(CreateProntuarioDto prontuarioDto)
    {
        var prontuario = _mapper.Map<Prontuario>(prontuarioDto);
        _context.Prontuarios.Add(prontuario);
        await _context.SaveChangesAsync();
        return prontuario;
    }

    public async Task<List<ReadPagamentosDto>> ExibirPagamentosPorIdServiceAsync(int id)
    {
        var pagamentos = await _context.Pagamentos
            .Where(p => p.ProntuarioId == id)
            .ToListAsync();

        return _mapper.Map<List<ReadPagamentosDto>>(pagamentos);
    }

    public async Task<List<ReadTratamentosDto>> ExibirTratamentosPorIdServiceAsync(int id)
    {
        var tratamentos = await _context.Tratamentos
            .Where(t => t.ProntuarioId == id)
            .ToListAsync();

        return _mapper.Map<List<ReadTratamentosDto>>(tratamentos);
    }

    public async Task<List<ReadProntuarioDto>> ExibirProntuariosServiceAsync()
    {
        var lista = await _context.Prontuarios.ToListAsync();
        return _mapper.Map<List<ReadProntuarioDto>>(lista);
    }

    public async Task<ReadProntuarioDto?> ExibirProntuarioPorIdServiceAsync(int id)
    {
        var prontuario = await _context.Prontuarios
            .FirstOrDefaultAsync(p => p.Id == id);

        return prontuario == null
            ? null
            : _mapper.Map<ReadProntuarioDto>(prontuario);
    }

    public async Task<ReadProntuarioDto?> ExibirProntuarioPorNomeServiceAsync(string nome)
    {
        var pessoa = await _context.Pacientes
            .FirstOrDefaultAsync(p => p.Nome == nome);
        if (pessoa is null) return null;

        var prontuario = await _context.Prontuarios
            .FirstOrDefaultAsync(p => p.PacienteId == pessoa.Id);

        return prontuario is null
            ? null
            : _mapper.Map<ReadProntuarioDto>(prontuario);
    }

    public async Task<bool> DeletarProntuarioServiceAsync(int id)
    {
        var prontuario = await _context.Prontuarios
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prontuario == null) return false;

        _context.Remove(prontuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<double?> ExibirValoresServiceAsync(int id)
    {
        var prontuario = await _context.Prontuarios
            .Include(p => p.Tratamentos)
            .Include(p => p.Pagamentos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prontuario == null) return null;

        var devido = prontuario.Tratamentos.Sum(t => t.Valor);
        var pago = prontuario.Pagamentos.Sum(p => p.Valor);

        return devido - pago;
    }
}