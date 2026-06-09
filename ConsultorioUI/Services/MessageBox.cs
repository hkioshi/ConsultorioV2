using Avalonia;
using Avalonia.Controls;

namespace ConsultorioUI.Services;

public static class MessageBox
{
    public static void Show(Visual visual ,string message)
    {
        var parentWindow = TopLevel.GetTopLevel(visual) as Window;

        var dialog = new Window
        {
            Title = "Aviso",
            Width = 300,
            Height = 150,
            Content = new TextBlock { Text = message }
        };

        dialog.ShowDialog(parentWindow);
    }
    public static void Show(Visual visual ,string message, string title)
    {
        var parentWindow = TopLevel.GetTopLevel(visual) as Window;

        var dialog = new Window
        {
            Title = title,
            Width = 300,
            Height = 150,
            Content = new TextBlock { Text = message }
        };

        dialog.ShowDialog(parentWindow);
    }
    
}