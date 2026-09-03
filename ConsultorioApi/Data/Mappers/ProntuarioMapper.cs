using ConsultorioApi.Data.Dtos.ProntuarioDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;

public static class ProntuarioMapper
{
    public async static Task<GetProntuarioDto> ToGetDto(this Prontuario model)
    {

        return new GetProntuarioDto
        {
            Id = model.Id,
            PacienteId = model.PacienteId, // ← ADICIONA ISSO!

            Tratamentos = await Task.WhenAll(model.Tratamentos.Select(async x => await x.ToGetDto())),
            Pagamentos = await Task.WhenAll(model.Pagamentos.Select(async x => await x.ToGetDto()))
        };
    }
       
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
