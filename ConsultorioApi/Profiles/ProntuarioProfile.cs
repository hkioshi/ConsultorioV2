using AutoMapper;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;

namespace ConsultorioApi.Profiles
{
    public class ProntuarioProfile : Profile
    {
        public ProntuarioProfile()
        {
            CreateMap<CreateProntuarioDto, Prontuario>();
            CreateMap<Prontuario, ReadProntuarioDto>();

            

        }
    }
}
