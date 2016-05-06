using System;

namespace Flatland {


public class Polar : Coordinate
{
    readonly double a;
    readonly double r;

    public Polar(double a, double r)
    {
        this.a = a;
        this.r = r;
    }

    public Polar(Point p) : this(p.ToCartesian())
    {}

    public Polar(Cartesian p)
    {
        this.a = SafeAtan(p);
        this.r = Math.Sqrt(p.X * p.X + p.Y * p.Y);
    }

    private double SafeAtan(Cartesian p)
    {
        if (Math.Abs(p.X) > 1e-9)
            return AtanByQuadrant(p);
        else
            return AtanPointOnYAxis(p);
    }

    private double AtanByQuadrant(Cartesian p)
    {
        double result = Math.Atan(p.Y / p.X);

        if (p.X < 0.0)
            result += Math.PI;
        else if (p.Y < 0.0)
            result += 2*Math.PI;

        return result;
    }

    private double AtanPointOnYAxis(Cartesian p)
    {
        if (p.Y >= 0.0)
            return Math.PI / 2.0;
        else
            return 3.0 * Math.PI / 2.0;
    }

    public Polar TransformR(Func<double, double> fn)
    {
        return new Polar(a, fn(r));
    }

    public Point ToPoint()
    {
        return new Point(this);
    }

    public Polar ToPolar()
    {
        return this;
    }

    public Cartesian ToCartesian()
    {
        return new Cartesian(this);
    }

    public double A { get { return a; } }
    public double R { get { return r; } }
}

}
