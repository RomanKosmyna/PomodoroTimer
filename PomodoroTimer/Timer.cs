using NAudio.Wave;
using System.Globalization;
using static System.Console;

namespace PomodoroTimer
{
    internal class Timer
    {
        private readonly int _interval = 100;
        private static readonly int _pomodoroTime = 30;
        private readonly System.Timers.Timer _timer;
        private readonly string _audioFileName = "Sound.mp3";
        private readonly string _startingAudioFileName = "Start.mp3";

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

        public void StartTimer()
        {
            DateTime currentTime = DateTime.Now;
            //DateTime audioPlayTime = currentTime.AddMinutes(_pomodoroTime);
            Clear();
     
            WriteLine("Timer has been set.");
            Write("\n");
            WriteLine($"Current time is {currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}.");
            //WriteLine($"Sound will play on {audioPlayTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}.");
            Task.Run(() => OutputStartingAudio());
            StartCounter();
            //SetTimer();
            OutputEndingAudio();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public static void StartCounter()
        {
            bool counterActive = true;
            int totalSeconds = 1 * 10;
            int remainingSeconds = totalSeconds;

            WriteLine("Time left:");
            do
            {
                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;

                Write($"{minutes:00}:{seconds:00}\r");

                remainingSeconds--;
                Thread.Sleep(1000);
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
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _audioFileName);

            using var audioFile = new AudioFileReader(fullPath);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }

        public void OutputStartingAudio()
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _startingAudioFileName);

            using var audioFile = new AudioFileReader(fullPath);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }

        public void OutputEndingAudio()
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _audioFileName);

            using var audioFile = new AudioFileReader(fullPath);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }
    }
}