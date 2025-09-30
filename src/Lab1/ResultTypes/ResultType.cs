using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record ResultType
{
    private ResultType() { }

    public sealed record Success : ResultType
    {
        public Success(Time time)
        {
            PastTime = time;
        }

        public Time PastTime { get; }
    }

    public sealed record Failed : ResultType
    {
    }

    public static ResultType operator +(ResultType left, ResultType right)
    {
        var totalTime = new Time(0);

        if ((left is Success left_res) &&
            (right is Success right_res))
        {
            totalTime = new Time(left_res.PastTime.Value + right_res.PastTime.Value);
            return new Success(totalTime);
        }

        return new Failed();
    }
}