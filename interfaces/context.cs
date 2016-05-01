using System;

namespace Flatland {


public interface Context
{
    Context SetLineColor(Color color);
    Context SetFillColor(Color color);
    Turtle NewTurtle();
}

}
