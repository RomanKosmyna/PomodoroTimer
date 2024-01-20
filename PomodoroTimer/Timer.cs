using System.Diagnostics;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace PomodoroTimer
{
    internal class Timer
    {
        private readonly int _interval = 1000;
        private readonly System.Timers.Timer _timer;

        public System.Timers.Timer GetTimer => _timer;

        public Timer()
        {
            _timer = new System.Timers.Timer(_interval);
        }

        public void RenderCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            
            Clear();
     
            WriteLine("Timer has been set.");
            Write("\n");
            WriteLine($"Current time is {currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}.");
        }

        public async Task StartCounter()
        {
            int totalSeconds = 30 * 60;
            int remainingSeconds = totalSeconds;

            WriteLine("\nTime left:");
            
            _timer.Elapsed += (sender, e) =>
            {
                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;

                Write($"{minutes:00}:{seconds:00}\r");

                remainingSeconds--;

                if (remainingSeconds == 0)
                {
                    _timer.Stop();
                    _timer.Dispose();
                    Audio.OutputEndingAudio();
                }
            };

            _timer.Start();
        }

        public static void StopTimer(string userInput)
        {
            if ( userInput == "Escape")
            {
                Environment.Exit(0);
            }
        }
    }
}