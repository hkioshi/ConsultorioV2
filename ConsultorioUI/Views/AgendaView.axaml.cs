using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class AgendaView : UserControl
{
    private readonly AgendaViewModel _agendaVM = new(); 
    public DateTime Hoje { get; } = DateTime.Today;
    public AgendaView()
    {
        InitializeComponent();
        DataContext = new AgendaViewModel();
    }
    

    
    
}