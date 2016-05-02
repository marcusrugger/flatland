using System;
using System.Drawing;
using System.Windows.Forms;
using Flatland;

using Drawing = System.Drawing;


public class Tides
{
    static public void Main ()
    {
        Func<Drawing.Graphics, Flatland.Common.Canvas> fn = (g) => Flatland.Common.Canvas.Create( Flatland.GdiPlus.Context.Create(g) );
        Application.Run( new GdiPlusWindow(fn) );
    }
}
