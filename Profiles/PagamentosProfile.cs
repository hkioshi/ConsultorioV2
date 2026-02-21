using AutoMapper;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;

namespace ConsultorioV2.Profiles
{
    public class PagamentosProfile : Profile
    {
        public PagamentosProfile()
        {
            CreateMap<CreatePagamentoDto, Pagamentos>();
            CreateMap<Pagamentos, ReadPagamentosDto>();
        }
    }
}
