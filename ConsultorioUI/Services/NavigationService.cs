using System.Collections.Generic;
using Avalonia;

using ConsultorioUI.Views;

namespace ConsultorioUI.Services;

public class NavigationService()
{
    private Visual _atual = new InicioView();
    private Stack<Visual> Stack {get;} = new();
    public void Voltar()
    {
        _atual = Stack.Pop();
        App.Window.MainContent.Content = _atual;
    }
    public void Navegar(Visual visual)
    {
        Stack.Push(_atual);
        _atual = visual;
        App.Window.MainContent.Content = visual;
    }
    public void Atualizar(Visual visual)
    {
        Stack.Pop();
        Stack.Push(_atual);
        _atual = visual;
        App.Window.MainContent.Content = visual;
    }
    public void NavegarParaInicio(Visual navegacao)
    {
        Stack.Clear();
        Navegar(navegacao);
    }
}