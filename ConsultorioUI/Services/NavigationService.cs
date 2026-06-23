using Avalonia.Controls;
using ConsultorioUI.Views;

namespace ConsultorioUI.Services;

public class NavigationService
{
    private MainWindow _mainWindow { get; set; }
    public NavigationService(MainWindow mainwindow)
    {
        _mainWindow = mainwindow;
    }
    public void Navigate<T>()
        where T : UserControl, new()
    {
        _mainWindow.MainContent.Content = new T();
    }
    public void Navigate(string view)
    {
        _mainWindow.MainContent.Content = view switch
        {
            
            //TODO: Fazer Agenda
            //TODO: Fazer Tratamentos
            //TODO: Fazer Pagamentos
            //TODO: Fazer Configs
            "Inicio" => new InicioView(),
            "Pacientes" => new PacientesView(),
            "Agenda" => new AgendaView(),
            "Financeiro" => new PagamentoView(),
            "NovoPaciente" => new NovoPacienteView(),
            _ => _mainWindow.MainContent.Content
            
        };
        
    }

    public void Navigate(string view, string id)
    {
        _mainWindow.MainContent.Content = view switch
        {

            "PerfilPaciente" => new PacientePerfilView(id),
            "Prontuario" => new ProntuarioView(id),
            _ => _mainWindow.MainContent.Content

        };
    }
}