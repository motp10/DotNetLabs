using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record TrainDistancePassingResult
{
    private TrainDistancePassingResult() { }

    public sealed record Success(Time PastTime) : TrainDistancePassingResult;

    public sealed record Failed : TrainDistancePassingResult;
}