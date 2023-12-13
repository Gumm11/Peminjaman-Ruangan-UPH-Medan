using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    public int CornerRadius { get; set; }

    public RoundedButton()
    {
        CornerRadius = 20; // Set the corner radius to 20
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        GraphicsPath path = new GraphicsPath();
        int radius = CornerRadius * 2;

        // Top-left corner
        path.AddArc(ClientRectangle.X, ClientRectangle.Y, radius, radius, 180, 90);

        // Top-right corner
        path.AddArc(ClientRectangle.Right - radius, ClientRectangle.Y, radius, radius, 270, 90);

        // Bottom-right corner
        path.AddArc(ClientRectangle.Right - radius, ClientRectangle.Bottom - radius, radius, radius, 0, 90);

        // Bottom-left corner
        path.AddArc(ClientRectangle.X, ClientRectangle.Bottom - radius, radius, radius, 90, 90);

        path.CloseFigure();

        Region = new Region(path);

        using (Pen pen = new Pen(FlatStyle == FlatStyle.Popup ? SystemColors.ControlDark : SystemColors.ControlDarkDark, 1.5f))
        {
            e.Graphics.DrawPath(pen, path);
        }
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        Invalidate(); // Force the control to repaint after a click
    }
}
