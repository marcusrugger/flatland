using System;

namespace Flatland {


interface Color
{
    byte Red   { get; }
    byte Green { get; }
    byte Blue  { get; }
    byte Alpha { get; }
}


class ColorGrayscale : Color
{
    byte value;

    public ColorGrayscale()
    {}

    public ColorGrayscale(byte a)
    {
        this.value = a;
    }
    
    public ColorGrayscale(Color other)
    {
        value = (byte) (((int) other.Red + (int) other.Green + (int) other.Blue) / 3);
    }

    public byte Red   { get { return value; } }
    public byte Green { get { return value; } }
    public byte Blue  { get { return value; } }
    public byte Alpha { get { return 255;   } }
}


class ColorRGB : Color
{
    byte red;
    byte green;
    byte blue;
    
    public ColorRGB()
    {
        red   = 0;
        green = 0;
        blue  = 0;
    }

    public ColorRGB(byte red, byte green, byte blue)
    {
        this.red   = red;
        this.green = green;
        this.blue  = blue;
    }
    
    public ColorRGB(Color other)
    {
        this.red   = other.Red;
        this.green = other.Green;
        this.blue  = other.Blue;
    }

    public byte Red   { get { return red;   } }
    public byte Green { get { return green; } }
    public byte Blue  { get { return blue;  } }
    public byte Alpha { get { return 255;   } }
}


class ColorRGBA : Color
{
    byte red;
    byte green;
    byte blue;
    byte alpha;

    public ColorRGBA(byte red, byte green, byte blue, byte alpha)
    {
        this.red   = red;
        this.green = green;
        this.blue  = blue;
        this.alpha = alpha;
    }

    public byte Red   { get { return red;   } }
    public byte Green { get { return green; } }
    public byte Blue  { get { return blue;  } }
    public byte Alpha { get { return alpha; } }
}


class Colors
{
    public static Color Black   = new ColorGrayscale(   0 );
    public static Color DkGray  = new ColorGrayscale(  64 );
    public static Color Gray    = new ColorGrayscale( 128 );
    public static Color LtGray  = new ColorGrayscale( 192 );
    public static Color White   = new ColorGrayscale( 255 );

    public static Color Red     = new ColorRGB( 255,   0,   0 );
    public static Color Green   = new ColorRGB(   0, 255,   0 );
    public static Color Blue    = new ColorRGB(   0,   0, 255 );
    public static Color Cyan    = new ColorRGB(   0, 255, 255 );
    public static Color Magenta = new ColorRGB( 255,   0, 255 );
    public static Color Yellow  = new ColorRGB( 255, 255,   0 );
}

}
