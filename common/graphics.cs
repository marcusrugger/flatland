using System;

namespace Flatland.Common {


public class Graphics
{
    readonly Context context;
    
    protected Graphics(Context context)
    {
        this.context = context;
    }

    protected Graphics(Graphics other)
    {
        this.context = other.context;
    }

    protected Graphics(Graphics other, Context context)
    {
        this.context = context;
    }

    public Context SetContextLineColor(Color color)
    {
        return context.SetLineColor(color);
    }

    public Context SetContextFillColor(Color color)
    {
        return context.SetFillColor(color);
    }

    protected void DrawLine(Cartesian pt1, Cartesian pt2)
    {
        context.DrawLine(pt1, pt2);
    }
    
    protected void DrawRectangle(Cartesian pt1, Cartesian pt2)
    {
        Cartesian c12 = new Cartesian(pt1.X, pt2.Y);
        Cartesian c21 = new Cartesian(pt2.X, pt1.Y);

        context.DrawLine(pt1, c12);
        context.DrawLine(c12, pt2);
        context.DrawLine(pt2, c21);
        context.DrawLine(c21, pt1);
    }

    protected void DrawArc(Cartesian point, double radius, double angle, double sweep)
    {
        context.DrawArc(point, radius, angle, sweep);
    }
    
    protected void DrawCircle(Cartesian point, double radius)
    {
        context.DrawArc(point, radius, 0.0, 2*Math.PI);
    }
}

}
