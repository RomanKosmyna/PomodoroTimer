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
        string input = "";

        do
        {
            keyInfo = ReadKey();
            
            if (keyInfo.Key != ConsoleKey.Enter)
            {
                Write("\n");
                WriteLine("Input is incorrect. It needs to be Enter.");
                continue;
            }
            else
            {
                input = keyInfo.Key.ToString();
            }

            if (string.IsNullOrEmpty(input))
            {
                WriteLine("Input can not be empty.");
                continue;
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);
    
        return input;
    }
}
