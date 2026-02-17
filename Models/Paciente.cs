using System.ComponentModel.DataAnnotations;

namespace ConsultorioV2.Models
{
    public class Paciente
    {
        //Infos Pessoais
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public int PessoaResponsavelId { get; set; }
        public int RecomendadoPorId { get; set; }

        //Contato
        public int ContatoInfoId { get; set; }
        public virtual ContatoInfo ContatoInfo { get; set; }
        public int ProntuarioId { get; set; }
        public virtual Prontuario Prontuario { get; set; }

        //Extra
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string NomeConjuge { get;set; }
        public string Profissao { get; set; }
        public int ConheceuPor { get; set; }
        public string Observacoes { get; set; }
        public string Convenio { get; set; }
        public string NumeroConvenio { get; set; }
        public string PreferenciaHorario { get; set; }
        public bool QueroReceberLembretes { get; set; }


    }
}
