namespace Models.ValueObjects;

public readonly record struct SessionKey
{
    public Guid Value { get; }

    public SessionKey()
    {
        Value = Guid.NewGuid();
    }

    public SessionKey(Guid value)
    {
        Value = value;
    }
}