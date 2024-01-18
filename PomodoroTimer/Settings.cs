using static System.Console;

namespace PomodoroTimer;

internal static class Settings
{
    private static readonly int _windowWidth = 90;
    private static readonly int _windowHeight = 20;

    public static void ApplySettings()
    {
        SetDimensions();
    }

    public static void SetDimensions()
    {
        WindowWidth = _windowWidth;
        WindowHeight = _windowHeight;
        SetBufferSize(_windowWidth, _windowHeight);
    }
}