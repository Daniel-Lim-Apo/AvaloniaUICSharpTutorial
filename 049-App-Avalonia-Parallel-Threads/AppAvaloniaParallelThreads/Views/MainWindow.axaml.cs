using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace AppAvaloniaParallelThreads.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnProcessSequentially(object sender, RoutedEventArgs e)
        {
            ResultTextSequential.Text = "Processing Sequential... wait";
            var stopwatch = Stopwatch.StartNew();
            // Assuming a batch of 10 tasks for both sequential and parallel for fair comparison
            string result = await Task.Run(() => ProcessSequentially(10));
            stopwatch.Stop();
            ResultTextSequential.Text = $"Sequential processing time: {stopwatch.ElapsedMilliseconds} ms\n{result}";
        }

        private async void OnProcessInParallel(object sender, RoutedEventArgs e)
        {
            ResultTextParallel.Text = "Processing Parallel... wait";
            var stopwatch = Stopwatch.StartNew();
            string result = await Task.Run(() => ProcessInParallel(10));
            stopwatch.Stop();
            ResultTextParallel.Text = $"Parallel processing time: {stopwatch.ElapsedMilliseconds} ms\n{result}";
        }

        private string ProcessSequentially(int numberOfTasks)
        {
            long totalMilliseconds = 0;
            for (int i = 0; i < numberOfTasks; i++)
            {
                var taskStopwatch = Stopwatch.StartNew();
                // Simulate task
                Thread.Sleep(1000); // Simulating a task
                taskStopwatch.Stop();
                totalMilliseconds += taskStopwatch.ElapsedMilliseconds;
            }
            return $"Sequential processing completed. Total time for {numberOfTasks} tasks: {totalMilliseconds} ms.";
        }

        private string ProcessInParallel(int numberOfTasks)
        {
            long totalMilliseconds = 0;
            Parallel.For(0, numberOfTasks, i =>
            {
                var taskStopwatch = Stopwatch.StartNew();
                Thread.Sleep(1000); // Simulating a task
                taskStopwatch.Stop();
                Interlocked.Add(ref totalMilliseconds, taskStopwatch.ElapsedMilliseconds);
            });
            return $"Parallel processing completed. Sum of individual tasks time for {numberOfTasks} tasks: {totalMilliseconds} ms.";
        }
    }

}