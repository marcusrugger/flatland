using System;

namespace Flatland.Common {


public class Turtle : Graphics, Flatland.Turtle
{
    readonly Cartesian position;
    readonly double angle;
    readonly bool penDown;

    public static Turtle Create(Context context)
    {
        return new Turtle(context);
    }

    private Turtle(Context context) : base(context)
    {
        this.position = new Cartesian();
        this.angle    = 0;
        this.penDown  = true;
    }

    private Turtle(Turtle other) : base(other)
    {
        this.position = other.position;
        this.angle    = other.angle;
        this.penDown  = other.penDown;
    }

    private Turtle(Turtle other, Context context) : base(other, context)
    {
        this.position = other.position;
        this.angle    = other.angle;
        this.penDown  = other.penDown;
    }

    private Turtle(Turtle other, Cartesian position) : base(other)
    {
        this.position = position;
        this.angle    = other.angle;
        this.penDown  = other.penDown;
    }

    private Turtle(Turtle other, double angle) : base(other)
    {
        this.position = other.position;
        this.angle    = angle;
        this.penDown  = other.penDown;
    }

    private Turtle(Turtle other, bool penDown) : base(other)
    {
        this.position = other.position;
        this.angle    = other.angle;
        this.penDown  = penDown;
    }

    public Flatland.Turtle SetLineColor(Color color)
    {
        return new Turtle( this, SetContextLineColor(color) );
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
        DrawLine(this.position, position);
        return MoveTo(position);
    }

    public Flatland.Turtle Line(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return LineTo(newPosition);
    }

    public Flatland.Turtle PenDown(bool flag)
    {
        return new Turtle(this, flag);
    }

    public Flatland.Turtle PenUp(bool flag)
    {
        return new Turtle(this, !flag);
    }

    public Flatland.Turtle PenToggle()
    {
        return new Turtle(this, !penDown);
    }

    public Flatland.Turtle PenMoveTo(double x, double y)
    {
        return PenMoveTo(new Cartesian(x, y));
    }

    public Flatland.Turtle PenMoveTo(Cartesian position)
    {
        if (penDown)
            return LineTo(position);
        else
            return MoveTo(position);
    }

    public Flatland.Turtle PenMove(double distance)
    {
        if (penDown)
            return Line(distance);
        else
            return Move(distance);
    }

}

}
