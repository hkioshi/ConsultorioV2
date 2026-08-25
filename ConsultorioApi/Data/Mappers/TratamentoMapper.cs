using ConsultorioApi.Data.Dtos.TratamentoDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;

public static class TratamentoMapper
{
    public static async Task<Tratamento> ToTratamento(
    this AddTratamentoDto dto)
    {
        return new Tratamento
        {
            Data = dto.Data,
            Dente = dto.Dente,
            OclusalIncisal = dto.OclusalIncisal,
            LingualPalatina = dto.LingualPalatina,
            Vestibular = dto.Vestibular,
            Mesial = dto.Mesial,
            Distal = dto.Distal,
            Procedimento = dto.Procedimento,
            Observacoes = dto.Observacoes,
            Status = dto.Status,
            Valor = dto.Valor,
            ProntuarioId = dto.ProntuarioId
        };
    }

    public static async Task<GetTratamentoDto> ToGetDto(
    this Tratamento tratamento)
    {
        return new GetTratamentoDto
        {
            Id = tratamento.Id,
            Data = tratamento.Data,
            Dente = tratamento.Dente,
            OclusalIncisal = tratamento.OclusalIncisal,
            LingualPalatina = tratamento.LingualPalatina,
            Vestibular = tratamento.Vestibular,
            Mesial = tratamento.Mesial,
            Distal = tratamento.Distal,
            Procedimento = tratamento.Procedimento,
            Observacoes = tratamento.Observacoes,
            Status = tratamento.Status,
            Valor = tratamento.Valor,
            ProntuarioId = tratamento.ProntuarioId
        };
    }

    public static void ToPutDto(
    this Tratamento tratamento,
    ModifyTratamentoDto dto)
    {
        tratamento.Data = dto.Data;
        tratamento.Dente = dto.Dente;
        tratamento.OclusalIncisal = dto.OclusalIncisal;
        tratamento.LingualPalatina = dto.LingualPalatina;
        tratamento.Vestibular = dto.Vestibular;
        tratamento.Mesial = dto.Mesial;
        tratamento.Distal = dto.Distal;
        tratamento.Procedimento = dto.Procedimento;
        tratamento.Observacoes = dto.Observacoes;
        tratamento.Status = dto.Status;
        tratamento.Valor = dto.Valor;
    }
}
