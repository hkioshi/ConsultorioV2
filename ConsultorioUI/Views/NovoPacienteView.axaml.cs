using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class NovoPacienteView : UserControl
{
    private readonly PacienteViewModel _vm = new PacienteViewModel();
    public NovoPacienteView() => InitializeComponent();
    
    private async void BtnSalvar_Click(object? sender, RoutedEventArgs e)
    {
        Paciente pacienteSalvo = new Paciente
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
            if (await _vm.SalvarNovo(pacienteSalvo))
            {
                MessageBox.Show("Salvo com sucesso!");
                App.Navigation.Navigate("Pacientes");
            }
        }
        
        
    }

    private void Voltar_click(object? sender, RoutedEventArgs e) =>
        App.Navigation.Voltar();
}