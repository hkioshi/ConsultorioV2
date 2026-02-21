using System.ComponentModel.DataAnnotations;

namespace ConsultorioV2.Models
{
    public enum TipoPagamento
    {
        Dinheiro,
        CartaoCredito,
        CartaoDebito,
        Pix,
        TransferenciaBancaria
    }
    public class Pagamentos
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Tipo { get; set; }
        public DateTime DataPagamento { get; set; }
        public int ProntuarioId { get; set; }
        public virtual Prontuario Prontuario { get; set; }


    }
}
