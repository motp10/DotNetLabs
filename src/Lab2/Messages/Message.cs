using Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public Head Head { get; }

    public Body Body { get; }

    public MesageImportanceLevel ImportanceLevel { get; }

    public Message(string title, string body, MesageImportanceLevel importance)
    {
        Head = new Head(title);
        Body = new Body(body);
        ImportanceLevel = importance;
    }
}