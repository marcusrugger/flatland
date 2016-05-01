using System;

namespace Flatland {


// class Point<T>
// {
//     readonly T x;
//     readonly T y;

//     public Point()
//     {}
    
//     public Point(T x, T y)
//     {
//         this.x = x;
//         this.y = y;
//     }
    
//     public Point<T> SetX(T x)
//     {
//         return new Point<T>(x, this.y);
//     }
    
//     public Point<T> SetY(T y)
//     {
//         return new Point<T>(this.x, y);
//     }
    
//     public Point<T> SetXY(T x, T y)
//     {
//         return new Point<T>(x, y);
//     }
    
//     public Point<T> Offset(Point<T> p)
//     {
//         return new Point<T>(x + p.x, y + p.y);
//     }
    
//     public Point<T> Offset(T x, T y)
//     {
//         return new Point<T>(this.x + x, this.y + y);
//     }

//     T X { get { return x; } }
//     T Y { get { return y; } }
// }


// class DrawLine
// {
//     readonly Color color;
//     readonly Point pointStart;
//     readonly Point pointEnd;


//     public DrawLine()
//     {
//         color      = new ColorRGB(0, 0, 0);
//         pointStart = new PointInt();
//         pointEnd   = new PointInt();
//     }
    
//     public DrawLine(DrawLine other)
//     {
//         this.color      = other.color;
//         this.pointStart = other.pointStart;
//         this.pointEnd   = other.pointEnd;
//     }
    
//     private DrawLine(DrawLine other, Color color)
//     {
//         this.color      = color;
//         this.pointStart = other.pointStart;
//         this.pointEnd   = other.pointEnd;
//     }
    
//     private DrawLine(DrawLine other, Point startPt, Point endPt)
//     {
//         this.color      = other.color;
//         this.pointStart = startPt;
//         this.pointEnd   = endPt;
//     }

//     public DrawLine SetColor(Color color)
//     {
//         return new DrawLine(this, color);
//     }

//     public DrawLine SetColor(byte red, byte green, byte blue)
//     {
//         return new DrawLine(this, new ColorRGB(red, green, blue));
//     }
    
//     public DrawLine SetStartPoint(Point pt)
//     {
//         return new DrawLine(this, pt, pointEnd);
//     }

//     public DrawLine SetEndPoint(Point pt)
//     {
//         return new DrawLine(this, pointStart, pt);
//     }

//     public DrawLine SetPoints(Point startPt, Point endPt)
//     {
//         return new DrawLine(this, startPt, endPt);
//     }
// }

}
