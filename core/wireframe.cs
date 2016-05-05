using System;

namespace Flatland.Core {


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
        return new Wireframe( Context.SetLineColor(color) );
    }

    public Flatland.Wireframe Line(double x1, double y1, double x2, double y2)
    {
        Context.DrawLine(new Cartesian(x1, y1), new Cartesian(x2, y2));
        return this;
    }

    public Flatland.Wireframe Line(Cartesian p1, Cartesian p2)
    {
        Context.DrawLine(p1, p2);
        return this;
    }

    public Flatland.Wireframe Rectangle(double x1, double y1, double width, double height)
    {
        return Rectangle(new Cartesian(x1, y1), width, height);
    }

    public Flatland.Wireframe Rectangle(Cartesian p1, double width, double height)
    {
        return Rectangle(p1, p1.Offset(width, height));
    }

    private Flatland.Wireframe Rectangle(Cartesian p11, Cartesian p22)
    {
        var p12 = new Cartesian(p11.X, p22.Y);
        var p21 = new Cartesian(p22.X, p11.Y);
        Context.DrawLine(p11, p12);
        Context.DrawLine(p12, p22);
        Context.DrawLine(p22, p21);
        Context.DrawLine(p21, p11);
        return this;
    }

    public Flatland.Wireframe Circle(double x, double y, double r)
    {
        Context.DrawArc(new Cartesian(x, y), r, 0.0, 2*Math.PI);
        return this;
    }

    public Flatland.Wireframe Circle(Cartesian p, double r)
    {
        Context.DrawArc(p, r, 0.0, 2*Math.PI);
        return this;
    }
}

}