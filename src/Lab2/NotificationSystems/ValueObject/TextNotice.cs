namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems.ValueObject;

public record TextNotice
{
    public string Value { get; }

    public TextNotice(string value)
    {
        Value = value;
    }
}