using AutoMapper;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
namespace ConsultorioV2.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<CreatePacienteDto, Paciente>();
            CreateMap<Paciente, ReadPacienteDto>();

            CreateMap<UpdatePacienteDto, Paciente>();


        }
    }
}
