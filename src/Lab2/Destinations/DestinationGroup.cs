using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public class DestinationGroup : IDestination
{
    private readonly IReadOnlyCollection<User> _usersGroup;

    public DestinationGroup(IReadOnlyCollection<User> usersGroup)
    {
        _usersGroup = usersGroup;
    }

    public void Recieve(Message message)
    {
        foreach (User user in _usersGroup)
        {
            user.ReceiveMessage(message);
        }
    }
}