using Gtk;
using System;


public class Tides
{
    static public void Main ()
    {
        Application.Init();

        Func<Cairo.Context, Flatland.Canvas> fn = (c) => Flatland.Common.Canvas.Create( Flatland.GtkSharp.Context.Create(c) );
        var window = new GtkSharpWindow(fn);
        window.ShowAll(); 
        Application.Run();
    }
}
