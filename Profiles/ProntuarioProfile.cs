using AutoMapper;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;

namespace ConsultorioV2.Profiles
{
    public class ProntuarioProfile : Profile
    {
        public ProntuarioProfile()
        {
            CreateMap<CreateProntuarioDto, Prontuario>();
        }
    }
}
