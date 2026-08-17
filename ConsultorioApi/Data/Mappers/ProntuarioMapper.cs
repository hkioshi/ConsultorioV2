using ConsultorioApi.Data.Dtos.ProntuarioDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;

public static class ProntuarioMapper
{
    public async static Task<GetProntuarioDto> ToGetDto(this Prontuario model) =>
        new GetProntuarioDto
        {
            Id = model.Id,
            Tratamentos = model.Tratamentos,
            Pagamentos = model.Pagamentos
        };

   public static async Task<Prontuario> ToProntuario(this AddProntuarioDto model)
        {
            return new Prontuario()
            {
                PacienteId = model.PacienteId,
                Pagamentos = [],
                Tratamentos = [],
            };
        }
}
