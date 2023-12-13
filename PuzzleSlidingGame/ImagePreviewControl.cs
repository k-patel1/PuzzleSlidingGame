using System;
using System.Drawing;
using System.Windows.Forms;

public class ImagePreviewControl : PictureBox
{
    private float zoomFactor = 1.0f;

    public float ZoomFactor
    {
        get { return zoomFactor; }
        set
        {
            if (value > 0)
            {
                zoomFactor = value;
                Invalidate();
            }
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        if (Image != null)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Size newSize = new Size((int)(Image.Width * ZoomFactor), (int)(Image.Height * ZoomFactor));
            pe.Graphics.DrawImage(Image, new Rectangle(Point.Empty, newSize));
        }
    }
}
