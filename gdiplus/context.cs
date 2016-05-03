using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Context : Flatland.Context
{
    readonly Drawing.Graphics    graphics;
    readonly Drawing.Pen         currentPen;
    readonly Drawing.Brush       currentBrush;
    
    public static Context Create(Drawing.Graphics graphics)
    {
        return new Context(graphics);
    }

    private Context(Drawing.Graphics graphics) : base()
    {
        this.graphics       = graphics;
        this.currentPen     = Drawing.Pens.Black;
        this.currentBrush   = Drawing.Brushes.White;
    }

    private Context(Context other, Drawing.Pen newPen)
    {
        this.graphics       = other.graphics;
        this.currentPen     = newPen;
        this.currentBrush   = other.currentBrush;
    }

    private Context(Context other, Drawing.Brush newBrush)
    {
        this.graphics       = other.graphics;
        this.currentPen     = other.currentPen;
        this.currentBrush   = newBrush;
    }

    private Drawing.Brush CreateGdiBrush(Flatland.Color color)
    {
        return new Drawing.SolidBrush( ToGdiColor(color) );
    }

    private Drawing.Pen CreateGdiPen(Flatland.Color color)
    {
        return new Drawing.Pen( ToGdiColor(color) );
    }

    private Drawing.Color ToGdiColor(Flatland.Color color)
    {
        var colorb = color.ToColorB();
        return Drawing.Color.FromArgb( colorb.Alpha, colorb.Red, colorb.Green, colorb.Blue );
    }
    

    /* Flatland.Context interface */

    public Flatland.Context SetLineColor(Flatland.Color color)
    {
        return new Context( this, CreateGdiPen(color) );
    }

    public Flatland.Context SetFillColor(Color color)
    {
        return new Context( this, CreateGdiBrush(color) );
    }

    public void DrawLine(double ax, double ay, double bx, double by)
    {
        graphics.DrawLine(currentPen, (int) ax, (int) ay, (int) bx, (int) by);
    }

    public void DrawArc(double x, double y, double radius, double startAngle, double sweepAngle)
    {
        Drawing.RectangleF rect = new Drawing.RectangleF((float) (x - radius),
                                                         (float) (y - radius),
                                                         (float) (2 * radius),
                                                         (float) (2 * radius));

        float a = (float) Algorithms.ToDegrees(startAngle);
        float b = (float) Algorithms.ToDegrees(sweepAngle);
        graphics.DrawArc(currentPen, rect, a, b);
    }
}

}
