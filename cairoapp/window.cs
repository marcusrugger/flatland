using Cairo;
using Gtk;
using System;
using Flatland;


class CairoWindow : Window
{
    Func<Cairo.Context, Flatland.Canvas> fnCreateCanvas;

    public CairoWindow(Func<Cairo.Context, Flatland.Canvas> fnCreateCanvas) : base("GtkSharp Test App")
    {
        this.fnCreateCanvas = fnCreateCanvas;

        SetDefaultSize(1000, 1000);

        DeleteEvent += (obj, args) => Application.Quit();
    }

    protected override bool OnDrawn(Cairo.Context context)
    {
        bool result = base.OnDrawn(context);
        var canvas = fnCreateCanvas(context).SetLineColor(Colors.Blue);

        Test1(canvas);
        Test2(canvas.Turtle().MoveTo(500, 500), 10);
        TestWireframe(canvas);

        return result;
    }

    private void Test1(Canvas canvas)
    {
        canvas.Turtle()
              .SetLineColor(Colors.Red)
              .MoveTo(100, 100)
              .LineTo(200, 200);

        canvas.Turtle()
              .MoveTo(200, 200)
              .LineTo(300, 300);

        canvas.Turtle()
              .MoveTo(400, 400)
              .LineTo(400, 600)
              .SetLineColor(Colors.Cyan)
              .LineTo(600, 600)
              .SetLineColor(Colors.Magenta)
              .LineTo(600, 400)
              .SetLineColor(Colors.Green)
              .LineTo(400, 400);
    }

    private void Test2(Turtle turtle, double distance)
    {
        double angle = Algorithms.ToRadians(91);

        if (distance > 500) return;
        var nextTurtle = turtle.Turn(angle).PenMove(distance).PenToggle();
        Test2(nextTurtle, distance+1 );
    }

    private void TestWireframe(Canvas canvas)
    {
        var wireframe = canvas.Wireframe().SetLineColor(Colors.Green);
        wireframe.Line(100, 100, 200, 100);
        wireframe.SetLineColor(Colors.Red).Circle(500, 500, 100);
    }

}
