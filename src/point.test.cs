using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class PointTest
{
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
}
