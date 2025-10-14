using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class InMemoryArchivator : IArchivator
{
    private readonly List<Message> _messages;

    public InMemoryArchivator()
    {
        _messages = new List<Message>();
    }

    public void WriteMessage(Message msg)
    {
        _messages.Add(msg);
    }
}