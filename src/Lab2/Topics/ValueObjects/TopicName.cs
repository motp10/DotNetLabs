namespace Itmo.ObjectOrientedProgramming.Lab2.Topics.ValueObjects;

public record TopicName
{
    public string Value { get; }

    public TopicName(string value)
    {
        Value = value;
    }
}