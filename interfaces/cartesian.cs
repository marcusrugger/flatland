using System;

namespace Flatland {


public class Cartesian
{
    readonly double x;
    readonly double y;
    
    public Cartesian()
    {
        x = 0;
        y = 0;
    }

    public Cartesian(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public Cartesian(Polar pc)
    {
        x = pc.R * Math.Cos(pc.A);
        y = pc.R * Math.Sin(pc.A);
    }
    
    public Cartesian(Point p)
    {
        x = p.X;
        y = p.Y;
    }

    public static Cartesian operator +(Cartesian ls, Cartesian rs)
    {
        return new Cartesian(ls.x + rs.x, ls.y + rs.y);
    }

    public static Cartesian operator -(Cartesian ls, Cartesian rs)
    {
        return new Cartesian(ls.x - rs.x, ls.y - rs.y);
    }

    public Cartesian Offset(Cartesian other)
    {
        return new Cartesian(x + other.x, y + other.y);
    }

    public Cartesian Scale(double magnitude)
    {
        return new Cartesian(magnitude * x, magnitude * y);
    }

    public Cartesian Transform(Func<double, double> fn)
    {
        return new Cartesian(fn(x), fn(y));
    }

    public Polar ToPolar()
    {
        return new Polar(this);
    }

    public double X { get { return x; } }
    public double Y { get { return y; } }
}

}
