using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Threading.Tasks;

namespace AppAvaloniaAutoMoveControls.Views;
public partial class MainWindow : Window
{
    private TextBlock[] controls;
    private double[] speeds;

    public MainWindow()
    {
        InitializeComponent();
        this.Opened += async (s, e) => await StartAnimation();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        controls = new TextBlock[]
        {
            this.FindControl<TextBlock>("Control1"),
            this.FindControl<TextBlock>("Control2"),
            this.FindControl<TextBlock>("Control3"),
            this.FindControl<TextBlock>("Control4")
        };

        speeds = new double[] { 1.0, 2.0, 3.0, 4.0 }; // Different speeds for each control
    }

    private async Task StartAnimation()
    {
        while (true)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                var control = controls[i];
                double nextPos = Canvas.GetLeft(control) + speeds[i];
                double maxWidth = this.Bounds.Width;

                // Check boundaries and reverse direction if necessary
                if (nextPos <= 0 || nextPos >= maxWidth - control.Bounds.Width)
                {
                    speeds[i] *= -1;
                }

                Canvas.SetLeft(control, nextPos);
            }

            await Task.Delay(16); // Roughly 60 FPS
        }
    }
}
