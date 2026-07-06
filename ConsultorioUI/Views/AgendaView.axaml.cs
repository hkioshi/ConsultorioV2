using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class AgendaView : UserControl
{
    private readonly AgendaViewModel _agendaVm = new(); 
    
    public AgendaView()
    {
        InitializeComponent();
    }


    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://www.youtube.com",
            UseShellExecute = true
        });    }
}