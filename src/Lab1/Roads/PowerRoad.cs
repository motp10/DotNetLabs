using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class PowerRoad : IRoadSegment
{
    public PowerRoad(decimal length, decimal force)
    {
        Length = new Distance(length);
        Force = new Force(force);
    }

    public Distance Length { get; }

    private Force Force { get; }

    public ResultTypes.ResultType TrainInteraction(Train train, Time time)
    {
        train.ForceApplication(Force);

        if (Force > train.MaxForce)
        {
            return new ResultTypes.ResultType.Failed();
        }

        return train.DistancePassing(Length, time);
    }
}