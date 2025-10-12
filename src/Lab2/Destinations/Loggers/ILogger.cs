using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;

public interface ILogger
{
    void Log(Message message);
}