using System.ComponentModel.DataAnnotations;

namespace ConsultorioV2.Models
{
    public class ContatoInfo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [Required]
        public Paciente Paciente { get; set; }
    }
}
