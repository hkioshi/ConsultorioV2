using ConsultorioApi.Data.Dtos.ProcedimentosDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;
public static class ProcedimentoMapper
{
    public static async Task<Procedimento> ToProcedimento(
    this AddProcedimentoDto dto)
    {
        return new Procedimento
        {
            Nome = dto.Nome,
            Valor = dto.Valor
        };
    }

    public static async Task<GetProcedimentoDto> ToGetDto(
    this Procedimento procedimento)
    {
        return new GetProcedimentoDto
        {
            Id = procedimento.Id,
            Nome = procedimento.Nome,
            Valor = procedimento.Valor
        };
    }

    public static void ToPutDto(
    this Procedimento procedimento,
    ModifyProcedimentoDto dto)
    {
        procedimento.Valor = dto.Valor;
    }
}
