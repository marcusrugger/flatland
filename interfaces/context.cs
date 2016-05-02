using System;

namespace Flatland {


public interface Context
{
    Context SetLineColor(Color color);
    Context SetFillColor(Color color);

    void DrawLine(Cartesian p1, Cartesian p2);
    void DrawArc(Cartesian point, double radius, double startAngle, double sweepAngle);
}

}
