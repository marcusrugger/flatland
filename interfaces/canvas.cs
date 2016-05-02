using System;

namespace Flatland {


public interface Canvas
{

    Context Context
    { get; }

    Canvas SetLineColor(Color color);
    Canvas SetFillColor(Color color);

    Turtle Turtle();
}

}
