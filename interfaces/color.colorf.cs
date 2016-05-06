using System;

namespace Flatland {


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

    public ColorF(float r, float g, float b, float a = 1.0f)
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
    : this(color.Red, color.Green, color.Blue, color.Alpha)
    {}

    public ColorF(byte red, byte green, byte blue, byte alpha = 255)
    {
        this.red     = ((float) red)   / 255.0f;
        this.green   = ((float) green) / 255.0f;
        this.blue    = ((float) blue)  / 255.0f;
        this.alpha   = ((float) alpha) / 255.0f;
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

}
