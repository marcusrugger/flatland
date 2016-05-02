using System;

namespace Flatland {


public interface Turtle
{
    Turtle SetLineColor(Color color);

    Turtle MoveTo(int x, int y);
    Turtle MoveTo(double x, double y);
    Turtle MoveTo(Point position);
    Turtle MoveTo(Cartesian position);

    Turtle LineTo(int x, int y);
    Turtle LineTo(double x, double y);
    Turtle LineTo(Point position);
    Turtle LineTo(Cartesian position);

    Turtle Move(double distance);
    Turtle TurnTo(double angle);
    Turtle Turn(double angle);
    Turtle Line(double distance);
}

}