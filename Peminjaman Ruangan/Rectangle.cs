using System.Drawing;
using System.Windows.Forms;

public class RectangleControl : Control
{
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (SolidBrush brush = new SolidBrush(BackColor))
        {
            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }
}
