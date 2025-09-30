using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface ITrackSection
{
    ResultTypes.ResultType TrainInteraction(Train train, ValueObjects.Time time);
}
