using System.Windows;
using System.Windows.Controls;

namespace ConsultorioApp.Controls
{
    public partial class SidebarControl : UserControl
    {
        // Evento disparado quando o usuário clica em um item de navegação
        public event RoutedEventHandler NavigationRequested;

        public SidebarControl()
        {
            InitializeComponent();
        }

        // Seleciona programaticamente um item do menu
        public void SelectItem(string item)
        {
            NavInicio.IsChecked       = item == "Inicio";
            NavPacientes.IsChecked    = item == "Pacientes";
            NavAgenda.IsChecked       = item == "Agenda";
            NavFinanceiro.IsChecked   = item == "Financeiro";
            NavConfiguracoes.IsChecked = item == "Configuracoes";
        }

        private void NavInicio_Click(object sender, RoutedEventArgs e)
            => NavigationRequested?.Invoke("Inicio", e);

        private void NavPacientes_Click(object sender, RoutedEventArgs e)
            => NavigationRequested?.Invoke("Pacientes", e);

        private void NavAgenda_Click(object sender, RoutedEventArgs e)
            => NavigationRequested?.Invoke("Agenda", e);

        private void NavFinanceiro_Click(object sender, RoutedEventArgs e)
            => NavigationRequested?.Invoke("Financeiro", e);

        private void NavConfiguracoes_Click(object sender, RoutedEventArgs e)
            => NavigationRequested?.Invoke("Configuracoes", e);

        private void NavConfiguracoes_Checked()
        {

        }

        private void NavConfiguracoes_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
