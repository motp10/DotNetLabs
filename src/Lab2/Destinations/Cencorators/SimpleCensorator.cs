using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations.Cencorators;

public class SimpleCensorator : ICensorator
{
    private readonly IReadOnlyCollection<Message> _bannedWords;

    public SimpleCensorator(IReadOnlyCollection<Message> bannedWords)
    {
        _bannedWords = bannedWords;
    }

    public bool CheckMessage(Message message)
    {
        return _bannedWords.Contains(message);
    }
}