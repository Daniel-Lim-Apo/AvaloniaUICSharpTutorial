using AppAvaloniaBulletShot.Views;
using Avalonia;
using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AppAvaloniaBulletShot.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private Rect _rectangle1Bounds = new Rect(650, 650, 100, 100);
    private Rect _rectangle2Bounds = new Rect(700, 625, 100, 100);

    public Rect Rectangle1Bounds
    {
        get => _rectangle1Bounds;
        set
        {
            _rectangle1Bounds = value;
            OnPropertyChanged();
        }
    }

    public Rect Rectangle2Bounds
    {
        get => _rectangle2Bounds;
        set
        {
            _rectangle2Bounds = value;
            OnPropertyChanged();
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // Method to move the rectangles and check for collision
    public void MoveRectangles()
    {
        // Move logic here (e.g., change Rectangle1Bounds and Rectangle2Bounds)
        // Check for collision
        if (Rectangle1Bounds.Intersects(Rectangle2Bounds))
        {
            // Handle collision
        }
    }

    public void MoveRectangle1(int deltaX, int deltaY)
    {
        var newRect = new Rect(Rectangle1Bounds.X + deltaX, Rectangle1Bounds.Y + deltaY, Rectangle1Bounds.Width, Rectangle1Bounds.Height);
        Rectangle1Bounds = newRect;

        // Check for collision
        if (Rectangle1Bounds.Intersects(Rectangle2Bounds))
        {
            // Handle collision (e.g., change color, display a message, etc.)
            var newRect2 = new Rect(Rectangle2Bounds.X + deltaX + 100, Rectangle2Bounds.Y + deltaY + 100, Rectangle2Bounds.Width, Rectangle2Bounds.Height);
            Rectangle2Bounds = newRect2;
        }
    }

    public void MoveRectangle2(int deltaX, int deltaY)
    {
        var newRect2 = new Rect(Rectangle2Bounds.X + deltaX, Rectangle2Bounds.Y + deltaY, Rectangle2Bounds.Width, Rectangle2Bounds.Height);
        Rectangle2Bounds = newRect2;

        // Check for collision
        if (Rectangle2Bounds.Intersects(Rectangle1Bounds))
        {
            // Handle collision (e.g., change color, display a message, etc.)
            var newRect1 = new Rect(Rectangle1Bounds.X + deltaX + 100, Rectangle1Bounds.Y + deltaY + 100, Rectangle1Bounds.Width, Rectangle1Bounds.Height);
            Rectangle1Bounds = newRect1;
        }
    }

    public async void Shot(double boundsTop, double boundsBottom, Control control)    
    {
        double shotY = Rectangle2Bounds.Y;
        var speed = 10;
        while (true)
        {
            
            //var control = MainWindow.FindControl<TextBlock>("Rectangle2");
            //double nextPos = Canvas.GetTop(control) + speed;
            //double maxHigh = boundsTop;

            var newRect = new Rect(Rectangle2Bounds.X, shotY, Rectangle2Bounds.Width, Rectangle2Bounds.Height);
            Rectangle2Bounds = newRect;
            //Thread.Sleep(100);
            shotY = shotY - speed;

            if ( shotY <= boundsTop || shotY >= boundsBottom ) {
                speed *= -1; 
            }

            // Check boundaries and reverse direction if necessary

                //if (nextPos <= 0 || nextPos >= maxHigh - control.Bounds.Top)
                //{
                //    speed *= -1;
                //}

                //Canvas.SetLeft(control, nextPos);

            await Task.Delay(16); // Roughly 60 FPS
        }



        //


        //while (shotY > 0)
        //{
        //    var newRect = new Rect(Rectangle2Bounds.X, shotY, Rectangle2Bounds.Width, Rectangle2Bounds.Height);
        //    Rectangle2Bounds = newRect;
        //    Thread.Sleep(1000);
        //    shotY = shotY - 10 ;
        //}   

        // Check for collision
        //if (Rectangle2Bounds.Intersects(Target1Bounds))
        //{
        //    // Handle collision (e.g., change color, display a message, etc.)
        //    var newRect2 = new Rect(Rectangle2Bounds.X + deltaX + 100, Rectangle2Bounds.Y + deltaY + 100, Rectangle2Bounds.Width, Rectangle2Bounds.Height);
        //    Rectangle2Bounds = newRect2;
        //}
    }

    //private async Task StartAnimation()
    //{
    //    //while (true)
    //    //{
    //    //        var control = MainWindow.FindControl<TextBlock>("Rectangle2");
    //    //        double nextPos = Canvas.GetLeft() + speeds[i];
    //    //        double maxWidth = this.Bounds.Width;

    //    //        // Check boundaries and reverse direction if necessary
    //    //        if (nextPos <= 0 || nextPos >= maxWidth - control.Bounds.Width)
    //    //        {
    //    //            speeds[i] *= -1;
    //    //        }

    //    //        Canvas.SetLeft(control, nextPos);

    //    //    await Task.Delay(16); // Roughly 60 FPS
    //    //}
    //}
}
