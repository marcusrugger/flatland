using System;

namespace Flatland.Common {


public class Turtle : Flatland.Turtle
{
    Flatland.Canvas canvas;
    Cartesian position;
    double angle;

    public static Turtle Create(Flatland.Canvas canvas)
    {
        return new Turtle(canvas);
    }

    private Turtle(Flatland.Canvas canvas)
    {
        this.canvas   = canvas;
        this.position = new Cartesian();
        this.angle    = 0;
    }

    private Turtle(Turtle other)
    {
        this.canvas   = other.canvas;
        this.position = other.position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, Flatland.Canvas canvas)
    {
        this.canvas   = canvas;
        this.position = other.position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, Cartesian position)
    {
        this.canvas   = other.canvas;
        this.position = position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, double angle)
    {
        this.canvas   = other.canvas;
        this.position = other.position;
        this.angle    = angle;
    }

    public Flatland.Turtle SetLineColor(Color color)
    {
        return new Turtle( this, canvas.SetLineColor(color) );
    }

    public Flatland.Turtle MoveTo(double x, double y)
    {
        return MoveTo(new Cartesian(x, y));
    }

    public Flatland.Turtle MoveTo(Cartesian position)
    {
        return new Turtle(this, position);
    }

    public Flatland.Turtle Move(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return MoveTo(newPosition);
    }

    public Flatland.Turtle TurnTo(double angle)
    {
        return new Turtle(this, angle);
    }

    public Flatland.Turtle Turn(double angle)
    {
        return TurnTo(this.angle + angle);
    }

    public Flatland.Turtle LineTo(double x, double y)
    {
        return LineTo(new Cartesian(x, y));
    }

    public Flatland.Turtle LineTo(Cartesian position)
    {
        Draw(this.position, position);
        return MoveTo(position);
    }

    public Flatland.Turtle Line(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return LineTo(newPosition);
    }

    protected void Draw(Cartesian p1, Cartesian p2)
    {
        canvas.Context.DrawLine(p1, p2);
    }

}

}
