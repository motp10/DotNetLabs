using Itmo.ObjectOrientedProgramming.Lab1.Roads;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRoute
{
    IReadOnlyCollection<ITrackSection> Sections { get; }
}