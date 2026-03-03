using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioV2.Services
{
    public class PagamentoService
    {
        private ConsultorioContext _context;
        private IMapper _mapper;
        public PagamentoService(ConsultorioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReadPagamentosDto>> GetAllPagamentos()
        {
            var lista = await _context.Pagamentos.ToListAsync();
            return  _mapper.Map<List<ReadPagamentosDto>>(lista);
        }

        public async Task<Pagamentos> AddPagamentosAsync(CreatePagamentoDto pagamentoDto)
        {
            var pagamentos = _mapper.Map<Pagamentos>(pagamentoDto);
            _context.Pagamentos.Add(pagamentos);
            await _context.SaveChangesAsync();
            return pagamentos;
        }

        public async Task<bool> UpdatePagamentosAsync(int id, UpdatePagamentoDto pagamentoDto)
        {
            var pagamentos = await _context.Pagamentos.FirstOrDefaultAsync(
            pagamentos => pagamentos.Id == id);
            if (pagamentos == null) return false;
            _mapper.Map(pagamentoDto, pagamentos);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePagamentosAsync(int id)
        {
            var pagamento = await _context.Pagamentos.FirstOrDefaultAsync(
            pagamento => pagamento.Id == id);
            if (pagamento is null) return false;
            _context.Remove(pagamento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}