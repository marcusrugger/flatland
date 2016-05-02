using System;

namespace Flatland {


public interface Context
{
    Context SetLineColor(Color color);
    Context SetFillColor(Color color);

    void DrawLine(Point p1, Point p2);
    void DrawLine(Cartesian p1, Cartesian p2);
}

}
