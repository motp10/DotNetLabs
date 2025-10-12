namespace Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;

public record Head
{
    public string Value { get; }

    public Head(string head)
    {
        Value = head;
    }
}