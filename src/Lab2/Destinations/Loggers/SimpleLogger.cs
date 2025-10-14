using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;

public class SimpleLogger : ILogger
{
    private readonly List<Message> _messages;

    public SimpleLogger()
    {
        _messages = new List<Message>();
    }

    public void Log(Message message)
    {
        _messages.Add(message);
    }
}