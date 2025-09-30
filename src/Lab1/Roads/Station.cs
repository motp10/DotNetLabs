using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class Station : ITrackSection
{
    public Speed ArriveLimit { get; }

    public Time BoardingAndDisembarking { get; }

    public Station(Speed arriveLimit, Time time)
    {
        ArriveLimit = arriveLimit;
        BoardingAndDisembarking = time;
    }

    public ResultTypes.IterationResult TrainInteraction(Train train, Time time)
    {
        train.ForceApplication(new Force(0));

        if (train.Velocity > ArriveLimit)
        {
            return new ResultTypes.IterationResult.Failed();
        }

        if (train.Velocity == Speed.MinimalSpeed)
        {
            return new ResultTypes.IterationResult.Failed();
        }

        return new ResultTypes.IterationResult.Success(BoardingAndDisembarking);
    }
}