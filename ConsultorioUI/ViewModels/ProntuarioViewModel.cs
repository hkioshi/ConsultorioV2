using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;

namespace ConsultorioUI.ViewModels;
public partial class ProntuarioViewModel : ObservableObject
{
    public ObservableCollection<Procedimento> Procedimentos { get; set; }
    [ObservableProperty]
    private string nome = "";
    [ObservableProperty]
    private string nomeValor;
}

