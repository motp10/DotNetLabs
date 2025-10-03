using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public record Route
{
    private readonly Speed _maxSpeed;

    private readonly IReadOnlyCollection<ITrackSection> _sections;

    public Route(IReadOnlyCollection<ITrackSection> sections, Speed maxSpeed)
    {
        _maxSpeed = maxSpeed;

        _sections = sections;
    }

    public SimulatorResult Simulate(Train train, Time period)
    {
        SimulatorResult result = new SimulatorResult.Success(new Time(0));

        Time totalTime = Time.Zero;

        foreach (ITrackSection section in _sections)
        {
            IterationResult iterationIterationResult = section.TrainInteraction(train, period);
            if (iterationIterationResult is IterationResult.Success success)
            {
                totalTime = Time.Create(totalTime, success.PastTime);
            }
            else
            {
                return new SimulatorResult.Failed();
            }
        }

        if (train.Velocity > _maxSpeed)
        {
            return new SimulatorResult.Failed();
        }

        return new SimulatorResult.Success(totalTime);
    }
}