using Itmo.ObjectOrientedProgramming.Lab2.Archivators;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public class ArchivatorDestination : IDestination
{
    private readonly IArchivator _archivator;

    public ArchivatorDestination(IArchivator archivator)
    {
        _archivator = archivator;
    }

    public void Recieve(Message message)
    {
        _archivator.WriteMessage(message);
    }
}