using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class RouteSimulator
{
    public ResultType Simulate(Route route, Train train, decimal time = 1)
    {
        var period = new Time(time);
        ResultType result = new ResultType.Success(new Time(0));

        foreach (ITrackSection section in route.Sections)
        {
            ResultType iterationResult = section.TrainInteraction(train, period);
            result += iterationResult;
            if (result is ResultType.Failed)
            {
                return result;
            }
        }

        if (train.Velocity > route.MaxSpeed)
        {
            return new ResultType.Failed();
        }

        return result;
    }
}