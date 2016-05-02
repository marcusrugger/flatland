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
        return Drawing.Color.FromArgb( color.Alpha, color.Red, color.Green, color.Blue );
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

    public void DrawLine(Cartesian p1, Cartesian p2)
    {
        var pt1 = p1.ToPoint();
        var pt2 = p2.ToPoint();
        graphics.DrawLine(currentPen, pt1.X, pt1.Y, pt2.X, pt2.Y);
    }

    public void DrawArc(Cartesian point, double radius, double startAngle, double sweepAngle)
    {
        Drawing.RectangleF rect = new Drawing.RectangleF((float) (point.X - radius),
                                                         (float) (point.Y - radius),
                                                         (float) (2*radius),
                                                         (float) (2*radius));

        float a = (float) Algorithms.ToDegrees(startAngle);
        float b = (float) Algorithms.ToDegrees(sweepAngle);
        graphics.DrawArc(currentPen, rect, a, b);
    }
}

}
