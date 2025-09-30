using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SimulatorResult
{
    private SimulatorResult() { }

    public sealed record Success : SimulatorResult
    {
        public Success(Time time)
        {
            PastTime = time;
        }

        public Time PastTime { get; }
    }

    public sealed record Failed : SimulatorResult
    {
    }
}