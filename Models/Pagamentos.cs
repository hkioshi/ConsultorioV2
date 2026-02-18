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
        public int Id { get; set; }
        double Valor { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Tipo { get; set; }
        public DateTime DataPagamento { get; set; }



    }
}
