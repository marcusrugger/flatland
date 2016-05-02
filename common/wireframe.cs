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
        context.DrawLine(x1, y1, x2, y2);
        return this;
    }

    public Flatland.Wireframe Line(Cartesian p1, Cartesian p2)
    {
        context.DrawLine(p1.X, p1.Y, p2.X, p2.Y);
        return this;
    }

    public Flatland.Wireframe Circle(double x, double y, double r)
    {
        context.DrawArc(x, y, r, 0, 2*Math.PI);
        return this;
    }

    public Flatland.Wireframe Circle(Cartesian p, double r)
    {
        return Circle(p.X, p.Y, r);
    }
}

}