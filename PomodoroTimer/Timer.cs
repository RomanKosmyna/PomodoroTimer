using System.Globalization;
using static System.Console;

namespace PomodoroTimer;

internal class Timer
{
    private readonly int _interval = 3000;
    private static System.Timers.Timer _timer;

    public Timer()
    {
        _timer = new System.Timers.Timer(_interval);
    }

    public static void Run()
    {
        StartingWindow.InitialiseStartingText();

        string input = StartingWindow.GetUserKey();

        StartTimer(input);

        ReadKey();
    }

    public static void StartTimer(string userInput)
    {
        if (userInput == "Enter")
        {
            DateTime currentTime = DateTime.Now;

            Clear();
            WriteLine($"Timer has been set. Current time is {currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}.");

            Timer timer = new();
            timer.SetTimer();
        }
    }

    public void SetTimer()
    {
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    public void OnTimedEvent(object sender, EventArgs e)
    {
        Beep();
    }
}