namespace Models.ValueObjects;

public readonly record struct Password
{
    public static Password Null => new Password(string.Empty);

    public string Value { get; }

    public Password(string value)
    {
        Value = value;
    }
}