using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace ConsultorioUI.Services;

public static class MessageBox
{
    
    public static  void Show(Visual visual, string message)
    {
        var parentWindow = TopLevel.GetTopLevel(visual) as Window;

        var okButton = new Button
        {
            Content = "OK",
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Thickness(24, 8),
            Margin = new Thickness(0, 12, 0, 0)
        };

        var dialog = new Window
        {
            Title = "Aviso",
            Width = 320,
            SizeToContent = SizeToContent.Height,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                HorizontalAlignment = HorizontalAlignment.Center,
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                    okButton
                }
            }
        };

        okButton.Click += (_, _) => dialog.Close();

        if (parentWindow != null) dialog.ShowDialog(parentWindow);
    }
    
}