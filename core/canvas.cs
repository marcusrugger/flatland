using System;

namespace Flatland.Core {


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

    public Flatland.Canvas SetTransformer(Transformer transformer)
    {
        return new Canvas( context.SetTransformer(transformer) );
    }

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
        return Core.Turtle.Create(context);
    }

    public Flatland.Wireframe Wireframe()
    {
        return Core.Wireframe.Create(context);
    }
}

}
