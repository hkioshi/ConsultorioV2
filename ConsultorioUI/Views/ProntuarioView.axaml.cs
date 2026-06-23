using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class ProntuarioView : UserControl 
{
    public ProntuarioView(string id)
    {
        DataContext = new ProntuarioViewModel();
        InitializeComponent();
    }
    
    
    
}