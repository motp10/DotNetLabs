namespace Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;

public record Body
{
    public string Value { get; }

    public Body(string body)
    {
        Value = body;
    }
}