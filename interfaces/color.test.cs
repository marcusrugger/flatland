using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class ColorTest
{
    [Test]
    public void ColorB_Grayscale()
    {
        var color = new ColorB(123);

        Assert.That(color.Red  , Is.EqualTo( 123 ));
        Assert.That(color.Green, Is.EqualTo( 123 ));
        Assert.That(color.Blue , Is.EqualTo( 123 ));
        Assert.That(color.Alpha, Is.EqualTo( 255 ));
    }

    [Test]
    public void ColorB_RGB()
    {
        var color = new ColorB(12, 23, 34);

        Assert.That(color.Red  , Is.EqualTo(  12 ));
        Assert.That(color.Green, Is.EqualTo(  23 ));
        Assert.That(color.Blue , Is.EqualTo(  34 ));
        Assert.That(color.Alpha, Is.EqualTo( 255 ));
    }

    [Test]
    public void ColorB_RGBA()
    {
        var color = new ColorB(12, 23, 34, 45);

        Assert.That(color.Red  , Is.EqualTo(  12 ));
        Assert.That(color.Green, Is.EqualTo(  23 ));
        Assert.That(color.Blue , Is.EqualTo(  34 ));
        Assert.That(color.Alpha, Is.EqualTo(  45 ));
    }

    [Test]
    public void ColorB_From_ColorF()
    {
        var color = new ColorB( new ColorF(0.1f, 0.2f, 0.3f, 0.4f) );

        Assert.That(color.Red  , Is.EqualTo(  26 ));
        Assert.That(color.Green, Is.EqualTo(  51 ));
        Assert.That(color.Blue , Is.EqualTo(  77 ));
        Assert.That(color.Alpha, Is.EqualTo( 102 ));
    }

    [Test]
    public void ColorB_From_ColorD()
    {
        var color = new ColorB( new ColorD(0.1, 0.2, 0.3, 0.4) );

        Assert.That(color.Red  , Is.EqualTo(  26 ));
        Assert.That(color.Green, Is.EqualTo(  51 ));
        Assert.That(color.Blue , Is.EqualTo(  77 ));
        Assert.That(color.Alpha, Is.EqualTo( 102 ));
    }

    [Test]
    public void ColorB_ToColorB()
    {
        var color1 = new ColorB(12, 23, 34, 45);
        var color2 = color1.ToColorB();

        Assert.That(color2.Red  , Is.EqualTo(  12 ));
        Assert.That(color2.Green, Is.EqualTo(  23 ));
        Assert.That(color2.Blue , Is.EqualTo(  34 ));
        Assert.That(color2.Alpha, Is.EqualTo(  45 ));
    }

    [Test]
    public void ColorB_ToColorF()
    {
        var color1 = new ColorB(12, 23, 34, 45);
        var color2 = color1.ToColorF();

        Assert.That(color2, Is.TypeOf( typeof(ColorF) ));
        Assert.That( IsApproximately(color2.Red  , 0.047, 0.001) );
        Assert.That( IsApproximately(color2.Green, 0.090, 0.001) );
        Assert.That( IsApproximately(color2.Blue , 0.133, 0.001) );
        Assert.That( IsApproximately(color2.Alpha, 0.176, 0.001) );
    }

    [Test]
    public void ColorB_ToColorD()
    {
        var color1 = new ColorB(12, 23, 34, 45);
        var color2 = color1.ToColorD();

        Assert.That(color2, Is.TypeOf( typeof(ColorD) ));
        Assert.That( IsApproximately(color2.Red  , 0.047, 0.001) );
        Assert.That( IsApproximately(color2.Green, 0.090, 0.001) );
        Assert.That( IsApproximately(color2.Blue , 0.133, 0.001) );
        Assert.That( IsApproximately(color2.Alpha, 0.176, 0.001) );
    }

    private bool IsApproximately(double value, double expected, double fudge)
    {
        return Math.Abs(value - expected) < fudge;
    }

}
