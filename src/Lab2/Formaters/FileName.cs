namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters;

public record FileName
{
    public string Value { get; }

    public FileName(string value)
    {
        Value = value;
    }
}