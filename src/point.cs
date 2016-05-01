using System;

namespace Flatland {


class Point
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

    public Point Offset(Point p)
    {
        return new Point(x + p.x, y + p.y);
    }

    public Point Offset(int x, int y)
    {
        return new Point(this.x + x, this.y + y);
    }

    public int X { get { return x; } }
    public int Y { get { return y; } }
}

}
