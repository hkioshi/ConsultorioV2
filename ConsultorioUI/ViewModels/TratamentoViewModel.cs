using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.Services;

namespace ConsultorioUI.ViewModels;

public partial class TratamentoViewModel : ObservableObject
{
    [ObservableProperty] public partial Tratamento Tratamento { get; set; }

    public DateTimeOffset? Data
    {
        get => new DateTimeOffset(Tratamento.Data);
        set
        {
            if (value != null)
                Tratamento.Data = value.Value.DateTime;
        }
    }

    public TratamentoViewModel(Tratamento tratamento)
    {
        Tratamento = tratamento;
    }


    public async Task<bool> Salvar() =>
        await DatabaseService.SalvarAlteracaoTratamento(Tratamento, Tratamento.Id);
    
    public async Task<bool> ExcluirTratento() =>
        await DatabaseService.ExcluirTratamento(Tratamento.Id);

}