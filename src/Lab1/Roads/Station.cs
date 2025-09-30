using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public class Station : IStationSegment
{
    public Station(Speed arriveLimit, Time time)
    {
        ArriveLimit = arriveLimit;
        BoardingAndDisembarking = time;
    }

    public Speed ArriveLimit { get; }

    public Time BoardingAndDisembarking { get; }

    public ResultTypes.ResultType TrainInteraction(Train train, Time time)
    {
        train.ForceApplication(new Force(0));

        if (train.Velocity > ArriveLimit)
        {
            return new ResultTypes.ResultType.Failed();
        }

        if (train.Velocity == Speed.MinimalSpeed)
        {
            return new ResultTypes.ResultType.Failed();
        }

        return new ResultTypes.ResultType.Success(BoardingAndDisembarking);
    }
}