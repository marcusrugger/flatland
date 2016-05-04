using System;

namespace Flatland.Common {


public class Wireframe : Flatland.Wireframe
{
    readonly Context context;

    public static Wireframe Create(Context context)
    {
        return new Wireframe(context);
    }

    private Wireframe(Context context)
    {
        this.context = context;
    }

    public Flatland.Wireframe SetLineColor(Color color)
    {
        return new Wireframe( context.SetLineColor(color) );
    }

    public Flatland.Wireframe Line(double x1, double y1, double x2, double y2)
    {
        return Line(new Cartesian(x1, y1), new Cartesian(x2, y2));
    }

    public Flatland.Wireframe Line(Cartesian p1, Cartesian p2)
    {
        context.DrawLine(p1, p2);
        return this;
    }

    public Flatland.Wireframe Circle(double x, double y, double r)
    {
        return Circle(new Cartesian(x, y), r);
    }

    public Flatland.Wireframe Circle(Cartesian p, double r)
    {
        context.DrawArc(p, r, 0.0, 2*Math.PI);
        return this;
    }
}

}