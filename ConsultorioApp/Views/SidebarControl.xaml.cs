using System.Windows;
using System.Windows.Controls;

namespace ConsultorioApp.Views
{
    public partial class SidebarControl : UserControl
    {
        public event Action<string> OnNavigate;

        public SidebarControl() => InitializeComponent();

        private void NavInicio_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Inicio");
        }

        private void NavPacientes_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Pacientes");
        }

        private void NavAgenda_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Agenda");
        }

        private void NavFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Financeiro");
        }

        private void NavConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Config");
        }
    }
}