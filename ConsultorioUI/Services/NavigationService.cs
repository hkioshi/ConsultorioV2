using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using ConsultorioUI.Models;
using ConsultorioUI.Views;

namespace ConsultorioUI.Services;

public class NavigationService
{
    private MainWindow _mainWindow { get; set; }
    private Visual Atual = new InicioView();
    private Stack<Visual> _stack { get; set; } = new();
    public NavigationService(MainWindow mainwindow) =>
        _mainWindow = mainwindow;
    public void VoltarAoInicio() =>
        _stack.Clear();

    public void Voltar()
    {
        Atual = _stack.Pop();
        _mainWindow.MainContent.Content = Atual;
    }
    
    public Visual Ir(Visual visual)
    {
        _stack.Push(Atual);
        Atual = visual;
        return visual;
    }
    
    
    public void Navigate(string view)
    {
        _mainWindow.MainContent.Content = view switch
        {
            
            "Inicio" => Ir(new InicioView()),
            "Pacientes" => Ir(new PacientesView()),
            "Agenda" => Ir(new AgendaView()),
            "Financeiro" => Ir(new PagamentoView()),
            "NovoPaciente" => Ir(new NovoPacienteView()),
            _ => _mainWindow.MainContent.Content
            
        };
        
    }

    public void Atualizar(string view)
    {
        _mainWindow.MainContent.Content = view switch
        {
            
            "Inicio" => Att(new InicioView()),
            "Pacientes" => Att(new PacientesView()),
            "Agenda" => Att(new AgendaView()),
            "Financeiro" => Att(new PagamentoView()),
            "NovoPaciente" => Att(new NovoPacienteView()),
            _ => _mainWindow.MainContent.Content
            
        };
        
    }
    
    public void Navigate(string view, Paciente? paciente)
    {
        _mainWindow.MainContent.Content = view switch
        {
            "PerfilPaciente" => Ir(new PacientePerfilView(paciente)),
            "Prontuario" => Ir(new ProntuarioView(paciente)),
            _ => _mainWindow.MainContent.Content
        };
    }


    public void Atualizar(string view, Paciente paciente)
    {
        _mainWindow.MainContent.Content = view switch
        {
            "PerfilPaciente" => Att(new PacientePerfilView(paciente)),
            "Prontuario" => Att(new ProntuarioView(paciente)),
            _ => _mainWindow.MainContent.Content
        };
    }

    private Visual Att(Visual visual)
    {
        _stack.Pop();
        _stack.Push(Atual);
        Atual = visual;
        return visual;
    }
}