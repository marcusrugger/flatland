using System;

namespace Flatland.Common {


public abstract class Context : Flatland.Context
{
    public Context()
    {
    }

    public abstract Flatland.Context SetLineColor(Color color);
    public abstract Flatland.Context SetFillColor(Color color);
    public abstract Flatland.Turtle NewTurtle();
}

}