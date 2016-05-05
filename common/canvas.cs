using System;

namespace Flatland.Common {


public class Canvas : Flatland.Canvas
{
    readonly Context context;
    
    public static Canvas Create(Context context)
    {
        return new Canvas(context);
    }

    private Canvas(Context context)
    {
        this.context = context;
    }
    

    /* Flatland.Canvas interface */

    public Flatland.Canvas SetLineColor(Color color)
    {
        return new Canvas( context.SetLineColor(color) );
    }

    public Flatland.Canvas SetFillColor(Color color)
    {
        return new Canvas( context.SetFillColor(color) );
    }

    public Flatland.Turtle Turtle()
    {
        return Common.Turtle.Create(context);
    }

    public Flatland.Wireframe Wireframe()
    {
        return Common.Wireframe.Create(context);
    }
}

}
