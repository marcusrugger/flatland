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
}
