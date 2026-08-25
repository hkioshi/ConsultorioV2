namespace ConsultorioApi.Data.Dtos.PagamentoDto;
public class AddPagamentoDto
{
    public double Valor { get; set; }
    public string? Descricao { get; set; }
    public string? Observacoes { get; set; }
    public int Tipo { get; set; }
    public DateTime DataPagamento { get; set; }
    public int ProntuarioId { get; set; }
}