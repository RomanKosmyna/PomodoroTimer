using static System.Console;

namespace PomodoroTimer;

internal class Break
{
    private static readonly int _duration = 5;

    public static void SetBreak()
    {
        bool breakActive = true;
        int totalSeconds = 5 * 60;
        int remainingSeconds = totalSeconds;
        Audio.OutputEndingAudio();
        Clear();
        WriteLine("Break left:");
        do
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;

            Write($"{minutes:00}:{seconds:00}\r");
            Thread.Sleep(1000);
            remainingSeconds--;

            if (remainingSeconds == 0)
            {
                breakActive = false;
            }
        }
        while (breakActive);
    }
}
