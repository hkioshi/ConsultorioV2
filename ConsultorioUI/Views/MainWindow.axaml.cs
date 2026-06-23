using Avalonia.Controls;

namespace ConsultorioUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
       // Busca os controles pelo nome após inicializar
        var mainContent = this.FindControl<ContentControl>("MainContent")!;
        mainContent.Content = new InicioView();
    }
    
}