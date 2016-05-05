using System;

namespace Flatland {


public interface Canvas
{
    Canvas SetLineColor(Color color);
    Canvas SetFillColor(Color color);

    Turtle Turtle();
    Wireframe Wireframe();
}

}
