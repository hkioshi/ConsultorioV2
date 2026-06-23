using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class NovoPacienteView : UserControl
{
    private PacienteViewModel VM = new PacienteViewModel();
    private MainWindow _mainWindow;
    public NovoPacienteView(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        InitializeComponent();
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
        Paciente PacienteSalvo = new Paciente
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

        if(VM.Validar(this,PacienteSalvo))
        {
            var response = await VM.SalvarNovo(PacienteSalvo);
            if (response)
            {
                MessageBox.Show(this,"Salvo com sucesso!");
                _mainWindow.MainContent.Content = new PacientesView(_mainWindow);
            }
        }
        
        
    }
}