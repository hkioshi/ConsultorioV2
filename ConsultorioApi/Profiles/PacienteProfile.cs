using AutoMapper;
using ConsultorioApi.Data.Dtos;
using ConsultorioApi.Models;
namespace ConsultorioApi.Profiles
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
