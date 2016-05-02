using System;

namespace Flatland.Common {


public class Geometry : Flatland.Geometry
{
    readonly Context context;

    public static Geometry Create(Context context)
    {
        return new Geometry(context);
    }

    private Geometry(Context context)
    {
        this.context = context;
    }

    public Flatland.Geometry SetLineColor(Color color)
    {
        return new Geometry(context.SetLineColor(color));
    }

    public Flatland.Geometry Line(double x1, double y1, double x2, double y2)
    {
        return Line(new Cartesian(x1, y1), new Cartesian(x2, y2));
    }

    public Flatland.Geometry Line(Cartesian p1, Cartesian p2)
    {
        context.DrawLine(p1, p2);
        return this;
    }

    public Flatland.Geometry Circle(double x, double y, double r)
    {
        return Circle(new Cartesian(x, y), r);
    }

    public Flatland.Geometry Circle(Cartesian p, double r)
    {
        context.DrawArc(p, r, 0, 2*Math.PI);
        return this;
    }
}

}