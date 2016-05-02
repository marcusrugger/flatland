using System;

namespace Flatland {


public interface Wireframe
{
    Wireframe SetLineColor(Color color);

    Wireframe Line(double x1, double y1, double x2, double y2);
    Wireframe Line(Cartesian p1, Cartesian p2);
    Wireframe Circle(double x, double y, double r);
    Wireframe Circle(Cartesian p, double r);
}

}