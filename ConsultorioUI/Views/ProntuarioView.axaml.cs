using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class ProntuarioView : UserControl
{
    private ProntuarioViewModel vm = new();
    public ProntuarioView(string id)
    {
        InitializeComponent();
    }
    
    
    
}