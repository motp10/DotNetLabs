using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface IStationSegment : ITrackSection
{
    Speed ArriveLimit { get; }

    Time BoardingAndDisembarking { get; }
}