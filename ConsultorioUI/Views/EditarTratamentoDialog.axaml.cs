using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class EditarTratamentoDialog : Window
{
    private TratamentoViewModel _viewModel;
    public EditarTratamentoDialog(Tratamento tratamento)
    {
        InitializeComponent();
        _viewModel = new TratamentoViewModel(tratamento);
        DataContext = _viewModel;

    }

    private async void Excluir_click(object? sender, RoutedEventArgs e)
    {
        if (await MessageBox.ShowWarning("Tem certeza que quer exluir?"))
            if (await _viewModel.ExcluirTratento())
            {
                MessageBox.Show("Excluido com sucesso");
                Close(true);
            }
    }

    private void Cancelar_click(object? sender, RoutedEventArgs e) => Close(false);
    
    private async void Salvar_click(object? sender, RoutedEventArgs e)
    {
        MessageBox.Show(await _viewModel.Salvar() ? "Salvo com sucesso" : "Não Salvo");
        Close(true);
    }
}