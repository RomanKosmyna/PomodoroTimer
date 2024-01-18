namespace PomodoroTimer;

class Program
{
    static void Main()
    {
        bool status = true;
        bool error = false;
        Timer timer = new Timer();

        do
        {
            if (!error)
            {
                Console.Clear();
                StartingWindow.InitialiseStartingText();
                error = false;
            }

            string input = StartingWindow.GetUserKey();
            
            //if (input != "Enter")
            //{
            //    Console.Write("\n");
            //    Console.WriteLine("Please, try again.");
            //    error = true;
            //    continue;
            //}
            
            switch (input)
            {
                case "Enter":
                    timer.StartTimer();
                    break;
                case "Escape":
                    Environment.Exit(0);
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