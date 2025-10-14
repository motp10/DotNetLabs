using Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public Head Head { get; }

    public Body Body { get; }

    public MessageImportanceLevel ImportanceLevel { get; }

    public Message(string head, string body, MessageImportanceLevel importance)
    {
        Head = new Head(head);
        Body = new Body(body);
        ImportanceLevel = importance;
    }
}