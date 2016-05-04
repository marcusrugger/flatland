using Cairo;
using System;

namespace Flatland.CairoGraphics {


public class Context : Flatland.Context
{
    readonly Cairo.Context context;
    readonly Cairo.Color currentLineColor;
    readonly Cairo.Color currentFillColor;

    readonly Transformer transformer;


    public static Context Create(Cairo.Context context)
    {
        return new Context(context);
    }

    public static Context Create(Cairo.Context context, Transformer transformer)
    {
        return new Context(context, transformer);
    }

    private Context(Cairo.Context context) : this(context, new Transformer())
    {}

    private Context(Cairo.Context context, Transformer transformer)
    {
        this.context            = context;
        this.currentLineColor   = new Cairo.Color(0.0, 0.0, 0.0);
        this.currentFillColor   = new Cairo.Color(1.0, 1.0, 1.0);
        this.transformer        = transformer;
    }

    private Context(Context other, Cairo.Color colorLine, Cairo.Color colorFill)
    {
        this.context            = other.context;
        this.currentLineColor   = colorLine;
        this.currentFillColor   = colorFill;
        this.transformer        = other.transformer;
    }

    private Cairo.Color ToCairoColor(Flatland.Color color)
    {
        var colord = color.ToColorD();
        return new Cairo.Color( colord.Red, colord.Green, colord.Blue, colord.Alpha );
    }
    
    private Cairo.PointD ToCairoPoint(Coordinate point)
    {
        Cartesian p = transformer.Transform( point.ToCartesian() );
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
        var pt1 = ToCairoPoint(a);
        var pt2 = ToCairoPoint(b);

        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.MoveTo(pt1);
        context.LineTo(pt2);
        context.Stroke();
    }

    public void DrawArc(Coordinate point, double radius, double startAngle, double sweepAngle)
    {
        var pt = ToCairoPoint(point);

        context.NewSubPath();
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.Arc(pt.X, pt.Y, radius, startAngle, startAngle + sweepAngle);
        context.Stroke();
    }
}

}
