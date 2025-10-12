namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public abstract record MarkResult
{
    private MarkResult() { }

    public sealed record Success() : MarkResult;

    public sealed record Failed : MarkResult;
}