using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class Station : ITrackSection
{
    private readonly Speed _arriveLimit;

    private readonly Time _boardingAndDisembarking;

    public Station(Speed arriveLimit, Time time)
    {
        _arriveLimit = arriveLimit;
        _boardingAndDisembarking = time;
    }

    public IterationResult TrainInteraction(Train train, Time interval)
    {
        if ((train.Velocity > _arriveLimit) || Speed.IsZero(train.Velocity))
        {
            return new IterationResult.Failed();
        }

        return new IterationResult.Success(_boardingAndDisembarking);
    }
}