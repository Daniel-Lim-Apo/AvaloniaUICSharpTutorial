using AppAvaloniaMVVMPerson.Models;
using AppAvaloniaMVVMPerson.ViewModels;
using Avalonia.Controls;

namespace AppAvaloniaMVVMPerson.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            var person = new Person { Name = "John Doe", Age = 30 };
            var detailViewModel = new DetailViewModel(person);
            var summaryViewModel = new SummaryViewModel(person);

            // Assuming you have a way to display these views in your MainWindow,
            // you would set their DataContext here.
            //detailView.DataContext = detailViewModel;
            //summaryView.DataContext = summaryViewModel;


        }
    }
}