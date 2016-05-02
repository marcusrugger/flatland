using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Turtle : Flatland.Common.Turtle
{
    Canvas canvas;

    public Turtle(Canvas canvas) : base()
    {
        this.canvas = canvas;
    }

    public Turtle(Turtle other, Canvas newCanvas) : base()
    {
        this.canvas = newCanvas;
    }

    private Turtle(Turtle other, Cartesian position) : base(other, position)
    {
        this.canvas = other.canvas;
    }

    private Turtle(Turtle other, double angle) : base(other, angle)
    {
        this.canvas = other.canvas;
    }

    public override Flatland.Turtle SetLineColor(Color color)
    {
        var newContext = canvas.Context.SetPen(color);
        var newCanvas  = Canvas.Create(newContext);
        return new Turtle(this, newCanvas);
    }

    protected void Draw(Point p1, Point p2)
    {
        canvas.Context.DrawLine(p1, p2);
    }

    protected override void Draw(Cartesian p1, Cartesian p2)
    {
        Draw(p1.ToPoint(), p2.ToPoint());
    }

    protected override Flatland.Turtle CloneWith(Cartesian newPosition)
    {
        return new Turtle(this, newPosition);
    }

    protected override Flatland.Turtle CloneWith(double newAngle)
    {
        return new Turtle(this, newAngle);
    }

}

}
