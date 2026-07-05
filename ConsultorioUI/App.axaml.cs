using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Net.Http;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Services;
using ConsultorioUI.Views;

namespace ConsultorioUI;

public partial class App : Application
{

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public static NavigationService Navigation { get; private set; } = null!;
    public static MainWindow Window {get; private set; } = null!;
    public static HttpClient HttpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:7256/")
    };

    
    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Window = new MainWindow();
            Navigation = new NavigationService(Window);
            desktop.MainWindow = Window;
        }

        base.OnFrameworkInitializationCompleted();
    
    }
}