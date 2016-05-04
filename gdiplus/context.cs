using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Context : Flatland.Context
{
    readonly Drawing.Graphics    graphics;
    readonly Drawing.Pen         currentPen;
    readonly Drawing.Brush       currentBrush;

    readonly Transformer transfomer;


    public static Context Create(Drawing.Graphics graphics)
    {
        return new Context(graphics);
    }


    public static Context Create(Drawing.Graphics graphics, Transformer transformer)
    {
        return new Context(graphics, transformer);
    }

    private Context(Drawing.Graphics graphics) : this(graphics, new Transformer())
    {}

    private Context(Drawing.Graphics graphics, Transformer transformer)
    {
        this.graphics       = graphics;
        this.currentPen     = Drawing.Pens.Black;
        this.currentBrush   = Drawing.Brushes.White;
        this.transfomer     = transformer;
    }

    private Context(Context other, Drawing.Pen newPen)
    {
        this.graphics       = other.graphics;
        this.currentPen     = newPen;
        this.currentBrush   = other.currentBrush;
        this.transfomer     = other.transfomer;
    }

    private Context(Context other, Drawing.Brush newBrush)
    {
        this.graphics       = other.graphics;
        this.currentPen     = other.currentPen;
        this.currentBrush   = newBrush;
        this.transfomer     = other.transfomer;
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

    private Drawing.Point ToGdiPoint(Flatland.Coordinate point)
    {
        Flatland.Point fp = transfomer.Transform( point.ToCartesian() ).ToPoint();
        return new Drawing.Point(fp.X, fp.Y);
    }

    private Drawing.PointF ToGdiPointF(Flatland.Coordinate point)
    {
        Flatland.Cartesian fp = transfomer.Transform( point.ToCartesian() );
        return new Drawing.PointF((float) fp.X, (float) fp.Y);
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

    public void DrawLine(Coordinate a, Coordinate b)
    {
        var p1 = ToGdiPoint(a);
        var p2 = ToGdiPoint(b);

        graphics.DrawLine(currentPen, p1, p2);
    }

    public void DrawArc(Coordinate point, double radius, double startAngle, double sweepAngle)
    {
        var p = ToGdiPointF(point);

        Drawing.RectangleF rect = new Drawing.RectangleF( p.X - (float) radius,
                                                          p.Y - (float) radius,
                                                         2.0f * (float) radius,
                                                         2.0f * (float) radius);

        float a = (float) Algorithms.ToDegrees(startAngle);
        float b = (float) Algorithms.ToDegrees(sweepAngle);

        graphics.DrawArc(currentPen, rect, a, b);
    }
}

}
