
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.Views;

namespace ConsultorioUI.ViewModels;
public partial class AgendaViewModel : ObservableObject
{
    public ObservableCollection<KeyValuePair<DateTime, List<Evento>>> EventosSemana { get; set; } = [];
    public ObservableCollection<Evento> EventosHoje { get; set; } = [];

    public DateTime Hoje { get; } = DateTime.Today;

    public AgendaViewModel()
    {
        PreencherData();
    }

    private async void PreencherData()
    {
        try
        {
           // var resposta = await DatabaseService.BuscarEventosHoje();
           
        }
        catch(UnauthorizedAccessException)
        {
            //App.Navigation.Navigate("Login");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        
    }
}
