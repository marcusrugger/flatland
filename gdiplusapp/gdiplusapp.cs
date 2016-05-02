using System;
using System.Drawing;
using System.Windows.Forms;
using Flatland.GdiPlus;

using Drawing = System.Drawing;


public class Tides
{
    static public void Main ()
    {
        Func<Drawing.Graphics, Canvas> fn = (g) => Canvas.Create( Context.Create(g) );
        Application.Run( new GdiPlusWindow(fn) );
    }
}
