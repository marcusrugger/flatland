using System;

namespace Flatland {


public interface Geometry
{
    Geometry SetLineColor(Color color);

    Geometry Line(double x1, double y1, double x2, double y2);
    Geometry Line(Cartesian p1, Cartesian p2);
}

}