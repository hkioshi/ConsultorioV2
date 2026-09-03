using ConsultorioApi.Data.Dtos.Pacientes;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Mappers;
public static class PacienteMapper
{
    public async static Task<Paciente> ToPaciente(this AddPacienteDto dto) =>
        new Paciente
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Rg = dto.Rg,
            DataNascimento = dto.DataNascimento,
            Genero = dto.Genero,
            EstadoCivil = dto.EstadoCivil,
            PessoaResponsavelId = dto.PessoaResponsavelId,
            RecomendadoPorId = dto.RecomendadoPorId,

            Cep = dto.Cep,
            Logradouro = dto.Logradouro,
            Numero = dto.Numero,
            Complemento = dto.Complemento,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            Telefone = dto.Telefone,
            Email = dto.Email,

            Profissao = dto.Profissao,
            Observacoes = dto.Observacoes,

            PreferenciaHorario = dto.PreferenciaHorario,
            QueroReceberLembretes = dto.QueroReceberLembretes
        };
    public async static Task<GetPacienteDto> ToGetDto(this Paciente model) =>
        new GetPacienteDto
        {
            Id = model.Id,
            Nome = model.Nome,
            Cpf = model.Cpf,
            Rg = model.Rg,
            DataNascimento = model.DataNascimento,
            Genero = model.Genero,
            EstadoCivil = model.EstadoCivil,
            PessoaResponsavelId = model.PessoaResponsavelId,
            RecomendadoPorId = model.RecomendadoPorId,

            Cep = model.Cep,
            Logradouro = model.Logradouro,
            Numero = model.Numero,
            Complemento = model.Complemento,
            Bairro = model.Bairro,
            Cidade = model.Cidade,
            Estado = model.Estado,
            Telefone = model.Telefone,
            Email = model.Email,
            Prontuario = model.Prontuario != null ? await model.Prontuario.ToGetDto() : null,

            Profissao = model.Profissao,
            Observacoes = model.Observacoes,

            PreferenciaHorario = model.PreferenciaHorario,
            QueroReceberLembretes = model.QueroReceberLembretes
        };
    public  static void ToPutDto(this Paciente model, ModifyPacienteDto dto)
    {
        model.Nome = dto.Nome;
        model.Cpf = dto.Cpf;
        model.Rg = dto.Rg;
        model.DataNascimento = dto.DataNascimento;
        model.Genero = dto.Genero;
        model.EstadoCivil = dto.EstadoCivil;
        model.PessoaResponsavelId = dto.PessoaResponsavelId;
        model.RecomendadoPorId = dto.RecomendadoPorId;

        model.Cep = dto.Cep;
        model.Logradouro = dto.Logradouro;
        model.Numero = dto.Numero;
        model.Complemento = dto.Complemento;
        model.Bairro = dto.Bairro;
        model.Cidade = dto.Cidade;
        model.Estado = dto.Estado;
        model.Telefone = dto.Telefone;
        model.Email = dto.Email;

        model.Profissao = dto.Profissao;
        model.ConheceuPor = dto.ConheceuPor;
        model.Observacoes = dto.Observacoes;
        model.PreferenciaHorario = dto.PreferenciaHorario;
        model.QueroReceberLembretes = dto.QueroReceberLembretes;
    }
}


