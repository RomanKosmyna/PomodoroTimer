namespace PomodoroTimer;

class Program
{
    static void Main()
    {
        Settings.ApplySettings();

        bool status = true;
        bool error = false;
        Timer timer = new();

        do
        {
            if (!error)
            {
                Console.Clear();
                StartingWindow.InitialiseStartingText();
                error = false;
            }

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
                    Console.Write("\n");
                    Console.WriteLine("Incorrect format.");
                    break;
            }

            Console.ReadKey();
        }
        while (status);
    }
}