using static System.Console;

namespace PomodoroTimer;

internal static class StartingWindow
{
    public static void InitialiseStartingText()
    {
        WriteLine("Welcome to Pomodoro Timer application.");
        Write("\n");
        WriteLine("When started, this application will remain working and each 30 minutes it will play a sound.");
        Write("\n");
        WriteLine("To start press Enter");
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
