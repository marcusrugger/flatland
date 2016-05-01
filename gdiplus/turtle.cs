using System;

namespace Flatland.GdiPlus {


class Turtle : Flatland.Common.Turtle
{
    private Turtle(Turtle other, Cartesian position) : base(other, position)
    {}

    private Turtle(Turtle other, double angle) : base(other, angle)
    {}

    protected override void Draw(Cartesian p1, Cartesian p2)
    {}

    protected override Flatland.Turtle CloneWith(Cartesian newPosition)
    {
        return new Turtle(this, newPosition);
    }

    protected override Flatland.Turtle CloneWith(double newAngle)
    {
        return new Turtle(this, newAngle);
    }

}

}