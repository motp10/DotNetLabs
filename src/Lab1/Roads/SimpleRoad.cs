using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class SimpleRoad : IRoadSegment
{
    public Distance Length { get; }

    public SimpleRoad(decimal length)
    {
        Length = new Distance(length);
    }

    public ResultTypes.ResultType TrainInteraction(ITrain train, Time time)
    {
        train.ForceApplication(new Force(0));

        return train.DistancePassing(Length, time);
    }
}