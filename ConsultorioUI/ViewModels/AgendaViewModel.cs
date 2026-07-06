
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.Views;
using DryIoc;

namespace ConsultorioUI.ViewModels;
public partial class AgendaViewModel : ObservableObject
{
    public ObservableCollection<Evento> Eventos = [];
    //public ObservableCollection<KeyValuePair<DateTime, List<Evento>>> EventosSemana { get; set; } = [];
    public ObservableCollection<Evento> EventosHoje { get; set; } = [];
    private readonly LoginService _loginService = new LoginService();
    public DateTime Hoje { get; } = DateTime.Today;

    public AgendaViewModel()
    {
        PreencherData();
    }
    
    private async void PreencherData()
    {
        var logado = await _loginService.Login();   // agora espera de verdade

        if (!logado)
        {
            // opcional: mostrar mensagem, redirecionar pra tela de login, etc.
            return;
        }

        var response = await App.HttpClient.GetAsync("/api/calendario/draceliaodonto@gmail.com/hoje");

        var conteudo = await response.Content.ReadAsStringAsync();


        Console.WriteLine(conteudo);
    }
}
