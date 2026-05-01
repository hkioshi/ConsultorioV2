using ConsultorioWPF.Views;
using System.Windows;

namespace ConsultorioWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Sidebar.OnNavigate += Sidebar_OnNavigate;
            MainContent.Content = new InicioView();
        }

        private void Sidebar_OnNavigate(string view)
        {
            MainContent.Content = view switch
            {
                "Inicio" => new InicioView(),
                "Pacientes" => new PacientesView(),
                _ => MainContent.Content 
            };
            
        }
    }
}