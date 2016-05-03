using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class ColorDTest
{
    [Test]
    public void DolorF_Grayscale()
    {
        var color = new ColorD(0.123);

        Assert.That(color.Red  , Is.EqualTo( 0.123 ));
        Assert.That(color.Green, Is.EqualTo( 0.123 ));
        Assert.That(color.Blue , Is.EqualTo( 0.123 ));
        Assert.That(color.Alpha, Is.EqualTo( 1.000 ));
    }

    [Test]
    public void ColorD_RGB()
    {
        var color = new ColorD(0.123, 0.234, 0.345);

        Assert.That(color.Red  , Is.EqualTo( 0.123 ));
        Assert.That(color.Green, Is.EqualTo( 0.234 ));
        Assert.That(color.Blue , Is.EqualTo( 0.345 ));
        Assert.That(color.Alpha, Is.EqualTo( 1.000 ));
    }

    [Test]
    public void ColorD_RGBA()
    {
        var color = new ColorD(0.123, 0.234, 0.345, 0.456);

        Assert.That(color.Red  , Is.EqualTo( 0.123 ));
        Assert.That(color.Green, Is.EqualTo( 0.234 ));
        Assert.That(color.Blue , Is.EqualTo( 0.345 ));
        Assert.That(color.Alpha, Is.EqualTo( 0.456 ));
    }

    [Test]
    public void ColorD_From_ColorB()
    {
        var color = new ColorD( new ColorB(12, 23, 34, 45) );

        Assert.That( IsApproximately(color.Red  , 0.047, 0.001) );
        Assert.That( IsApproximately(color.Green, 0.090, 0.001) );
        Assert.That( IsApproximately(color.Blue , 0.133, 0.001) );
        Assert.That( IsApproximately(color.Alpha, 0.176, 0.001) );
    }

    [Test]
    public void ColorD_From_ColorB_Black()
    {
        var color = new ColorD( new ColorB(0, 0, 0, 0) );

        Assert.That(color.Red  , Is.EqualTo( 0.0 ));
        Assert.That(color.Green, Is.EqualTo( 0.0 ));
        Assert.That(color.Blue , Is.EqualTo( 0.0 ));
        Assert.That(color.Alpha, Is.EqualTo( 0.0 ));
    }

    [Test]
    public void ColorD_From_ColorB_White()
    {
        var color = new ColorD( new ColorB(255, 255, 255, 255) );

        Assert.That(color.Red  , Is.EqualTo( 1.0 ));
        Assert.That(color.Green, Is.EqualTo( 1.0 ));
        Assert.That(color.Blue , Is.EqualTo( 1.0 ));
        Assert.That(color.Alpha, Is.EqualTo( 1.0 ));
    }

    [Test]
    public void ColorD_From_ColorF()
    {
        var color = new ColorD( new ColorF(0.123f, 0.234f, 0.345f, 0.456f) );

        Assert.That( IsApproximately(color.Red  , 0.123, 0.001) );
        Assert.That( IsApproximately(color.Green, 0.234, 0.001) );
        Assert.That( IsApproximately(color.Blue , 0.345, 0.001) );
        Assert.That( IsApproximately(color.Alpha, 0.456, 0.001) );
    }

    [Test]
    public void ColorD_ToColorB()
    {
        var color1 = new ColorD(0.123, 0.234, 0.345, 0.456);
        var color2 = color1.ToColorB();

        Assert.That(color2, Is.TypeOf( typeof(ColorB) ));
        Assert.That(color2.Red  , Is.EqualTo(  31 ));
        Assert.That(color2.Green, Is.EqualTo(  60 ));
        Assert.That(color2.Blue , Is.EqualTo(  88 ));
        Assert.That(color2.Alpha, Is.EqualTo( 116 ));
    }

    [Test]
    public void ColorD_ToColorF()
    {
        var color1 = new ColorD(0.123, 0.234, 0.345, 0.456);
        var color2 = color1.ToColorF();

        Assert.That(color2, Is.TypeOf( typeof(ColorF) ));
        Assert.That( IsApproximately(color2.Red  , 0.123, 0.001) );
        Assert.That( IsApproximately(color2.Green, 0.234, 0.001) );
        Assert.That( IsApproximately(color2.Blue , 0.345, 0.001) );
        Assert.That( IsApproximately(color2.Alpha, 0.456, 0.001) );
    }

    [Test]
    public void ColorD_ToColorD()
    {
        var color1 = new ColorD(0.123, 0.234, 0.345, 0.456);
        var color2 = color1.ToColorD();

        Assert.That(color2, Is.TypeOf( typeof(ColorD) ));
        Assert.That( IsApproximately(color2.Red  , 0.123, 0.001) );
        Assert.That( IsApproximately(color2.Green, 0.234, 0.001) );
        Assert.That( IsApproximately(color2.Blue , 0.345, 0.001) );
        Assert.That( IsApproximately(color2.Alpha, 0.456, 0.001) );
    }

    private bool IsApproximately(double value, double expected, double fudge)
    {
        return Math.Abs(value - expected) < fudge;
    }

}
