using System;

namespace Flatland {


public interface Canvas
{
    Canvas SetTransformer(Transformer transformer);
    Canvas SetLineColor(Color color);
    Canvas SetFillColor(Color color);

    Turtle Turtle();
    Wireframe Wireframe();
}

}
