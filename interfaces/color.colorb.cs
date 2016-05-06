using System;

namespace Flatland {


public class ColorB : Color
{
    readonly byte red;
    readonly byte blue;
    readonly byte green;
    readonly byte alpha;

    public ColorB(byte grayscale)
    {
        red     = grayscale;
        green   = grayscale;
        blue    = grayscale;
        alpha   = 255;
    }

    public ColorB(byte r, byte g, byte b, byte a = 255)
    {
        red     = r;
        green   = g;
        blue    = b;
        alpha   = a;
    }

    public ColorB(ColorD color)
    {
        red     = (byte) (255.0 * color.Red   + 0.5);
        green   = (byte) (255.0 * color.Green + 0.5);
        blue    = (byte) (255.0 * color.Blue  + 0.5);
        alpha   = (byte) (255.0 * color.Alpha + 0.5);
    }

    public ColorB(ColorF color)
    {
        red     = (byte) (255.0f * color.Red   + 0.5f);
        green   = (byte) (255.0f * color.Green + 0.5f);
        blue    = (byte) (255.0f * color.Blue  + 0.5f);
        alpha   = (byte) (255.0f * color.Alpha + 0.5f);
    }

    public ColorD ToColorD()
    {
        return new ColorD(this);
    }

    public ColorF ToColorF()
    {
        return new ColorF(this);
    }

    public ColorB ToColorB()
    {
        return this;
    }

    public byte Red   { get { return red;   } }
    public byte Green { get { return green; } }
    public byte Blue  { get { return blue;  } }
    public byte Alpha { get { return alpha; } }
}

}
