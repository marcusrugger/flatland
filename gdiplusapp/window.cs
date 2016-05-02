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

        canvas.NewTurtle()
              .SetLineColor(Colors.Red)
              .MoveTo(100, 100)
              .LineTo(200, 200);

        canvas.NewTurtle()
              .MoveTo(200, 200)
              .LineTo(300, 300);
    }

}
