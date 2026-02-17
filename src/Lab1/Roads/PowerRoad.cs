using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class PowerRoad : ITrackSection
{
    private readonly Force _force;

    private readonly Distance _length;

    public PowerRoad(Distance length, Force force)
    {
        _length = length;
        _force = force;
    }

    public IterationResult TrainInteraction(Train train, Time interval)
    {
        if (train.TryForceApplication(_force))
        {
            TrainDistancePassingResult result = train.DistancePassing(_length, interval);

            if (!train.TryForceApplication(Force.Zero))
            {
                throw new Exception("Train couldn't stop");
            }

            if (result is TrainDistancePassingResult.Success res)
            {
                return new IterationResult.Success(res.PastTime);
            }
        }

        return new IterationResult.Failed();
    }
}