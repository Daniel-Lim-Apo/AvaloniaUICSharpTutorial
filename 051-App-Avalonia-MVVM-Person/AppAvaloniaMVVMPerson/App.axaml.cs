using AppAvaloniaMVVMPerson.Models;
using AppAvaloniaMVVMPerson.ViewModels;
using AppAvaloniaMVVMPerson.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;

namespace AppAvaloniaMVVMPerson
{
    public partial class App : Application
    {
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var person = new Person { Id=1, Name = "John Doe", Age = 30, Gender = "Male", DocId ="XMO-555-468" };
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(person)
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}