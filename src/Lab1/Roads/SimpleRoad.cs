using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class SimpleRoad : ITrackSection
{
    public Distance Length { get; }

    public SimpleRoad(Distance length)
    {
        Length = length;
    }

    public ResultTypes.IterationResult TrainInteraction(Train train, Time time)
    {
        return train.DistancePassing(Length, time);
    }
}