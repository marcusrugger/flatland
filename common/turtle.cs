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

    public Flatland.Turtle MoveTo(int x, int y)
    {
        return MoveTo(new Cartesian(x, y));
    }

    public Flatland.Turtle MoveTo(double x, double y)
    {
        return MoveTo(new Cartesian(x, y));
    }

    public Flatland.Turtle MoveTo(Point position)
    {
        return MoveTo(position.ToCartesian());
    }

    public Flatland.Turtle MoveTo(Cartesian position)
    {
        return CloneWith(position);
    }

    public Flatland.Turtle Move(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return MoveTo(newPosition);
    }

    public Flatland.Turtle TurnTo(double angle)
    {
        return CloneWith(angle);
    }

    public Flatland.Turtle Turn(double angle)
    {
        return TurnTo(this.angle + angle);
    }

    public Flatland.Turtle LineTo(int x, int y)
    {
        return LineTo(new Cartesian(x, y));
    }

    public Flatland.Turtle LineTo(double x, double y)
    {
        return LineTo(new Cartesian(x, y));
    }

    public Flatland.Turtle LineTo(Point position)
    {
        return LineTo(position.ToCartesian());
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

    protected void Draw(Point p1, Point p2)
    {
        canvas.Context.DrawLine(p1, p2);
    }

    protected void Draw(Cartesian p1, Cartesian p2)
    {
        Draw(p1.ToPoint(), p2.ToPoint());
    }

    protected Flatland.Turtle CloneWith(Cartesian newPosition)
    {
        return new Turtle(this, newPosition);
    }

    protected Flatland.Turtle CloneWith(double newAngle)
    {
        return new Turtle(this, newAngle);
    }

}

}
