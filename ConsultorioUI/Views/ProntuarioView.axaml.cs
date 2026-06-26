using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class ProntuarioView : UserControl
{   
    private readonly Paciente _paciente;
    private  ProntuarioViewModel _viewModel;
    public ProntuarioView(Paciente paciente)
    {
        _paciente = paciente;
        _viewModel = new ProntuarioViewModel(paciente);
        DataContext = _viewModel;
        InitializeComponent();
        TxtNomePaciente.Text = _paciente.Nome;
        _viewModel.IniciarTabela(this);
    }

    private async void BtnSalvar_Click(object? sender, RoutedEventArgs e) =>
        await _viewModel.Salvar(this);

    private void Completo_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        FaceDistal.IsEnabled = !Completo.IsChecked.Value;
        FaceLingual.IsEnabled =  !Completo.IsChecked.Value;
        FaceOclusal.IsEnabled = !Completo.IsChecked.Value;
        FaceVestibular.IsEnabled = !Completo.IsChecked.Value;
        FaceMesial.IsEnabled =  !Completo.IsChecked.Value;
    }

    private void Descricao_click(object? sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();
        _viewModel.AbrirDescricao(id, this);
    }

    private void Pagar_click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void Voltar_click(object? sender, RoutedEventArgs e) =>
        App.Navigation.Voltar();
    
}