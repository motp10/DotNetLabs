using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Cencorators;

public interface ICensorator
{
    bool CheckMessage(Message message);
}