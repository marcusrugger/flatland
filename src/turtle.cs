using System;

namespace Flatland {


class Turtle
{
    Cartesian position;
    double angle;

    public Turtle()
    {
        position = new Cartesian();
        angle    = 0;
    }
    
    public Turtle(Turtle other, Cartesian position)
    {
        this.position = position;
        this.angle    = other.angle;
    }
    
    public Turtle(Turtle other, double angle)
    {
        this.position = other.position;
        this.angle    = angle;
    }

    public Turtle MoveTo(Cartesian position)
    {
        return new Turtle(this, position);
    }

    public Turtle Move(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return MoveTo(newPosition);
    }
    
    public Turtle TurnTo(double angle)
    {
        return new Turtle(this, angle);
    }

    public Turtle Turn(double angle)
    {
        return TurnTo(this.angle + angle);
    }

    public Turtle LineTo(Cartesian position)
    {
        Draw(this.position, position);
        return new Turtle(this, position);
    }

    public Turtle Line(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return LineTo(newPosition);
    }

    private void Draw(Cartesian p1, Cartesian p2)
    {}
}

}