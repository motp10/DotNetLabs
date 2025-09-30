using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public Train(Mass mass, Force force)
    {
        Weight = mass;
        Velocity = new Speed(0);
        Boost = new Acceleration(0);
        MaxForce = force;
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
            if (Velocity == Speed.MinimalSpeed)
            {
                return new ResultTypes.ResultType.Failed();
            }

            pastDistance = Distance.Create(PastDistance(interval), pastDistance);
            pastTime = Time.Create(pastTime, interval);
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

    private Acceleration Boost { get; set; }

    private Mass Weight { get; }
}