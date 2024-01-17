namespace PomodoroTimer;

class Program
{
    static void Main()
    {
        Timer timer = new();
        timer.SetTimer();

        Console.ReadKey();
    }
}