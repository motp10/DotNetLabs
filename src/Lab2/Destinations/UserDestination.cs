using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public class UserDestination : IDestination
{
    private readonly IUser _user;

    public UserDestination(IUser user)
    {
        _user = user;
    }

    public void Recieve(Message message)
    {
        _user.ReceiveMessage(message);
    }
}