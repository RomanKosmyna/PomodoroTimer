using System.Diagnostics;
using static System.Console;

namespace PomodoroTimer;

internal static class Settings
{
    private static readonly int _windowWidth = 60;
    private static readonly int _windowHeight = 20;

    public static void ApplySettings()
    {
        Title = "Pomodoro Timer";
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
            if (!error)
            {
                error = false;
                StartingWindow.InitialiseStartingText();
            }

            string input = StartingWindow.GetUserKey();

            if (input == "Enter")
            {
                StartApplication(timer);
                appStatus = false;
            }
            else
            {
                error = true;
                WriteLine("\nPress Enter to continue!");
            }
        }
        while (appStatus);
    }

    public static void RenderInstructionsBox()
    {
        var initialCursorPosition = new { Left = CursorLeft, Top = CursorTop };
        string[,] arr = new string[9, 34];

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = " ";
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                SetCursorPosition(j + 1, 7 + i);
                bool isBorder = j == 0 || j == arr.GetLength(1) - 1 || i == 0 || i == arr.GetLength(0) - 1;

                if (isBorder)
                {
                    BackgroundColor = ConsoleColor.DarkGray;
                    Write(arr[i, j]);
                }
                else
                {
                    BackgroundColor = ConsoleColor.Black;
                    Write(" ");
                }
                ResetColor();
            }
            WriteLine();
        }

        SetCursorPosition(initialCursorPosition.Left, initialCursorPosition.Top);
    }

    public static void RenderInstructionsContent()
    {
        var initialCursorPosition = new { Left = CursorLeft, Top = CursorTop };

        SetCursorPosition(2, 8);
        Write("To pause/unpause, press ");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("<enter>");
        ResetColor();

        SetCursorPosition(2, 10);
        Write("To restart, press ");
        ForegroundColor = ConsoleColor.Blue;
        WriteLine("<RightArrow>");
        ResetColor();

        SetCursorPosition(2, 12);
        Write("To stop, press ");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("<UpArrow>");
        ResetColor();

        SetCursorPosition(2, 14);
        Write("To close, press ");
        ForegroundColor = ConsoleColor.Red;
        WriteLine("<escape>");
        ResetColor();

        SetCursorPosition(initialCursorPosition.Left, initialCursorPosition.Top);
    }

    //public static async Task StartApplication(Timer timer)
    //{
    //    bool status = true;

    //    do
    //    {
    //        Task timerTask = timer.StartTimer();
    //        Task audioTask = Task.Run(Audio.OutputStartingAudio);

    //        RenderInstructionsBox();
    //        RenderInstructionsContent();

    //        Task counterTask = Timer.StartCounter();

    //        var initialCursorPosition = new { Left = CursorLeft, Top = CursorTop };

    //        Task<string> userInputTask = StartingWindow.GetUserKeyAsync();
    //        await Out.WriteLineAsync(userInputTask.Result);

    //        await Task.WhenAny(userInputTask, counterTask);

    //        if (userInputTask.IsCompleted && userInputTask.Result != null)
    //        {
    //            if (userInputTask.Result == "Enter")
    //            {
    //                ToggleApplication();
    //            }
    //            else if (userInputTask.Result == "RightArrow")
    //            {
    //                RestartApplication();
    //            }
    //            else if (userInputTask.Result == "UpArrow")
    //            {
    //                RestartApplication();
    //            }
    //            else if (userInputTask.Result == "Escape")
    //            {
    //                CloseApplication();
    //            }
    //        }

    //        if (counterTask.IsCompleted)
    //        {
    //            Audio.OutputEndingAudio();
    //        }
    //        else
    //        {
    //            await counterTask;
    //            Audio.OutputEndingAudio();
    //        }
    //    }
    //    while (status);
    //}
    public static async Task StartApplication(Timer timer)
    {
        bool appStatus = true;
        
        do
        {
            Clear();
            WriteLine("\nYou are inside StartApp method!");
            // Renders current time on a screen.
            timer.RenderCurrentTime();
            Task.Run(Audio.OutputStartingAudio);

            // Renders a box in the bottom part of the application with possible options.
            RenderInstructionsBox();
            RenderInstructionsContent();

            // Starts counter for how much time is left.
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task runCounter = timer.StartCounter(cancellationTokenSource);

            Task<string> input = StartingWindow.GetUserKeyAsync();
            await Out.WriteLineAsync(input.Result);
            if (input.Result != "Enter")
            {
                cancellationTokenSource.Cancel();
                continue;
            }
        }
        while (appStatus);
    }

    public static void RestartApplication()
    {
        string exePath = Process.GetCurrentProcess().MainModule.FileName;

        Process.Start(new ProcessStartInfo
        {
            FileName = exePath,
            UseShellExecute = true
        });

        Environment.Exit(0);
    }

    public static void ToggleApplication()
    {

    }

    public static void CloseApplication()
    {
        Environment.Exit(0);
    }
}