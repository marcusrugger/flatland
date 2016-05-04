using System;

namespace Flatland {


public class Point : Coordinate
{
    readonly int x;
    readonly int y;

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public Point(Polar p) : this(p.ToCartesian())
    {}

    public Point(Cartesian p)
    {
        x = (int) (p.X + 0.5);
        y = (int) (p.Y + 0.5);
    }

    public Point Offset(Point p)
    {
        return new Point(x + p.x, y + p.y);
    }

    public Point Offset(int x, int y)
    {
        return new Point(this.x + x, this.y + y);
    }

    public Point ToPoint()
    {
        return this;
    }

    public Polar ToPolar()
    {
        return new Polar(this);
    }

    public Cartesian ToCartesian()
    {
        return new Cartesian(this);
    }

    public int X { get { return x; } }
    public int Y { get { return y; } }
}

}
