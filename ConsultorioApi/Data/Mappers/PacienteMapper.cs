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
    public async static Task<Paciente> ToPaciente(this ModifyPacienteDto dto) =>
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

    public async static Task<GetPacienteDto> ToDto(this Paciente model) =>
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

            Profissao = model.Profissao,
            Observacoes = model.Observacoes,

            PreferenciaHorario = model.PreferenciaHorario,
            QueroReceberLembretes = model.QueroReceberLembretes
        };
}


