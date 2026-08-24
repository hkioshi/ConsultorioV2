using ConsultorioApi.Data.Dtos.PagamentoDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;

public static class PagamentoMapper
{
    public async static Task<GetPagamentoDto> ToGetDto(this Pagamento pagamento)
    {
        return new GetPagamentoDto
        {
            Id = pagamento.Id,
            Valor = pagamento.Valor,
            Descricao = pagamento.Descricao,
            Observacoes = pagamento.Observacoes,
            Tipo = pagamento.Tipo,
            DataPagamento = pagamento.DataPagamento,
            ProntuarioId = pagamento.ProntuarioId
        };
    }

    public static async Task<Pagamento> ToPagamento(this AddPagamentoDto dto)
    {
        return new Pagamento
        {
            Valor = dto.Valor,
            Descricao = dto.Descricao,
            Observacoes = dto.Observacoes,
            Tipo = dto.Tipo,
            DataPagamento = dto.DataPagamento,
            ProntuarioId = dto.ProntuarioId
        };
    }

    public static void ToPutDto(
    this Pagamento pagamento,
    ModifyPagamentoDto dto)
    {
        pagamento.Valor = dto.Valor;
        pagamento.Descricao = dto.Descricao;
        pagamento.Observacoes = dto.Observacoes;
        pagamento.Tipo = dto.Tipo;
        pagamento.DataPagamento = dto.DataPagamento;
    }
    }

