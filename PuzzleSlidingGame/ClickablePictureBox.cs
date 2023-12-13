using System;
using System.Windows.Forms;

public class ClickablePictureBox : PictureBox
{
    public event EventHandler ImageClick;

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        ImageClick?.Invoke(this, EventArgs.Empty);
    }
}
