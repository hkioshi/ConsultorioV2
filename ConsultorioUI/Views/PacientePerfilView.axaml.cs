using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class PacientePerfilView : UserControl
{
    private PacienteViewModel VM;
    private string Id;

    public PacientePerfilView(string id)
    {
        InitializeComponent();
        VM = new();
        Id = id;
        _ = Iniciar(id);
    }

    async Task Iniciar(string id)
    {
        var paciente = await VM.BuscarPacientePorId(id);
        if (paciente is null) return;

        // Dados Pessoais
        TxtNome.Text          = paciente.Nome;
        TxtCpf.Text            = paciente.Cpf;
        TxtRg.Text              = paciente.Rg;
        DtNascimento.SelectedDate = paciente.DataNascimento;
        SelecionarComboPorTexto(CmbGenero, paciente.Genero);
        SelecionarComboPorTexto(CmbEstadoCivil, paciente.EstadoCivil);
        TxtProfissao.Text     = paciente.Profissao;
        TxtNomePai.Text       = paciente.NomePai;
        TxtNomeMae.Text       = paciente.NomeMae;
        TxtNomeConjuge.Text   = paciente.NomeConjuge;

        // Contato / Endereço
        TxtCep.Text          = paciente.Cep;
        TxtNumero.Text       = paciente.Numero;
        TxtLogradouro.Text   = paciente.Logradouro;
        TxtComplemento.Text  = paciente.Complemento;
        TxtBairro.Text       = paciente.Bairro;
        TxtCidade.Text       = paciente.Cidade;
        TxtEstado.Text       = paciente.Estado;
        TxtTelefone.Text     = paciente.Telefone;
        TxtEmail.Text        = paciente.Email;

        // Informações Adicionais
        TxtConvenio.Text             = paciente.Convenio;
        TxtNumeroConvenio.Text       = paciente.NumeroConvenio;
        TxtPreferenciaHorario.Text   = paciente.PreferenciaHorario;
        TxtObservacoes.Text          = paciente.Observacoes;
        ChkLembretes.IsChecked       = paciente.QueroReceberLembretes;
    }

    private void SelecionarComboPorTexto(ComboBox combo, string? valor)
    {
        if (string.IsNullOrWhiteSpace(valor)) return;

        foreach (var item in combo.Items)
        {
            if (item is ComboBoxItem cbi &&
                cbi.Content?.ToString()?.Equals(valor, StringComparison.OrdinalIgnoreCase) == true)
            {
                combo.SelectedItem = cbi;
                break;
            }
        }
    }
}
    
    
    
