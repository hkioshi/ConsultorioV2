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
    private readonly Paciente _paciente;

    public PacientePerfilView(Paciente paciente)
    {
        InitializeComponent();
        _paciente = paciente;
        Iniciar();
    }

    async Task Iniciar()
    {
        if (_paciente is null) return;

        // Dados Pessoais
        TxtNome.Text          = _paciente.Nome;
        TxtCpf.Text            = _paciente.Cpf;
        TxtRg.Text              = _paciente.Rg;
        DtNascimento.SelectedDate = _paciente.DataNascimento;
        SelecionarComboPorTexto(CmbGenero, _paciente.Genero);
        SelecionarComboPorTexto(CmbEstadoCivil, _paciente.EstadoCivil);
        TxtProfissao.Text     = _paciente.Profissao;
        TxtNomePai.Text       = _paciente.NomePai;
        TxtNomeMae.Text       = _paciente.NomeMae;

        // Contato / Endereço
        TxtCep.Text          = _paciente.Cep;
        TxtNumero.Text       = _paciente.Numero;
        TxtLogradouro.Text   = _paciente.Logradouro;
        TxtComplemento.Text  = _paciente.Complemento;
        TxtBairro.Text       = _paciente.Bairro;
        TxtCidade.Text       = _paciente.Cidade;
        CmbEstado.Text       = _paciente.Estado;
        TxtTelefone.Text     = _paciente.Telefone;
        TxtEmail.Text        = _paciente.Email;

        // Informações Adicionais
        TxtPreferenciaHorario.Text   = _paciente.PreferenciaHorario;
        TxtObservacoes.Text          = _paciente.Observacoes;
        ChkLembretes.IsChecked       = _paciente.QueroReceberLembretes;
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
            var response = await _vm.SalvarAlteracao(pacienteSalvo, _paciente.Id.ToString());
            if (response)
            {
                MessageBox.Show("Salvo com sucesso!");
                
                App.Navigation.Navigate("Pacientes");
            }
        }
        
    }

    private void Voltar_click(object? sender, RoutedEventArgs e) =>
        App.Navigation.Voltar();
    
}
    
    
    
