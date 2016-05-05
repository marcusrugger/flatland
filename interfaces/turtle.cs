using System;

namespace Flatland {


public interface Turtle
{
    Turtle SetLineColor(Color color);

    Turtle MoveTo(double x, double y);
    Turtle MoveTo(Cartesian position);
    Turtle Move(double distance);
    Turtle Move(Polar p);

    Turtle LineTo(double x, double y);
    Turtle LineTo(Cartesian position);
    Turtle Line(double distance);
    Turtle Line(Polar p);

    Turtle TurnTo(double angle);
    Turtle Turn(double angle);

    Turtle PenDown(bool flag = true);
    Turtle PenUp(bool flag = true);
    Turtle PenToggle();
    Turtle PenMoveTo(double x, double y);
    Turtle PenMoveTo(Cartesian position);
    Turtle PenMove(double distance);
}

}