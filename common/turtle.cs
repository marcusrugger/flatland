using System;

namespace Flatland.Common {


public abstract class Turtle : Flatland.Turtle
{
    Cartesian position;
    double angle;

    public Turtle()
    {
        position = new Cartesian();
        angle    = 0;
    }

    protected Turtle(Turtle other, Cartesian position)
    {
        this.position = position;
        this.angle    = other.angle;
    }

    protected Turtle(Turtle other, double angle)
    {
        this.position = other.position;
        this.angle    = angle;
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

    protected abstract void Draw(Cartesian p1, Cartesian p2);
    protected abstract Flatland.Turtle CloneWith(Cartesian newPosition);
    protected abstract Flatland.Turtle CloneWith(double newAngle);

}

}
