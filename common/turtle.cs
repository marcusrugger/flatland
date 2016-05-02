using System;

namespace Flatland.Common {


public class Turtle : Flatland.Turtle
{
    readonly Context context;
    readonly Cartesian position;
    readonly double angle;

    public static Turtle Create(Context context)
    {
        return new Turtle(context);
    }

    private Turtle(Context context)
    {
        this.context   = context;
        this.position = new Cartesian();
        this.angle    = 0;
    }

    private Turtle(Turtle other)
    {
        this.context   = other.context;
        this.position = other.position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, Context context)
    {
        this.context   = context;
        this.position = other.position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, Cartesian position)
    {
        this.context   = other.context;
        this.position = position;
        this.angle    = other.angle;
    }

    private Turtle(Turtle other, double angle)
    {
        this.context   = other.context;
        this.position = other.position;
        this.angle    = angle;
    }

    public Flatland.Turtle SetLineColor(Color color)
    {
        return new Turtle( this, context.SetLineColor(color) );
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
        context.DrawLine(this.position, position);
        return MoveTo(position);
    }

    public Flatland.Turtle Line(double distance)
    {
        var newPosition = new Polar(angle, distance).ToCartesian().Offset(position);
        return LineTo(newPosition);
    }

}

}
