using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class PointTest
{
    [Test]
    public void CtorXY()
    {
        var a = new Point(2, 3);

        Assert.That(a.X, Is.EqualTo(2));
        Assert.That(a.Y, Is.EqualTo(3));
    }

    [Test]
    public void CtorPolar()
    {
        var a = new Polar(1.234, 345.6);
        var b = new Point(a);

        Assert.That(b.X, Is.EqualTo(114));
        Assert.That(b.Y, Is.EqualTo(326));
    }

    [Test]
    public void CtorCartesian()
    {
        var a = new Cartesian(123.4, 345.6);
        var b = new Point(a);

        Assert.That(b.X, Is.EqualTo(123));
        Assert.That(b.Y, Is.EqualTo(346));
    }

    [Test]
    public void OffsetPoint()
    {
        Point a = new Point(2, 3);
        Point b = new Point(4, 5);
        Point c = a.Offset(b);

        Assert.That(a.X, Is.EqualTo(2));
        Assert.That(a.Y, Is.EqualTo(3));

        Assert.That(b.X, Is.EqualTo(4));
        Assert.That(b.Y, Is.EqualTo(5));

        Assert.That(c.X, Is.EqualTo(2+4));
        Assert.That(c.Y, Is.EqualTo(3+5));
    }

    [Test]
    public void OffsetXY()
    {
        Point a = new Point(2, 3);
        Point b = a.Offset(4, 5);

        Assert.That(a.X, Is.EqualTo(2));
        Assert.That(a.Y, Is.EqualTo(3));

        Assert.That(b.X, Is.EqualTo(2+4));
        Assert.That(b.Y, Is.EqualTo(3+5));
    }

    [Test]
    public void ToPoint()
    {
        var a = new Point(2, 3);
        var b = a.ToPoint();

        Assert.That(b, Is.InstanceOf(typeof(Point)));
        Assert.That(b.X, Is.EqualTo(2));
        Assert.That(b.Y, Is.EqualTo(3));
    }

    [Test]
    public void ToPolar()
    {
        var a = new Point(2, 3);
        var b = a.ToPolar();

        Assert.That(b, Is.InstanceOf(typeof(Polar)));
        Assert.That( IsApproximately(b.A, 0.983, 0.001) );
        Assert.That( IsApproximately(b.R, 3.606, 0.001) );
    }

    [Test]
    public void ToCartesian()
    {
        var a = new Point(2, 3);
        var b = a.ToCartesian();

        Assert.That(b, Is.InstanceOf(typeof(Cartesian)));
        Assert.That(b.X, Is.EqualTo(2.0));
        Assert.That(b.Y, Is.EqualTo(3.0));
    }

    private bool IsApproximately(double value, double expected, double fudge)
    {
        return Math.Abs(value - expected) < fudge;
    }

}
