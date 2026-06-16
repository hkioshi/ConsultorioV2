using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class PacientePerfilView : UserControl
{
    private PacienteViewModel VM;
    private string Id;
    public  PacientePerfilView(string id)
    {
        InitializeComponent();
        VM = new ();
        Id = id;
        _ = Iniciar(id);
    }

    async Task Iniciar(string id)
    {
        var paciente = await VM.BuscarPacientePorId(id);
        foreach (var prop in paciente.GetType().GetProperties())
        {
            var textBlock = new TextBlock();
            textBlock.Text = $"{prop.Name}: {prop.GetValue(paciente)}";
            Pai.Children.Add(textBlock);
        }

    }
    
    
    
    
    
    
    
}