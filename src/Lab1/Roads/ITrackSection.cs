using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface ITrackSection
{
    IterationResult TrainInteraction(Train train, ValueObjects.Time interval);
}
