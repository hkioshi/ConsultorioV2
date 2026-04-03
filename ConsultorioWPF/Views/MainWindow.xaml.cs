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
            switch (view)
            {
                case "Inicio":
                    MainContent.Content = new InicioView();
                    break;

                case "Pacientes":
                    MainContent.Content = new PacientesView();
                    break;
                

            }
        }
    }
}