using static System.Console;

namespace PomodoroTimer;

internal static class Settings
{
    private static readonly int _windowWidth = 60;
    private static readonly int _windowHeight = 20;

    public static void ApplySettings()
    {
        CursorVisible = false;

        SetDimensions();
    }

    public static void SetDimensions()
    {
        WindowWidth = _windowWidth;
        WindowHeight = _windowHeight;
        SetBufferSize(_windowWidth, _windowHeight);
    }

    public static void RunApp(Timer timer)
    {
        bool appStatus = true;
        bool error = false;

        do
        {
            StartingWindow.InitialiseStartingText();

            string input = StartingWindow.GetUserKey();

            switch (input)
            {
                case "Enter":
                    timer.StartTimer();
                    break;
                case "Escape":
                    timer.StopTimer();
                    break;
                default:
                    Write("\n");
                    WriteLine("Incorrect format.");
                    break;
            }

            ReadKey();
        }
        while (appStatus);
    }
}