using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.DestinationDecorators;

public class FilterDecorator : IDestination
{
    private readonly IDestination _destination;

    private readonly MessageImportanceLevel _messageImportanceLevel;

    public FilterDecorator(IDestination destination, MessageImportanceLevel messageImportanceLevel)
    {
        _destination = destination;
        _messageImportanceLevel = messageImportanceLevel;
    }

    public void Recieve(Message message)
    {
        if (message.ImportanceLevel > _messageImportanceLevel)
        {
            _destination.Recieve(message);
        }
    }
}