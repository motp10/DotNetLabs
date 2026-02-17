using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.DestinationDecorators;

public class FilterDecorator : IDestination
{
    private readonly IDestination _destination;

    private readonly MesageImportanceLevel _mesageImportanceLevel;

    public FilterDecorator(IDestination destination, MesageImportanceLevel mesageImportanceLevel)
    {
        _destination = destination;
        _mesageImportanceLevel = mesageImportanceLevel;
    }

    public void Recieve(Message message)
    {
        if (message.ImportanceLevel > _mesageImportanceLevel)
        {
            _destination.Recieve(message);
        }
    }
}