using System;

namespace Flatland {


public interface Color
{
    ColorD ToColorD();
    ColorF ToColorF();
    ColorB ToColorB();
}


public class Colors
{
    // public static readonly Color Black   = new ColorB(   0 );
    // public static readonly Color DkGray  = new ColorB(  64 );
    // public static readonly Color Gray    = new ColorB( 128 );
    // public static readonly Color LtGray  = new ColorB( 192 );
    // public static readonly Color White   = new ColorB( 255 );

    // public static readonly Color Red     = new ColorB( 255,   0,   0 );
    // public static readonly Color Green   = new ColorB(   0, 255,   0 );
    // public static readonly Color Blue    = new ColorB(   0,   0, 255 );
    // public static readonly Color Cyan    = new ColorB(   0, 255, 255 );
    // public static readonly Color Magenta = new ColorB( 255,   0, 255 );
    // public static readonly Color Yellow  = new ColorB( 255, 255,   0 );

    public static readonly Color Black   = new ColorD( 0.00 );
    public static readonly Color DkGray  = new ColorD( 0.25 );
    public static readonly Color Gray    = new ColorD( 0.50 );
    public static readonly Color LtGray  = new ColorD( 0.75 );
    public static readonly Color White   = new ColorD( 1.00 );

    public static readonly Color Red     = new ColorD( 1.0, 0.0, 0.0 );
    public static readonly Color Green   = new ColorD( 0.0, 1.0, 0.0 );
    public static readonly Color Blue    = new ColorD( 0.0, 0.0, 1.0 );
    public static readonly Color Cyan    = new ColorD( 0.0, 1.0, 1.0 );
    public static readonly Color Magenta = new ColorD( 1.0, 0.0, 1.0 );
    public static readonly Color Yellow  = new ColorD( 1.0, 1.0, 0.0 );
}

}
