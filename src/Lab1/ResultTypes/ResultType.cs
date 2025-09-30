using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record ResultType
{
    private ResultType() { }

    public sealed record Success(Time PastTime) : ResultType;

    public sealed record Failed : ResultType;
}