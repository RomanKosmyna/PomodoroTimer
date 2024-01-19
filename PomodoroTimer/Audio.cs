using NAudio.Wave;

namespace PomodoroTimer;

internal class Audio
{
    private static readonly string _startingAudioFileName = "Start.mp3";
    private static readonly string _endingAudioFileName = "End.mp3";

    public static void OutputStartingAudio()
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

    public static async Task OutputEndingAudio()
    {
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _endingAudioFileName);

        using var audioFile = new AudioFileReader(fullPath);
        using var outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFile);
        outputDevice.Play();

        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            await Task.Delay(1000);
        }
    }
}