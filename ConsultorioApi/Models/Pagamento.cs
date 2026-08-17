using System.ComponentModel.DataAnnotations;

namespace ConsultorioApi.Models;
public class Pagamento
{
    [Key] [Required] public int Id { get; set; }

    public double Valor { get; set; }
    public string? Descricao { get; set; }
    public string? Observacoes { get; set; }
    public int Tipo { get; set; }
    public DateTime DataPagamento { get; set; }
    public int ProntuarioId { get; set; }
    public virtual required Prontuario Prontuario { get; set; }
}
