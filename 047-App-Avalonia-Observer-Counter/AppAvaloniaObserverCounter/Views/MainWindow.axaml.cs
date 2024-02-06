using AppAvaloniaObserverCounter.Interfaces;
using AppAvaloniaObserverCounter.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;


namespace AppAvaloniaObserverCounter.Views
{
    public partial class MainWindow : Window, IObserver
    {
        private Counter counter = new Counter();
        private TextBlock counterTextBlock;

        public MainWindow()
        {
            InitializeComponent();
            counter.Attach(this);
            counterTextBlock = this.FindControl<TextBlock>("CounterTextBlock");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Update(int value)
        {
            counterTextBlock.Text = $"Counter: {value}";
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            counter.Increment();
        }
    }
}