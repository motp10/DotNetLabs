using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train : ITrain
{
    public Train(decimal mass, decimal force)
    {
        Weight = new Mass(mass);
        Velocity = new Speed(0);
        Boost = new Acceleration(0);
        MaxForce = new Force(force);
    }

    public void ForceApplication(Force force)
    {
        Boost = new Acceleration(force, Weight);
    }

    public ResultTypes.ResultType DistancePassing(Distance distance, Time interval)
    {
        var pastDistance = new Distance(0);
        var pastTime = new Time(0);
        while (pastDistance < distance)
        {
            UpdateSpeed(interval);
            if (Velocity.Value == 0)
            {
                return new ResultTypes.ResultType.Failed("Train is too slaw");
            }

            pastDistance = new Distance(PastDistance(interval).Value + pastDistance.Value);
            pastTime = new Time(pastTime.Value + interval.Value);
        }

        return new ResultTypes.ResultType.Success(pastTime);
    }

    private void UpdateSpeed(Time time)
    {
        Velocity = new Speed(Velocity, Boost, time);
    }

    private Distance PastDistance(Time time)
    {
        return new Distance(Velocity, time);
    }

    public Force MaxForce { get; private set; }

    public Speed Velocity { get; private set; }

    public Acceleration Boost { get; private set; }

    public Mass Weight { get; private set; }
}