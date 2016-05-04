using System;

namespace Flatland {


public class Transformer
{
    readonly Matrix33 matrix;
    readonly Cartesian scale;
    readonly Cartesian offset;
    readonly double angle;

    public Transformer()
    {
        this.angle  = 0.0;
        this.scale  = new Cartesian(1.0, 1.0);
        this.offset = new Cartesian();
        this.matrix = new Matrix33();
    }

    public Transformer(double angle, Cartesian scale, Cartesian offset)
    {
        this.angle  = angle;
        this.scale  = scale;
        this.offset = offset;
        this.matrix = Matrix33.CreateMatrix(scale, offset, angle);
    }
    
    public Transformer SetRotation(double angle)
    {
        return new Transformer(angle, this.scale, this.offset);
    }

    public Transformer SetScale(Cartesian scale)
    {
        return new Transformer(this.angle, scale, this.offset);
    }

    public Transformer SetTranslation(Cartesian offset)
    {
        return new Transformer(this.angle, this.scale, offset);
    }

    public double ScaleOnX(double r)
    {
        return scale.X * r;
    }

    public double ScaleOnY(double r)
    {
        return scale.Y * r;
    }

    public Cartesian Scale(Cartesian p)
    {
        return p.Scale(scale);
    }
    
    public Cartesian Translate(Cartesian p)
    {
        return p.Offset(offset);
    }

    public Cartesian Transform(Cartesian p)
    {
        return matrix.Transform(p);
    }
}

}
