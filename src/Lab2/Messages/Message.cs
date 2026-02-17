namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public string Head { get; }

    public string Body { get; }

    public MessageImportanceLevel ImportanceLevel { get; }

    public Message(string head, string body, MessageImportanceLevel importance)
    {
        Head = head;
        Body = body;
        ImportanceLevel = importance;
    }
}