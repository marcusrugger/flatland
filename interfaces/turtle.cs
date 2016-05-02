using System;

namespace Flatland {


public interface Turtle
{
    Turtle SetLineColor(Color color);

    Turtle MoveTo(double x, double y);
    Turtle MoveTo(Cartesian position);

    Turtle LineTo(double x, double y);
    Turtle LineTo(Cartesian position);

    Turtle Move(double distance);
    Turtle Line(double distance);

    Turtle TurnTo(double angle);
    Turtle Turn(double angle);
}

}