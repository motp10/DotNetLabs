using Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.DestinationDecorators;

public class LoggerDestination : IDestination
{
    private readonly IDestination _destination;

    private readonly ILogger _logger;

    public LoggerDestination(IDestination destination, ILogger logger)
    {
        _destination = destination;
        _logger = logger;
    }

    public void Recieve(Message message)
    {
        _logger.Log(message.Head);
        _logger.Log(message.Body);
        _destination.Recieve(message);
    }
}