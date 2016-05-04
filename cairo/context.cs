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
        this.currentFillColor   = new Cairo.Color(1.0, 1.0, 1.0);
    }

    private Context(Context other, Cairo.Color colorLine, Cairo.Color colorFill)
    {
        this.context            = other.context;
        this.currentLineColor   = colorLine;
        this.currentFillColor   = colorFill;
    }

    private Cairo.Color ToCairoColor(Flatland.Color color)
    {
        var colord = color.ToColorD();
        return new Cairo.Color( colord.Red, colord.Green, colord.Blue, colord.Alpha );
    }
    
    private Cairo.PointD ToCairoPoint(Coordinate point)
    {
        Cartesian p = point.ToCartesian();
        return new Cairo.PointD(p.X, p.Y);
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

    public void DrawLine(Coordinate a, Coordinate b)
    {
        Cairo.PointD pt1 = ToCairoPoint(a);
        Cairo.PointD pt2 = ToCairoPoint(b);

        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.MoveTo(pt1);
        context.LineTo(pt2);
        context.Stroke();
    }

    public void DrawArc(Coordinate point, double radius, double startAngle, double sweepAngle)
    {
        Cairo.PointD pt = ToCairoPoint(point);

        context.NewSubPath();
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.Arc(pt.X, pt.Y, radius, startAngle, startAngle + sweepAngle);
        context.Stroke();
    }
}

}
