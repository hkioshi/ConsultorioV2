using Avalonia.Controls;
namespace ConsultorioUI.Views;

public partial class MainWindow : Window
{
    private SidebarControl _sidebar;
    private ContentControl _mainContent;

    public MainWindow()
    {
        InitializeComponent();

        // Busca os controles pelo nome após inicializar
        _sidebar = this.FindControl<SidebarControl>("Sidebar")!;
        _mainContent = this.FindControl<ContentControl>("MainContent")!;

        _sidebar.OnNavigate += Sidebar_OnNavigate;
        _mainContent.Content = new InicioView();
    }

    private void Sidebar_OnNavigate(string view)
    {
        _mainContent.Content = view switch
        {
            //TODO: Fazer Prontuario
            //TODO: Fazer Odontograma
            //TODO: Fazer Agenda
            //TODO: Fazer Tratamentos
            //TODO: Fazer Pagamentos
            //TODO: Fazer Configs
            "Inicio" => new InicioView(),
            "Pacientes" => new PacientesView(this),
            "Agenda" => new AgendaView(),
            "Financeiro" => new PagamentoView(),
            _ => _mainContent.Content
            
        };
    }
}