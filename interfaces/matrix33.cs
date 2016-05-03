using System;

namespace Flatland {


class Matrix33
{
    readonly double[,] matrix;

    public static Matrix33 Scale(Cartesian scale)
    {
        double[,] matrix = new double[3,3];
        matrix[0,0] = scale.X;
        matrix[1,1] = scale.Y;
        matrix[2,2] = 1.0;
        return new Matrix33(matrix);
    }

    public static Matrix33 Translate(Cartesian delta)
    {
        double[,] matrix = new double[3,3];
        matrix[0,0] = matrix[1,1] = matrix[2,2] = 1.0;
        matrix[0,2] = delta.X;
        matrix[1,2] = delta.Y;
        return new Matrix33(matrix);
    }

    public static Matrix33 Rotate(double angle)
    {
        double[,] matrix = new double[3,3];
        matrix[0,0] =  Math.Cos(angle);     matrix[0,1] = Math.Sin(angle);
        matrix[1,0] = -Math.Sin(angle);     matrix[1,1] = Math.Cos(angle);
        matrix[2,2] = 1.0;
        return new Matrix33(matrix);
    }

    public static Matrix33 Multiply(Matrix33 l, Matrix33 r)
    {
        return new Matrix33(l, r);
    }

    public Matrix33()
    {
        matrix = new double[3,3];
        matrix[0,0] = matrix[1,1] = matrix[2,2] = 1.0;
    }
    
    public Matrix33(double[,] matrix)
    {
        this.matrix = matrix;
    }

    private Matrix33(Matrix33 l, Matrix33 r)
    {
        matrix = new double[3,3];
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                matrix[x, y] = l.matrix[x, 0] * r.matrix[0, y] +
                               l.matrix[x, 1] * r.matrix[1, y] +
                               l.matrix[x, 2] * r.matrix[2, y];
            }
        }
    }

    public double[,] Matrix
    {
        get { return matrix; }
    }

    public bool Equals(Matrix33 other)
    {
        bool result = true;
        for (int x = 0; result && x < 3; x++)
        {
            for (int y = 0; result && y < 3; y++)
            {
                result = matrix[x, y] == other.matrix[x, y];
            }
        }
        return result;
    }
}

}