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


    /* Flatland.Context interface */

    public Flatland.Context SetLineColor(Flatland.Color color)
    {
        return new Context(this, ToCairoColor(color), this.currentFillColor);
    }

    public Flatland.Context SetFillColor(Flatland.Color color)
    {
        return new Context(this, this.currentLineColor, ToCairoColor(color));
    }

    public void DrawLine(double ax, double ay, double bx, double by)
    {
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.MoveTo(ax, ay);
        context.LineTo(bx, by);
        context.Stroke();
    }

    public void DrawArc(double x, double y, double radius, double startAngle, double sweepAngle)
    {
        context.NewSubPath();
        context.LineWidth = 1.0;
        context.SetSourceColor(currentLineColor);
        context.Arc(x, y, radius, startAngle, startAngle + sweepAngle);
        context.Stroke();
    }
}

}
