using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Turtle : Flatland.Common.Turtle
{
    Context context;

    public Turtle(Context context)
    {
        this.context = context;
    }

    public Turtle(Turtle other, Context newContext) : base()
    {
        this.context = newContext;
    }

    private Turtle(Turtle other, Cartesian position) : base(other, position)
    {
        this.context = other.context;
    }

    private Turtle(Turtle other, double angle) : base(other, angle)
    {
        this.context = other.context;
    }

    public override Flatland.Turtle SetLineColor(Color color)
    {
        var newContext = context.SetPen(color);
        return new Turtle(this, newContext);
    }

    protected override void Draw(Cartesian p1, Cartesian p2)
    {
        context.Graphics.DrawLine(context.CurrentPen, ToPoint(p1), ToPoint(p2));
    }

    protected override Flatland.Turtle CloneWith(Cartesian newPosition)
    {
        return new Turtle(this, newPosition);
    }

    protected override Flatland.Turtle CloneWith(double newAngle)
    {
        return new Turtle(this, newAngle);
    }

    private Drawing.Point ToPoint(Cartesian realPt)
    {
        int x = (int) (realPt.X + 0.5);
        int y = (int) (realPt.Y + 0.5);
        return new Drawing.Point(x, y);
    }
}

}
