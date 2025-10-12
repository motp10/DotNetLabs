using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public interface IDestination
{
    void Recieve(Message message);
}