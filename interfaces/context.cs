using System;

namespace Flatland {


public interface Context
{
    Context SetLineColor(Color color);
    Context SetFillColor(Color color);

    void DrawLine(double ax, double ay, double bx, double by);
    void DrawArc(double x, double y, double radius, double startAngle, double sweepAngle);
}

}
