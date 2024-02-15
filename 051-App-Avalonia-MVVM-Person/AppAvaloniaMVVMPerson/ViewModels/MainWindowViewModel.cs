using Avalonia.Controls;
using ReactiveUI;
using System.Windows.Input;
using System;
using AppAvaloniaMVVMPerson.Models;
using AppAvaloniaMVVMPerson.Views;

namespace AppAvaloniaMVVMPerson.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private UserControl _currentView;
        private readonly DetailViewModel _detailViewModel;
        private readonly SummaryViewModel _summaryViewModel;

        public MainWindowViewModel(Person person)
        {
            _detailViewModel = new DetailViewModel(person);
            _summaryViewModel = new SummaryViewModel(person);

            ShowDetailViewCommand = ReactiveCommand.Create(() => CurrentView = new DetailView { DataContext = _detailViewModel });
            ShowSummaryViewCommand = ReactiveCommand.Create(() => CurrentView = new SummaryView { DataContext = _summaryViewModel });

            // Default view
            CurrentView = new DetailView { DataContext = _detailViewModel };
        }

        public UserControl CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        public ICommand ShowDetailViewCommand { get; }
        public ICommand ShowSummaryViewCommand { get; }
    }
}
