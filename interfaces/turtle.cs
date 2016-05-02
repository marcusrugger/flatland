using System;

namespace Flatland {


public interface Turtle
{
    Turtle SetLineColor(Color color);

    Turtle MoveTo(int x, int y);
    Turtle MoveTo(double x, double y);
    Turtle MoveTo(Point position);
    Turtle MoveTo(Cartesian position);

    Turtle Move(double distance);
    Turtle TurnTo(double angle);
    Turtle Turn(double angle);
    Turtle LineTo(Cartesian position);
    Turtle Line(double distance);
}

}