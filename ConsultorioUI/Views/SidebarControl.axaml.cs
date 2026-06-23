using Avalonia.Controls;
using Avalonia.Interactivity;
namespace ConsultorioUI.Views;

public partial class SidebarControl : UserControl
{
    public SidebarControl() => InitializeComponent();
    
    private void NavInicio_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("Inicio");
    
    private void NavPacientes_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("Pacientes");

    private void NavAgenda_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("Agenda");

    private void NavFinanceiro_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("Financeiro");
    
    private void NavConfiguracoes_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("Config");
    
}