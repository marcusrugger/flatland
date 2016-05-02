using System;
using System.Windows.Forms;
using Flatland.GdiPlus;


public class Tides
{
    static public void Main ()
    {
        Application.Run( new GdiPlusWindow(Context.Create) );
    }
}
