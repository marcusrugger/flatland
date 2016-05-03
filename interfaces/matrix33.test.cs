using NUnit.Framework;
using System;
using Flatland;


[TestFixture]
class Matrix33Test
{
    [Test]
    public void Identity()
    {
        double[,] id = new double[3,3];
        id[0,0] = id[1,1] = id[2,2] = 1.0;
        Matrix33 a = new Matrix33(id);
        Matrix33 b = new Matrix33();
        Assert.That( b.Equals(a) );
    }

    [Test]
    public void Identity_NegativeCase()
    {
        double[,] id = new double[3,3];
        id[0,0] = id[1,1] = id[2,2] = 1.0;
        id[0,2] = 1.0;
        Matrix33 a = new Matrix33(id);
        Matrix33 b = new Matrix33();
        Assert.That( !b.Equals(a) );
    }

    [Test]
    public void Scale()
    {
        var d = new Cartesian(1.23, 2.34);
        double[,] m = new double[3,3];

        m[0,0] = d.X;
        m[1,1] = d.Y;
        m[2,2] = 1.0;

        Matrix33 a = new Matrix33(m);
        Matrix33 b = Matrix33.Scale(d);
        Assert.That( b.Equals(a) );
    }

    [Test]
    public void Translate()
    {
        var d = new Cartesian(1.23, 2.34);
        double[,] m = new double[3,3];

        m[0,0] = m[1,1] = m[2,2] = 1.0;
        m[0,2] = d.X;
        m[1,2] = d.Y;

        Matrix33 a = new Matrix33(m);
        Matrix33 b = Matrix33.Translate(d);
        Assert.That( b.Equals(a) );
    }

    [Test]
    public void MultiplyIdentity()
    {
        var a = new Matrix33();
        var b = new Matrix33();
        var c = Matrix33.Multiply(a, b);
        Assert.That( c.Equals(a) );
        Assert.That( c.Equals(b) );
    }

    [Test]
    public void TranslatePoint1()
    {
        var d = new Cartesian(5.0, 10.0);
        var m = Matrix33.Translate(d);
        var a = new Cartesian();
        var b = m.Transform(a);
        Assert.That(b.X, Is.EqualTo( 5.0));
        Assert.That(b.Y, Is.EqualTo(10.0));
    }

    [Test]
    public void TranslatePoint2()
    {
        var d = new Cartesian(5.0, 10.0);
        var m = Matrix33.Translate(d);
        var a = new Cartesian(1.0, 2.0);
        var b = m.Transform(a);
        Assert.That(b.X, Is.EqualTo( 6.0));
        Assert.That(b.Y, Is.EqualTo(12.0));
    }

    [Test]
    public void ScalePoint()
    {
        var d = new Cartesian(0.5, 0.25);
        var m = Matrix33.Scale(d);
        var a = new Cartesian(100.0, 100.0);
        var b = m.Transform(a);
        Assert.That(b.X, Is.EqualTo(50.0));
        Assert.That(b.Y, Is.EqualTo(25.0));
    }

    [Test]
    public void ScaleAndTranslatePoint()
    {
        // var tp = new Cartesian(5.0, 10.0);
        // var sp = new Cartesian(0.5, 0.25);
        // var m  = Matrix33.CreateMatrix(sp, tp, 0.0);
        // var a = new Cartesian(95.0, 90.0);
        // var b = m.Transform(a);
        // Assert.That(b.X, Is.EqualTo(50.0));
        // Assert.That(b.Y, Is.EqualTo(25.0));
    }

    [Test]
    public void ScaleAndTranslatePoint2()
    {
        var tp = new Cartesian(500.0, 500.0);
        var sp = new Cartesian(300.0/6000.0, -300.0/6000.0);
        var m  = Matrix33.CreateMatrix(sp, tp, 0.0);
        var a = new Cartesian(6000.0, 0.0);
        var b = m.Transform(a);
        Assert.That(b.X, Is.EqualTo(800.0));
        Assert.That(b.Y, Is.EqualTo(500.0));
    }

    [Test]
    public void ScaleAndTranslatePoint3()
    {
        var tp = new Cartesian(500.0, 500.0);
        var sp = new Cartesian(300.0/6000.0, -300.0/6000.0);
        var m  = Matrix33.CreateMatrix(sp, tp, 0.0);
        var a = new Cartesian(0.0, 6000.0);
        var b = m.Transform(a);
        Assert.That(b.X, Is.EqualTo(500.0));
        Assert.That(b.Y, Is.EqualTo(200.0));
    }
}
