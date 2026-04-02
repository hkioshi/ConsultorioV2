using ConsultorioApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioApi.Data.Dtos
{
    public class ReadProntuarioDto
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public List<ReadTratamentosDto> Tratamentos { get; set; }
        public List<ReadPagamentosDto> Pagamentos { get; set; }
    }
}

