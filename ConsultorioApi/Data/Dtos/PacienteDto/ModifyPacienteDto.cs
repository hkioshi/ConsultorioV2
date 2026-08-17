namespace ConsultorioApi.Data.Dtos.Pacientes;

public class ModifyPacienteDto
{
    public string? Nome { get; set; }
    public required string Cpf { get; set; }
    public string? Rg { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Genero { get; set; }
    public string? EstadoCivil { get; set; }
    public int? PessoaResponsavelId { get; set; }
    public int? RecomendadoPorId { get; set; }

    //Contato
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public required string Telefone { get; set; }

    public required string Email { get; set; }

    //Extra
    public string? Profissao { get; set; }
    public int ConheceuPor { get; set; }
    public string? Observacoes { get; set; }

    public string? PreferenciaHorario { get; set; }
    public bool QueroReceberLembretes { get; set; }    
}
