using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SimulatorResult
{
    private SimulatorResult() { }

    public sealed record Success(Time PastTime) : SimulatorResult;

    public sealed record Failed : SimulatorResult;
}