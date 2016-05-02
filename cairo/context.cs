using Cairo;
using System;

namespace Flatland.CairoGraphics {


public class Context : Flatland.Context
{
    readonly Cairo.Context context;
    readonly Cairo.Color currentLineColor;
    readonly Cairo.Color currentFillColor;

    public static Context Create(Cairo.Context context)
    {
        return new Context(context);
    }

    private Context(Cairo.Context context)
    {
        this.context            = context;
        this.currentLineColor   = new Cairo.Color(0.0, 0.0, 0.0);
    }

    private Context(Context other, Cairo.Color colorLine, Cairo.Color colorFill)
    {
        this.context            = other.context;
        this.currentLineColor   = colorLine;
        this.currentFillColor   = colorFill;
    }

    private Cairo.Color ToCairoColor(Flatland.Color color)
    {
        return new Cairo.Color( ToUnitDouble(color.Red), ToUnitDouble(color.Green), ToUnitDouble(color.Blue) );
    }

    private double ToUnitDouble(byte value)
    {
        return ((double) value) / 255.0;
    }


    /* Flatland.Context interface */

    public Flatland.Context SetLineColor(Flatland.Color color)
    {
        return new Context(this, ToCairoColor(color), this.currentFillColor);
    }

    public Flatland.Context SetFillColor(Flatland.Color color)
    {
        return new Context(this, this.currentLineColor, ToCairoColor(color));
    }

    public void DrawLine(Cartesian p1, Cartesian p2)
    {
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.MoveTo(p1.X, p1.Y);
        context.LineTo(p2.X, p2.Y);
        context.Stroke();
    }

    public void DrawArc(Cartesian point, double radius, double startAngle, double sweepAngle)
    {
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.Arc(point.X, point.Y, radius, startAngle, startAngle + sweepAngle);
        context.Stroke();
    }
}

}
