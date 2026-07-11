using AutoMapper;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;

namespace ConsultorioApi.Profiles;

public class ProcedimentoProfile : Profile
{
    public ProcedimentoProfile()
    {
        CreateMap<CreateProcedimentoDto, Procedimento>();
        CreateMap<Procedimento, ReadProcedimentoDto>();
        CreateMap<UpdateProcedimentoDto, Procedimento>();
    }
}