using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record IterationResult
{
    private IterationResult() { }

    public sealed record Success(Time PastTime) : IterationResult;

    public sealed record Failed : IterationResult;
}