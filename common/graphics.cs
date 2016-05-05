using System;

namespace Flatland.Common {


public class Graphics
{
    readonly Context context;
    
    protected Graphics(Context context)
    {
        this.context = context;
    }

    protected Graphics(Graphics other)
    {
        this.context = other.context;
    }

    protected Graphics(Graphics other, Context context)
    {
        this.context = context;
    }
    
    protected Context Context
    {
        get { return context; }
    }
}

}
