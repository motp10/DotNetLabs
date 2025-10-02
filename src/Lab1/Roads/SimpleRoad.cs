using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class SimpleRoad : ITrackSection
{
    private readonly Distance _lenght;

    public SimpleRoad(Distance length)
    {
        _lenght = length;
    }

    public ResultTypes.IterationResult TrainInteraction(Train train, Time interval)
    {
        return train.DistancePassing(_lenght, interval);
    }
}