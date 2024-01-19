using static System.Console;

namespace PomodoroTimer;

internal static class StartingWindow
{
    public static void InitialiseStartingText()
    {
        WriteLine("Welcome to Pomodoro Timer application.");
        Write("\n");
        WriteLine("After 30 minutes a sound will be played.");
        Write("\n");
        Write("To start, press ");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("<enter>");
        ResetColor();
    }

    public static string GetUserKey()
    {
        ConsoleKeyInfo keyInfo;
        string input;

        keyInfo = ReadKey();
        input = keyInfo.Key.ToString();
        
        return input;
    }
}
