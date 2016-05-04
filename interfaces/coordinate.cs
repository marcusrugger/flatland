using System;

namespace Flatland {


interface Coordinate
{
    Cartesian ToCartesian();
    Polar ToPolar();
    Point ToPoint();
}

}
