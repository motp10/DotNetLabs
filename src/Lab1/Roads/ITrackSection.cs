using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface ITrackSection
{
    ResultTypes.ResultType TrainInteraction(ITrain train, ValueObjects.Time time);
}
