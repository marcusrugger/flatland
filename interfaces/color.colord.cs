using System;

namespace Flatland {


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

    public ColorD(double r, double g, double b, double a = 1.0)
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
    : this(color.Red, color.Green, color.Blue, color.Alpha)
    {}

    public ColorD(byte red, byte green, byte blue, byte alpha = 255)
    {
        this.red     = ((double) red)   / 255.0;
        this.green   = ((double) green) / 255.0;
        this.blue    = ((double) blue)  / 255.0;
        this.alpha   = ((double) alpha) / 255.0;
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

}
