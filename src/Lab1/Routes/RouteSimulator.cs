using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class RouteSimulator
{
    public SimulatorResult Simulate(Route route, Train train, Time period)
    {
        SimulatorResult result = new SimulatorResult.Success(new Time(0));

        var totalTime = new Time(0);

        foreach (ITrackSection section in route.Sections)
        {
            ResultType iterationResult = section.TrainInteraction(train, period);
            if (iterationResult is ResultType.Success success)
            {
                totalTime = Time.Create(totalTime, success.PastTime);
            }
            else
            {
                return new SimulatorResult.Failed();
            }
        }

        if (train.Velocity > route.MaxSpeed)
        {
            return new SimulatorResult.Failed();
        }

        return new SimulatorResult.Success(totalTime);
    }
}