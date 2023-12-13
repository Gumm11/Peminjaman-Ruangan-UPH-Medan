using System;
using System.Drawing;
using System.Windows.Forms;

public class ImageButton : Button
{
    public new Image Image { get; set; }

    public ImageButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(100, 100); // Adjust the default size as needed

        // Set the event handler for click events
        Click += ImageButton_Click;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the image as the button's background
        if (Image != null)
        {
            e.Graphics.DrawImage(Image, ClientRectangle);
        }
    }

    private void ImageButton_Click(object sender, EventArgs e)
    {
        // Handle the click event as needed
        // You can override this method in derived classes or subscribe to the Click event
        // Example: MessageBox.Show("Button Clicked!");
    }
}
