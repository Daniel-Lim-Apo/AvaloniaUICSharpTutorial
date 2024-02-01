using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Animation;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Animation.Easings;
using Avalonia.Styling;
using AppAvaloniaBulletShot.ViewModels;

namespace AppAvaloniaBulletShot.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }


    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        var viewModel = DataContext as MainWindowViewModel;
        if (viewModel == null) return;

        switch (e.Key)
        {
            case Key.Up: // Move up
                viewModel.MoveRectangle1(0, -10);
                break;
            case Key.Down: // Move down
                viewModel.MoveRectangle1(0, 10);
                break;
            case Key.Left: // Move left
                viewModel.MoveRectangle1(-10, 0);
                break;
            case Key.Right: // Move right
                viewModel.MoveRectangle1(10, 0);
                break;
            case Key.Space: // Space
                viewModel.Shot(this.Bounds.Top, this.Bounds.Bottom, this.Rectangle2);
                break;

                //case Key.W: // Move up
                //    viewModel.MoveRectangle2(0, -10);
                //    break;
                //case Key.S: // Move down
                //    viewModel.MoveRectangle2(0, 10);
                //    break;
                //case Key.A: // Move left
                //    viewModel.MoveRectangle2(-10, 0);
                //    break;
                //case Key.D: // Move right
                //    viewModel.MoveRectangle2(10, 0);
                //    break;
        }
    }
}


