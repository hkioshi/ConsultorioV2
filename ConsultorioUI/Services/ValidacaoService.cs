using System;
using Avalonia;
using ConsultorioUI.Models;

namespace ConsultorioUI.Services;

public static class ValidacaoService
{
    public static bool Validar(Visual visual, Paciente paciente)
    {
        if (string.IsNullOrWhiteSpace(paciente.Nome))
        {
            MessageBox.Show(visual, "O campo Nome é obrigatório.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(paciente.Cpf) || paciente.Cpf.Length != 14)
        {
            MessageBox.Show(visual, "CPF inválido ou não informado.");
            return false;
        }

        if (paciente.DataNascimento == DateTime.MinValue)
        {
            MessageBox.Show(visual, "Informe a data de nascimento.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(paciente.Telefone) || paciente.Telefone.Length < 14)
        {
            MessageBox.Show(visual, "Telefone inválido ou não informado.");
            return false;
        }

        return true;
    }

    public static bool Validar(Visual visual, PacienteUpdateDTO paciente)
    {
        if (string.IsNullOrWhiteSpace(paciente.Nome))
        {
            MessageBox.Show(visual, "O campo Nome é obrigatório.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(paciente.Cpf) || paciente.Cpf.Length < 14)
        {
            MessageBox.Show(visual, "CPF inválido ou não informado.");
            return false;
        }

        if (paciente.DataNascimento == DateTime.MinValue)
        {
            MessageBox.Show(visual, "Informe a data de nascimento.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(paciente.Telefone) || paciente.Telefone.Length < 14)
        {
            MessageBox.Show(visual, "Telefone inválido ou não informado.");
            return false;
        }

        return true;
    }
}