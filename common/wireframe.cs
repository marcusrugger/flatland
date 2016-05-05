using System;

namespace Flatland.Common {


public class Wireframe : Graphics, Flatland.Wireframe
{
    public static Wireframe Create(Context context)
    {
        return new Wireframe(context);
    }

    private Wireframe(Context context) : base(context)
    {}

    public Flatland.Wireframe SetLineColor(Color color)
    {
        return new Wireframe( SetContextLineColor(color) );
    }

    public Flatland.Wireframe Line(double x1, double y1, double x2, double y2)
    {
        return Line(new Cartesian(x1, y1), new Cartesian(x2, y2));
    }

    public Flatland.Wireframe Line(Cartesian p1, Cartesian p2)
    {
        DrawLine(p1, p2);
        return this;
    }

    public Flatland.Wireframe Circle(double x, double y, double r)
    {
        return Circle(new Cartesian(x, y), r);
    }

    public Flatland.Wireframe Circle(Cartesian p, double r)
    {
        DrawCircle(p, r);
        return this;
    }
}

}