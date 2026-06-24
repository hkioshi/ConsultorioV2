using Avalonia.Controls;
using Avalonia.Interactivity;
using ConsultorioUI.Models;
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
    }
    
    //TODO: Botao Salvar
        //Registrar todos os botoes dentes que estiverem marcados, pegar nome do tratamento, faces, 
    //TODO: Protese e Estração


    private void BtnSalvar_Click(object? sender, RoutedEventArgs e)
    {
        _viewModel.Salvar(this);
    }

    private void Completo_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        FaceDistal.IsEnabled = !Completo.IsChecked.Value;
        FaceLingual.IsEnabled =  !Completo.IsChecked.Value;
        FaceOclusal.IsEnabled = !Completo.IsChecked.Value;
        FaceVestibular.IsEnabled = !Completo.IsChecked.Value;
        FaceMesial.IsEnabled =  !Completo.IsChecked.Value;
    }
}