using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AppAvaloniaButtonClick.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ClickHandlerButton1(object sender, RoutedEventArgs args)
    {
        message.Text = "Button 1 clicked!....";

    }

    public void ClickHandlerButton2(object sender, RoutedEventArgs args)
    {
        Button1.IsEnabled = false;
        message.Text = "Button 2 clicked and Button1 disabled";
    }
}