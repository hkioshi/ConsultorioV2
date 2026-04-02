namespace ConsultorioApi.Data.Dtos
{
    public class CreateTratamentoDto
    {
        public DateTime Data { get; set; }
        public int Dente { get; set; }
        public bool OclusalIncisal { get; set; }
        public bool LingualPalatina { get; set; }
        public bool Vestibular { get; set; }
        public bool Mesial { get; set; }
        public bool Distal { get; set; }
        public string Procedimento { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public double Valor { get; set; }
        public int ProntuarioId { get; set; }
    }
}
