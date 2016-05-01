using System;

namespace Flatland {


class Context
{
    public Color colorDefault;

    public Context()
    {
        colorDefault = new ColorRGB();
    }

    public Context(Context other, Color color)
    {
        colorDefault = color;
    }

    public Context SetColor(Color color)
    {
        return new Context(this, color);
    }

    public Color DefaultColor
    {
        get { return colorDefault; }
    }

    public DrawLine Line
    {
        get { return new DrawLine(this); }
    }
}

}