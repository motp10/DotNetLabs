using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public class DestinationGroup : IDestination
{
    private readonly IReadOnlyCollection<IDestination> _usersGroup;

    public DestinationGroup(IReadOnlyCollection<IDestination> usersGroup)
    {
        _usersGroup = usersGroup;
    }

    public void Recieve(Message message)
    {
        foreach (IDestination user in _usersGroup)
        {
            user.Recieve(message);
        }
    }
}