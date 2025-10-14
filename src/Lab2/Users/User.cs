using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    private readonly Dictionary<Message, bool> _messagesDict;

    public User()
    {
        _messagesDict = new Dictionary<Message, bool>();
    }

    public void ReceiveMessage(Message msg)
    {
        _messagesDict.Add(msg, false);
    }

    public bool IsMessageMarked(Message msg)
    {
        return _messagesDict[msg];
    }

    public MarkResult MarkMessage(Message msg)
    {
        if (!_messagesDict.ContainsKey(msg))
        {
            throw new Exception("No such message");
        }

        if (_messagesDict[msg])
        {
            return new MarkResult.Failed();
        }

        _messagesDict[msg] = true;
        return new MarkResult.Failed();
    }
}