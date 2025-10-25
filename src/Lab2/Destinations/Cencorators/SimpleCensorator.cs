using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Cencorators;

public class SimpleCensorator : ICensorator
{
    private readonly Collection<Message> _bannedWords;

    public SimpleCensorator(Collection<Message> bannedWords)
    {
        _bannedWords = bannedWords;
    }

    public bool CheckMessage(Message message)
    {
        return _bannedWords.Contains(message);
    }
}