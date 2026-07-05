using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using ConsultorioUI.Models;
using ConsultorioUI.Views;

namespace ConsultorioUI.Services;

public class NavigationService(MainWindow mainwindow)
{
    private MainWindow MainWindow { get; set; } = mainwindow;
    private Visual _atual = new InicioView();
    private Stack<Visual> Stack { get; set; } = new();

    public void Voltar()
    {
        _atual = Stack.Pop();
        MainWindow.MainContent.Content = _atual;
    }
    
    private Visual Ir(Visual visual)
    {
        Stack.Push(_atual);
        _atual = visual;
        return visual;
    }
    
    private Visual Att(Visual visual)
    {
        Stack.Pop();
        Stack.Push(_atual);
        _atual = visual;
        return visual;
    }
    
    public void Navegar(Visual visual) =>
        MainWindow.MainContent.Content = Ir(visual);
    
    public void Atualizar(Visual visual) => 
        MainWindow.MainContent.Content = Att(visual);
    
    public void NavegarParaInicio(Visual navegacao)
    {
        Stack.Clear();
        Navegar(navegacao);
    }
    
}