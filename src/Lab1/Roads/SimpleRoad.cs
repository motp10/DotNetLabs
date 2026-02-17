using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
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

    public IterationResult TrainInteraction(Train train, Time interval)
    {
        TrainDistancePassingResult result = train.DistancePassing(_lenght, interval);

        if (result is TrainDistancePassingResult.Success res)
        {
            return new IterationResult.Success(res.PastTime);
        }

        return new IterationResult.Failed();
    }
}