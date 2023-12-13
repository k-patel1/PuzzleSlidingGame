using System;
using System.Windows.Forms;

public class PlayerTimerControl : Label
{
    private DateTime startTime;

    public void StartTimer()
    {
        startTime = DateTime.Now;
        Timer timer = new Timer { Interval = 1000 };
        timer.Tick += UpdateTimer;
        timer.Start();
    }

    private void UpdateTimer(object sender, EventArgs e)
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        Text = $"Time: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
    }
}
