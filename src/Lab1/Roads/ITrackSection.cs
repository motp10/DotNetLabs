using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface ITrackSection
{
    ResultTypes.IterationResult TrainInteraction(Train train, ValueObjects.Time time);
}
