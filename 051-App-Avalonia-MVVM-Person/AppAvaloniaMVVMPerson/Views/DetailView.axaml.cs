using AppAvaloniaMVVMPerson.Models;
using AppAvaloniaMVVMPerson.ViewModels;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppAvaloniaMVVMPerson.Views
{
    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
