using Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.DestinationDecorators;

public class LoggerDecorator : IDestination
{
    private readonly IDestination _destination;

    private readonly ILogger _logger;

    public LoggerDecorator(IDestination destination, ILogger logger)
    {
        _destination = destination;
        _logger = logger;
    }

    public void Recieve(Message message)
    {
        _logger.Log(message);
        _destination.Recieve(message);
    }
}