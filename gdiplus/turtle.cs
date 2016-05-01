using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Turtle : Flatland.Common.Turtle
{
    Drawing.Graphics graphics;
    Drawing.Pen pen;

    public Turtle(Context context)
    {
        graphics = context.Graphics;
        pen      = context.CurrentPen;
    }

    private Turtle(Turtle other, Cartesian position) : base(other, position)
    {
        graphics = other.graphics;
        pen = other.pen;
    }

    private Turtle(Turtle other, double angle) : base(other, angle)
    {
        graphics = other.graphics;
        pen = other.pen;
    }

    protected override void Draw(Cartesian p1, Cartesian p2)
    {
        graphics.DrawLine(pen, ToPoint(p1), ToPoint(p2));
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
        int x = (int) (realPt.x + 0.5);
        int y = (int) (realPt.y + 0.5);
        return new Drawing.Point(x, y);
    }
}

}
