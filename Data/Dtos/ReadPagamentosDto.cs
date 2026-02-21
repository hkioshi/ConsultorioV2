using ConsultorioV2.Models;

namespace ConsultorioV2.Data.Dtos
{
    public class ReadPagamentosDto
    {
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Tipo { get; set; }
        public DateTime DataPagamento { get; set; }

        public int ProntuarioId { get; set; }
    }
}
