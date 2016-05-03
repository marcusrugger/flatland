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

}
