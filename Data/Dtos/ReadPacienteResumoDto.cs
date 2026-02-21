namespace ConsultorioV2.Data.Dtos
{
    public class ReadPacienteResumoDto
    {
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
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}