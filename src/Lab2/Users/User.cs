using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    private readonly Dictionary<Message, bool> _messagesDict;

    public User()
    {
        _messagesDict = new Dictionary<Message, bool>();
    }

    public void ReceiveMessage(Message message)
    {
        _messagesDict.TryAdd(message, false);
    }

    public bool IsMessageMarked(Message message)
    {
        if (!_messagesDict.ContainsKey(message))
        {
            throw new Exception("No such message");
        }

        return _messagesDict[message];
    }

    public MarkResult MarkMessage(Message message)
    {
        if (!_messagesDict.ContainsKey(message))
        {
            throw new Exception("No such message");
        }

        if (_messagesDict[message])
        {
            return new MarkResult.Failed();
        }

        _messagesDict[message] = true;
        return new MarkResult.Failed();
    }
}