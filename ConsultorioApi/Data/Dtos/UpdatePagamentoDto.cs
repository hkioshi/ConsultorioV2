namespace ConsultorioApi.Data.Dtos
{
    public class UpdatePagamentoDto
    {
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Tipo { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
