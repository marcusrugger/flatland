using System;

namespace Flatland.Common {


public interface Context
{
    Context SetLineColor(Color color);
    Context SetFillColor(Color color);

    void DrawLine(Coordinate a, Coordinate b);
    void DrawArc(Coordinate point, double radius, double startAngle, double sweepAngle);
}

}
