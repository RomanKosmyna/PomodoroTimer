namespace PomodoroTimer;

internal class Timer
{
    private static System.Timers.Timer _timer;
    private readonly int _interval = 30000;

    public void SetTimer()
    {
        _timer = new System.Timers.Timer(_interval);
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    public void OnTimedEvent(object sender, EventArgs e)
    {
        Console.Beep();
    }
}