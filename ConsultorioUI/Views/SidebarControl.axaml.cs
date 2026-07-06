using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ConsultorioUI.Services;

namespace ConsultorioUI.Views;

public partial class SidebarControl : UserControl
{
    public SidebarControl() => InitializeComponent();
    
    private void NavInicio_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.NavegarParaInicio(new InicioView());
    
    private void NavPacientes_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.NavegarParaInicio(new  PacientesView());

    private void NavAgenda_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.NavegarParaInicio(new AgendaView());

    private void NavFinanceiro_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.NavegarParaInicio(new PagamentoView());
    
    private void NavConfiguracoes_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.NavegarParaInicio(new ConfigView());
    
}