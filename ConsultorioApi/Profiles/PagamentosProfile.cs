using AutoMapper;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;

namespace ConsultorioApi.Profiles
{
    public class PagamentosProfile : Profile
    {
        public PagamentosProfile()
        {
            CreateMap<CreatePagamentoDto, Pagamentos>();
            CreateMap<Pagamentos, ReadPagamentosDto>();
            CreateMap<UpdatePagamentoDto, Pagamentos>();
            CreateMap<Pagamentos, ReadValorDto>();
                

        }
    }
}
