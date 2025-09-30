using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public Force MaxForce { get; private set; }

    public Speed Velocity { get; private set; }

    private readonly Mass _weight;

    private Acceleration _boost;

    public Train(Mass mass, Force force)
    {
        _weight = mass;
        Velocity = new Speed(0);
        _boost = new Acceleration(0);
        MaxForce = force;
    }

    public void ForceApplication(Force force)
    {
        _boost = new Acceleration(force, _weight);
    }

    public ResultTypes.IterationResult DistancePassing(Distance distance, Time interval)
    {
        var pastDistance = new Distance(0);
        var pastTime = new Time(0);
        while (pastDistance < distance)
        {
            UpdateSpeed(interval);
            if (Velocity == Speed.MinimalSpeed)
            {
                return new ResultTypes.IterationResult.Failed();
            }

            pastDistance = Distance.Create(PastDistance(interval), pastDistance);
            pastTime = Time.Create(pastTime, interval);
        }

        return new ResultTypes.IterationResult.Success(pastTime);
    }

    private void UpdateSpeed(Time time)
    {
        Velocity = new Speed(Velocity, _boost, time);
    }

    private Distance PastDistance(Time time)
    {
        return new Distance(Velocity, time);
    }
}