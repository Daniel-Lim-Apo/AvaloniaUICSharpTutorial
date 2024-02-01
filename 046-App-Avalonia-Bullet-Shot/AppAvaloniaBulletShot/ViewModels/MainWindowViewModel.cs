using Avalonia;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppAvaloniaBulletShot.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private Rect _rectangle1Bounds = new Rect(200, 150, 100, 100);
    private Rect _rectangle2Bounds = new Rect(300, 300, 100, 100);

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

}
