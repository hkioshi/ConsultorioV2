using System.ComponentModel.DataAnnotations;

namespace ConsultorioV2.Models
{
    public class Prontuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<Tratamento> Tratamentos { get; set; }    
        public virtual ICollection<Pagamentos> Pagamentos { get; set; }
    }
}
