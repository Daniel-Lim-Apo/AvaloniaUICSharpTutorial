using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace AppAvaloniaStackQueue.Views
{
    public partial class MainWindow : Window
    {
        private readonly Stack<string> _stack = new Stack<string>();
        private readonly Queue<string> _queue = new Queue<string>();
        private TextBlock _stackContents;
        private TextBlock _queueContents;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _stackContents = this.FindControl<TextBlock>("StackContents");
            _queueContents = this.FindControl<TextBlock>("QueueContents");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void PushToStack_Click(object sender, RoutedEventArgs e)
        {
            _stack.Push("Item " + (_stack.Count + 1));
            UpdateContents();
        }

        public void PopFromStack_Click(object sender, RoutedEventArgs e)
        {
            if (_stack.Count > 0)
            {
                _stack.Pop();
                UpdateContents();
            }
        }

        public void EnqueueToQueue_Click(object sender, RoutedEventArgs e)
        {
            //_queue.Enqueue("Item " + (_queue.Count + 1));
            _queue.Enqueue("Item " + (lastQueue++));
            UpdateContents();
        }

        private int lastQueue;
        public void DequeueFromQueue_Click(object sender, RoutedEventArgs e)
        {
            if (_queue.Count > 0)
            {
                _queue.Dequeue();
                UpdateContents();
            }
        }

        private void UpdateContents()
        {
            _stackContents.Text = "Stack Contents: " + string.Join(", ", _stack);
            _queueContents.Text = "Queue Contents: " + string.Join(", ", _queue);
        }
    }
}