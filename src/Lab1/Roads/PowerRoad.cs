using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class PowerRoad : ITrackSection
{
    public Distance Length { get; }

    private readonly Force _force;

    public PowerRoad(Distance length, Force force)
    {
        Length = length;
        _force = force;
    }

    public IterationResult TrainInteraction(Train train, Time time)
    {
        train.ForceApplication(_force);

        if (_force > train.MaxForce)
        {
            train.ForceApplication(new Force(0));

            return new IterationResult.Failed();
        }

        IterationResult result = train.DistancePassing(Length, time);

        train.ForceApplication(new Force(0));

        return result;
    }
}