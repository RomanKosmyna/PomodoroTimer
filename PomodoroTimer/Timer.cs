using System.Diagnostics;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace PomodoroTimer
{
    internal class Timer
    {
        private readonly int _interval = 100;
        private static readonly int _pomodoroTime = 30;
        private readonly System.Timers.Timer _timer;

        public Timer()
        {
            _timer = new System.Timers.Timer(_interval);
        }

        public static void Run()
        {
            StartingWindow.InitialiseStartingText();

            string input = StartingWindow.GetUserKey();

            ReadKey();
        }

        public async Task StartTimer()
        {
            DateTime currentTime = DateTime.Now;
            
            Clear();
     
            WriteLine("Timer has been set.");
            Write("\n");
            WriteLine($"Current time is {currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}.");
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public static async Task StartCounter()
        {
            bool counterActive = true;
            int totalSeconds = 1 * 10;
            int remainingSeconds = totalSeconds;

            Write("\n");
            WriteLine("Time left:");
            do
            {
                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;

                Write($"{minutes:00}:{seconds:00}\r");

                remainingSeconds--;
                await Task.Delay(1000);
                if (remainingSeconds == 0)
                {
                    counterActive = false;
                }
            }
            while (counterActive);
        }

        public static void StopTimer(string userInput)
        {
            if ( userInput == "Escape")
            {
                Environment.Exit(0);
            }
        }

        public void SetTimer()
        {
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = false;
            _timer.Enabled = true;
        }

        public void OnTimedEvent(object sender, EventArgs e)
        {
            //string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _audioFileName);

            //using var audioFile = new AudioFileReader(fullPath);
            //using var outputDevice = new WaveOutEvent();
            //outputDevice.Init(audioFile);
            //outputDevice.Play();

            //while (outputDevice.PlaybackState == PlaybackState.Playing)
            //{
            //    Thread.Sleep(1000);
            //}
        }
    }
}