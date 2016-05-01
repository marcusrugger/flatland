using System;

namespace Flatland {


public interface Turtle
{
    Turtle MoveTo(Cartesian position);
    Turtle Move(double distance);
    Turtle TurnTo(double angle);
    Turtle Turn(double angle);
    Turtle LineTo(Cartesian position);
    Turtle Line(double distance);
}

}