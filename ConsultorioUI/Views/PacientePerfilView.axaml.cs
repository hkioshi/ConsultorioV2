using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class PacientePerfilView : UserControl
{
    private readonly PacienteViewModel _vm = new();
    private readonly string _id;

    public PacientePerfilView(string id)
    {
        InitializeComponent();
        _id = id;
        _ = Iniciar(id);
    }

    async Task Iniciar(string id)
    {
        var paciente = await _vm.BuscarPacientePorId(id);
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

        // Contato / Endereço
        TxtCep.Text          = paciente.Cep;
        TxtNumero.Text       = paciente.Numero;
        TxtLogradouro.Text   = paciente.Logradouro;
        TxtComplemento.Text  = paciente.Complemento;
        TxtBairro.Text       = paciente.Bairro;
        TxtCidade.Text       = paciente.Cidade;
        CmbEstado.Text       = paciente.Estado;
        TxtTelefone.Text     = paciente.Telefone;
        TxtEmail.Text        = paciente.Email;

        // Informações Adicionais
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

    private async void BtnSalvar_Click(object? sender, RoutedEventArgs e)
    {
        PacienteUpdateDTO pacienteSalvo = new PacienteUpdateDTO
        {
            Nome           = TxtNome.Text?.Trim() ?? "",
            Cpf            = TxtCpf.Text?.Trim() ?? "",
            Rg             = TxtRg.Text?.Trim() ?? "",
            DataNascimento = DtNascimento.SelectedDate?.Date ?? DateTime.MinValue,  // DatePicker retorna DateTimeOffset?
            Genero         = (CmbGenero.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
            EstadoCivil    = (CmbEstadoCivil.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",

            PessoaResponsavelId = 0,
            RecomendadoPorId    = 0,

            Cep          = TxtCep.Text?.Trim() ?? "",
            Logradouro   = TxtLogradouro.Text?.Trim() ?? "",
            Numero       = TxtNumero.Text?.Trim() ?? "",
            Complemento  = TxtComplemento.Text?.Trim() ?? "",
            Bairro       = TxtBairro.Text?.Trim() ?? "",
            Cidade       = TxtCidade.Text?.Trim() ?? "",
            Estado       = (CmbEstado.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
            Telefone     = TxtTelefone.Text?.Trim() ?? "",
            Email        = TxtEmail.Text?.Trim() ?? "",

            NomePai            = TxtNomePai.Text?.Trim() ?? "",
            NomeMae            = TxtNomeMae.Text?.Trim() ?? "",
            NomeConjuge        = "",
            Profissao          = TxtProfissao.Text?.Trim() ?? "",
            ConheceuPor        = 0,
            Observacoes        = TxtObservacoes.Text?.Trim() ?? "",
            Convenio           = "",
            NumeroConvenio     = "",
            PreferenciaHorario = TxtPreferenciaHorario.Text?.Trim() ?? "",
            QueroReceberLembretes = ChkLembretes.IsChecked ?? false
        };

        if(ValidacaoService.Validar(this,pacienteSalvo))
        {
            var response = await _vm.SalvarAlteracao(pacienteSalvo, _id);
            if (response)
            {
                MessageBox.Show("Salvo com sucesso!");
                
                App.Navigation.Navigate("Pacientes");
            }
        }
        
    }
}
    
    
    
