using System;

namespace Flatland {


interface Color
{
    byte Red   { get; }
    byte Green { get; }
    byte Blue  { get; }
}


class ColorRGB : Color
{
    byte red;
    byte green;
    byte blue;

    public ColorRGB(byte red, byte green, byte blue)
    {
        this.red   = red;
        this.green = green;
        this.blue  = blue;
    }

    public byte Red   { get { return red;   } }
    public byte Green { get { return green; } }
    public byte Blue  { get { return blue;  } }
}


class Colors
{
    public static Color Red   = new ColorRGB( 255,   0,   0 );
    public static Color Green = new ColorRGB(   0, 255,   0 );
    public static Color Blue  = new ColorRGB(   0,   0, 255 );
}

}
