using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioApp.Models;
public class Paciente
{
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
    //Extra
    public string NomePai { get; set; }
    public string NomeMae { get; set; }
    public string NomeConjuge { get; set; }
    public string Profissao { get; set; }
    public int ConheceuPor { get; set; }
    public string Observacoes { get; set; }
    public string Convenio { get; set; }
    public string NumeroConvenio { get; set; }
    public string PreferenciaHorario { get; set; }
    public bool QueroReceberLembretes { get; set; }
}
