using System;
using System.Drawing;
using System.Windows.Forms;
using Flatland;


class GdiPlusWindow : Form
{
    Func<Graphics, Context> fnCreateContext;

    private const int DISPLAY_WIDTH        = 1000;
    private const int DISPLAY_HEIGHT       = 1000;

    public GdiPlusWindow(Func<Graphics, Context> fnCreateContext)
    {
        this.fnCreateContext = fnCreateContext;
        SetupForm();
    }

    private void SetupForm()
    {
        this.Text            = "GdiPlus Test App";
        this.Size            = new Size(DISPLAY_WIDTH, DISPLAY_HEIGHT);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var context = fnCreateContext(e.Graphics).SetLineColor(Colors.Blue);

        context.NewTurtle()
               .SetLineColor(Colors.Red)
               .MoveTo(100, 100)
               .LineTo(200, 200);

        context.NewTurtle()
               .MoveTo(200, 200)
               .LineTo(300, 300);
    }

}
