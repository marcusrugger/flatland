using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class PolarTest
{
    [Test]
    public void AngleRadiusConstructor()
    {
        double a = 123.4;
        double r = 234.5;

        Polar p = new Polar(a, r);

        Assert.That(p.A, Is.EqualTo(a));
        Assert.That(p.R, Is.EqualTo(r));
    }

    [Test]
    public void ConvertCartesian()
    {
        ConvertCartesian(  0.0,  1.0,   Math.PI/2,  1.0);
        ConvertCartesian(  0.0, -1.0, 3*Math.PI/2,  1.0);
        ConvertCartesian( 30.0, 50.0,   1.0303768, 58.3095189);
        ConvertCartesian(-30.0, 50.0,   2.1112158, 58.3095189);
        ConvertCartesian(-30.0,-50.0,   4.1719695, 58.3095189);
        ConvertCartesian( 30.0,-50.0,   5.2528085, 58.3095189);
    }

    private void ConvertCartesian(double x, double y, double expected_a, double expected_r)
    {
        Cartesian cp = new Cartesian(x, y);
        Polar pp = new Polar(cp);

        Assert.That( IsApproximately(pp.A, expected_a, 1e-6) );        
        Assert.That( IsApproximately(pp.R, expected_r, 1e-6) );
    }

    [Test]
    public void TransformR()
    {
        Polar p = new Polar(Math.PI/4.0, 1.0);
        Polar n = p.TransformR(r => 2*r);
        Assert.That(n.R, Is.EqualTo(2.0));
        Assert.That(p.R, Is.EqualTo(1.0));
    }

    [Test]
    public void ToPoint()
    {
        var p = new Polar(0.0, 1.0);
        var c = p.ToPoint();

        Assert.That(c, Is.InstanceOf(typeof(Point)));
        Assert.That(c.X, Is.EqualTo(1));
        Assert.That(c.Y, Is.EqualTo(0));

        Assert.That(p.A, Is.EqualTo(0));
        Assert.That(p.R, Is.EqualTo(1));
    }

    [Test]
    public void ToCartesian()
    {
        Polar p = new Polar(0.0, 1.0);
        var   c = p.ToCartesian();

        Assert.That(c, Is.InstanceOf(typeof(Cartesian)));
        Assert.That(c.X, Is.EqualTo(1.0));
        Assert.That(c.Y, Is.EqualTo(0.0));

        Assert.That(p.A, Is.EqualTo(0.0));
        Assert.That(p.R, Is.EqualTo(1.0));
    }

    [Test]
    public void ToPolar()
    {
        Polar p = new Polar(0.0, 1.0);
        var   c = p.ToPolar();

        Assert.That(c, Is.InstanceOf(typeof(Polar)));
        Assert.That(c.A, Is.EqualTo(0.0));
        Assert.That(c.R, Is.EqualTo(1.0));
    }

    private bool IsApproximately(double value, double expected, double fudge)
    {
        return Math.Abs(value - expected) < fudge;
    }

}
