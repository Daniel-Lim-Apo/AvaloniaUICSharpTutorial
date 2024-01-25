using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;

namespace AppAvaloniaOpenWindow.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand OpenWindowCommand { get; }

    public MainWindowViewModel()
    {
        OpenWindowCommand = ReactiveCommand.Create(() =>
        {
            // Code here will be executed when the button is clicked.
            Window sampleWindow = 
            new Window 
            { 
                Title = "Sample Window",
                Width = 200,
                Height = 200
            };

            // open the window
            sampleWindow.Show();

        });

    
    }
}    