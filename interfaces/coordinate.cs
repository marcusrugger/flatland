using System;

namespace Flatland {


public interface Coordinate
{
    Cartesian ToCartesian();
    Polar ToPolar();
    Point ToPoint();
}

}
