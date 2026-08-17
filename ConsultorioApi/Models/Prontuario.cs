using System.ComponentModel.DataAnnotations;

namespace ConsultorioApi.Models;
public class Prontuario
{
    [Key] [Required] public int Id { get; set; }

    [Required] public int PacienteId { get; set; }

    public virtual required Paciente Paciente { get; set; }
    public virtual required ICollection<Tratamento> Tratamentos { get; set; } = [];
    public virtual required ICollection<Pagamentos> Pagamentos { get; set; } = [];
}
