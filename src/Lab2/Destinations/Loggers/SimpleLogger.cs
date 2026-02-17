namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;

public class SimpleLogger : ILogger
{
    private readonly List<string> _messages;

    public SimpleLogger()
    {
        _messages = new List<string>();
    }

    public void Log(string message)
    {
        _messages.Add(message);
    }
}