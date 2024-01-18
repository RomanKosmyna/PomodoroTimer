namespace PomodoroTimer;

class Program
{
    private static readonly Timer timer = new();

    static void Main()
    {
        Settings.ApplySettings();

        Settings.RunApp(timer);
    }
}