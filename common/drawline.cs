using System;

namespace Flatland {


class DrawLine
{
    readonly Context context;
    readonly Color color;
    readonly Point pointStart;
    readonly Point pointEnd;


    public DrawLine()
    {
        color      = new ColorRGB(0, 0, 0);
        pointStart = new Point();
        pointEnd   = new Point();
    }
    
    public DrawLine(Context context)
    {
        this.context = context;
        this.color   = context.DefaultColor;
    }
    
    public DrawLine(DrawLine other)
    {
        this.color      = other.color;
        this.pointStart = other.pointStart;
        this.pointEnd   = other.pointEnd;
    }
    
    private DrawLine(DrawLine other, Color color)
    {
        this.color      = color;
        this.pointStart = other.pointStart;
        this.pointEnd   = other.pointEnd;
    }
    
    private DrawLine(DrawLine other, Point startPt, Point endPt)
    {
        this.color      = other.color;
        this.pointStart = startPt;
        this.pointEnd   = endPt;
    }

    public DrawLine SetColor(Color color)
    {
        return new DrawLine(this, color);
    }

    public DrawLine SetColor(byte red, byte green, byte blue)
    {
        return new DrawLine(this, new ColorRGB(red, green, blue));
    }
    
    public DrawLine SetStartPoint(Point pt)
    {
        return new DrawLine(this, pt, pointEnd);
    }

    public DrawLine SetEndPoint(Point pt)
    {
        return new DrawLine(this, pointStart, pt);
    }

    public DrawLine SetPoints(Point startPt, Point endPt)
    {
        return new DrawLine(this, startPt, endPt);
    }

    public virtual void Draw()
    {}

}

}
