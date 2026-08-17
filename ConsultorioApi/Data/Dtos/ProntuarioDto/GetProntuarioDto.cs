using System.ComponentModel.DataAnnotations;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Dtos.ProntuarioDto;

public class GetProntuarioDto
{
    public int Id { get; set; }
    [Required] public int PacienteId { get; set; }
    public virtual ICollection<Tratamento>? Tratamentos { get; set; }
    public virtual ICollection<Pagamento>? Pagamentos { get; set; }
}

