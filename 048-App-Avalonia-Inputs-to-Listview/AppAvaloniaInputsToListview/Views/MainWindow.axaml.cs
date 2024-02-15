using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace AppAvaloniaInputsToListview.Views
{
    public partial class MainWindow : Window
    {
        public class Submission
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
        }

        private List<Submission> Submissions = new List<Submission>();

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var input1 = this.FindControl<TextBox>("InputField1").Text;
            var input2 = this.FindControl<TextBox>("InputField2").Text;

            Submissions.Add(new Submission { Field1 = input1, Field2 = input2 });

            var control = this.FindControl<ListBox>("ListBoxDisplay");

            if (control != null)
            { 
                foreach (var  submission in Submissions) { 
                    control.Items.Add(submission.);
                }
            }
        }
    }
}