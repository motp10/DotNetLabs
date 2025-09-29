using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public interface ITrain
{
    void ForceApplication(Force force);

    ResultTypes.ResultType DistancePassing(Distance distance, Time interval);

    Force MaxForce { get; }

    Speed Velocity { get; }

    Mass Weight { get; }

    Acceleration Boost { get; }
}