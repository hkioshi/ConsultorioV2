using Avalonia.Controls;
using Avalonia.Interactivity;
namespace ConsultorioUI.Views;

public partial class SidebarControl : UserControl
{
    public SidebarControl() => InitializeComponent();

    private void NavegarParaInicio(string navegacao)
    {
        App.Navigation.VoltarAoInicio();
        App.Navigation.Navigate(navegacao);
    }
    
    private void NavInicio_Click(object sender, RoutedEventArgs e) =>
        NavegarParaInicio("Inicio");
    
    private void NavPacientes_Click(object sender, RoutedEventArgs e) =>
        NavegarParaInicio("Pacientes");

    private void NavAgenda_Click(object sender, RoutedEventArgs e) =>
        NavegarParaInicio("Agenda");

    private void NavFinanceiro_Click(object sender, RoutedEventArgs e) =>
        NavegarParaInicio("Financeiro");
    
    private void NavConfiguracoes_Click(object sender, RoutedEventArgs e) =>
        NavegarParaInicio("Config");
    
}