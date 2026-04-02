using AutoMapper;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;
namespace ConsultorioApi.Profiles
{
    public class TratamentoProfile : Profile
    {
        public TratamentoProfile()
        {
            CreateMap<CreateTratamentoDto, Tratamento>();
            CreateMap<Tratamento, ReadTratamentosDto>();
            CreateMap<UpdateTratamentoDto, Tratamento>();
            CreateMap<Pagamentos, ReadValorDto>();


        }



    }
}
