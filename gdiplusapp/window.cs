using System;
using System.Drawing;
using System.Windows.Forms;
using Flatland;


class GdiPlusWindow : Form
{
    Func<Graphics, Canvas> fnCreateCanvas;

    private const int DISPLAY_WIDTH        = 1000;
    private const int DISPLAY_HEIGHT       = 1000;

    public GdiPlusWindow(Func<Graphics, Canvas> fnCreateCanvas)
    {
        this.fnCreateCanvas = fnCreateCanvas;
        SetupForm();
    }

    private void SetupForm()
    {
        this.Text = "GdiPlus Test App";
        this.Size = new Size(DISPLAY_WIDTH, DISPLAY_HEIGHT);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var canvas = fnCreateCanvas(e.Graphics).SetLineColor(Colors.Blue);

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

}
