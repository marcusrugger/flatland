using System;
using System.Drawing;

using Drawing = System.Drawing;

namespace Flatland.GdiPlus {


public class Canvas : Flatland.Canvas
{
    Context context;
    
    public static Canvas Create(Context context)
    {
        return new Canvas(context);
    }

    private Canvas(Context context)
    {
        this.context = context;
    }

    public Context Context
    {
        get { return context; }
    }
    

    /* Flatland.Canvas interface */

    public Flatland.Canvas SetLineColor(Flatland.Color color)
    {
        return new Canvas(context.SetPen(color));
    }

    public Flatland.Canvas SetFillColor(Color color)
    {
        return new Canvas(context.SetBrush(color));
    }

    public Flatland.Turtle NewTurtle()
    {
        return new Turtle(this);
    }
}

}
