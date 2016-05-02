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
        var context = fnCreateContext(e.Graphics);
        context.NewTurtle()
               .MoveTo(new Flatland.Cartesian(100.0, 100.0))
               .LineTo(new Flatland.Cartesian(200.0, 200.0));
    }

}
