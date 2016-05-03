using System;

namespace Flatland {


public interface Color
{
    ColorD ToColorD();
    ColorF ToColorF();
    ColorB ToColorB();
}


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

    public ColorB(byte r, byte g, byte b)
    {
        red     = r;
        green   = g;
        blue    = b;
        alpha   = 255;
    }

    public ColorB(byte r, byte g, byte b, byte a)
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
        red     = (byte) (255.0 * color.Red   + 0.5);
        green   = (byte) (255.0 * color.Green + 0.5);
        blue    = (byte) (255.0 * color.Blue  + 0.5);
        alpha   = (byte) (255.0 * color.Alpha + 0.5);
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


public class ColorF : Color
{
    readonly float red;
    readonly float blue;
    readonly float green;
    readonly float alpha;

    public ColorF(float grayscale)
    {
        float crop = Crop(grayscale);

        red     = crop;
        green   = crop;
        blue    = crop;
        alpha   = 1.0f;
    }

    public ColorF(float r, float g, float b)
    {
        red     = Crop(r);
        green   = Crop(g);
        blue    = Crop(b);
        alpha   = 1.0f;
    }

    public ColorF(float r, float g, float b, float a)
    {
        red     = Crop(r);
        green   = Crop(g);
        blue    = Crop(b);
        alpha   = Crop(a);
    }

    public ColorF(ColorD color)
    {
        red     = (float) color.Red;
        green   = (float) color.Green;
        blue    = (float) color.Blue;
        alpha   = (float) color.Alpha;
    }

    public ColorF(ColorB color)
    {
        red     = ((float) color.Red)   / 255.0f;
        green   = ((float) color.Green) / 255.0f;
        blue    = ((float) color.Blue)  / 255.0f;
        alpha   = ((float) color.Alpha) / 255.0f;
    }

    private float Crop(float value)
    {
        float crop;
        crop = value > 1.0f ? 1.0f : value;
        crop = value < 0.0f ? 0.0f : value;
        return crop;
    }

    public ColorD ToColorD()
    {
        return new ColorD(this);
    }

    public ColorF ToColorF()
    {
        return this;
    }

    public ColorB ToColorB()
    {
        return new ColorB(this);
    }

    public float Red   { get { return red;   } }
    public float Green { get { return green; } }
    public float Blue  { get { return blue;  } }
    public float Alpha { get { return alpha; } }
}


public class ColorD : Color
{
    readonly double red;
    readonly double blue;
    readonly double green;
    readonly double alpha;

    public ColorD(double grayscale)
    {
        double crop = Crop(grayscale);

        red     = crop;
        green   = crop;
        blue    = crop;
        alpha   = 1.0;
    }

    public ColorD(double r, double g, double b)
    {
        red     = Crop(r);
        green   = Crop(g);
        blue    = Crop(b);
        alpha   = 1.0;
    }

    public ColorD(double r, double g, double b, double a)
    {
        red     = Crop(r);
        green   = Crop(g);
        blue    = Crop(b);
        alpha   = Crop(a);
    }

    public ColorD(ColorF color)
    {
        red     = color.Red;
        green   = color.Green;
        blue    = color.Blue;
        alpha   = color.Alpha;
    }

    public ColorD(ColorB color)
    {
        red     = ((double) color.Red)   / 255.0;
        green   = ((double) color.Green) / 255.0;
        blue    = ((double) color.Blue)  / 255.0;
        alpha   = ((double) color.Alpha) / 255.0;
    }

    private double Crop(double value)
    {
        double crop;
        crop = value > 1.0 ? 1.0 : value;
        crop = value < 0.0 ? 0.0 : value;
        return crop;
    }

    public ColorD ToColorD()
    {
        return this;
    }

    public ColorF ToColorF()
    {
        return new ColorF(this);
    }

    public ColorB ToColorB()
    {
        return new ColorB(this);
    }

    public double Red   { get { return red;   } }
    public double Green { get { return green; } }
    public double Blue  { get { return blue;  } }
    public double Alpha { get { return alpha; } }
}


public class Colors
{
    // public static readonly Color Black   = new ColorB(   0 );
    // public static readonly Color DkGray  = new ColorB(  64 );
    // public static readonly Color Gray    = new ColorB( 128 );
    // public static readonly Color LtGray  = new ColorB( 192 );
    // public static readonly Color White   = new ColorB( 255 );

    // public static readonly Color Red     = new ColorB( 255,   0,   0 );
    // public static readonly Color Green   = new ColorB(   0, 255,   0 );
    // public static readonly Color Blue    = new ColorB(   0,   0, 255 );
    // public static readonly Color Cyan    = new ColorB(   0, 255, 255 );
    // public static readonly Color Magenta = new ColorB( 255,   0, 255 );
    // public static readonly Color Yellow  = new ColorB( 255, 255,   0 );

    public static readonly Color Black   = new ColorD( 0.00 );
    public static readonly Color DkGray  = new ColorD( 0.25 );
    public static readonly Color Gray    = new ColorD( 0.50 );
    public static readonly Color LtGray  = new ColorD( 0.75 );
    public static readonly Color White   = new ColorD( 1.00 );

    public static readonly Color Red     = new ColorD( 1.0, 0.0, 0.0 );
    public static readonly Color Green   = new ColorD( 0.0, 1.0, 0.0 );
    public static readonly Color Blue    = new ColorD( 0.0, 0.0, 1.0 );
    public static readonly Color Cyan    = new ColorD( 0.0, 1.0, 1.0 );
    public static readonly Color Magenta = new ColorD( 1.0, 0.0, 1.0 );
    public static readonly Color Yellow  = new ColorD( 1.0, 1.0, 0.0 );
}

}
