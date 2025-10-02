using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public Speed Velocity { get; private set; }

    private readonly Force _maxForce;

    private readonly Mass _weight;

    private Acceleration _boost;

    public Train(Mass mass, Force force)
    {
        _weight = mass;
        Velocity = Speed.Zero;
        _boost = Acceleration.Zero;
        _maxForce = force;
    }

    public bool TryForceApplication(Force force)
    {
        if (force > _maxForce)
        {
            return false;
        }

        _boost = new Acceleration(force, _weight);

        return true;
    }

    public ResultTypes.IterationResult DistancePassing(Distance distance, Time interval)
    {
        Distance pastDistance = Distance.Zero;

        Time pastTime = Time.Zero;

        while (pastDistance < distance)
        {
            UpdateSpeed(interval);

            if (Velocity == Speed.Zero)
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