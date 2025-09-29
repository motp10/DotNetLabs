using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Roads;

public interface IRoadSegment : ITrackSection
{
    Distance Length { get; }
}