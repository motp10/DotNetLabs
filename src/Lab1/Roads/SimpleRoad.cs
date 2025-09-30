using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class SimpleRoad : IRoadSegment
{
    public Distance Length { get; }

    private static Force Force => new Force(0);

    public SimpleRoad(decimal length)
    {
        Length = new Distance(length);
    }

    public ResultTypes.ResultType TrainInteraction(Train train, Time time)
    {
        train.ForceApplication(Force);

        return train.DistancePassing(Length, time);
    }
}