using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace AppAvaloniaMoveControl.Views;

public partial class MainWindow : Window
{
        private readonly Control _bottomControl;
        private double _bottomControlLeft;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _bottomControl = this.FindControl<Control>("BottomControl");
            _bottomControlLeft = 0;

            this.KeyDown += MainWindow_KeyDown;

            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            const double moveStep = 30.0;

            switch (e.Key)
            {
                case Key.Left:
                    MoveControl(-moveStep);
                    break;
                case Key.Right:
                    MoveControl(moveStep);
                    break;
            }
        }

        private void MoveControl(double offset)
        {
            _bottomControlLeft += offset;
            Canvas.SetLeft(_bottomControl, _bottomControlLeft);
        }
    }

