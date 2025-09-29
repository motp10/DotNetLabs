using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public record Route : IRoute
{
    public Route(IReadOnlyCollection<ITrackSection> sections, Speed maxSpeed)
    {
        MaxSpeed = maxSpeed;

        Sections = sections;
    }

    public Speed MaxSpeed { get; }

    public IReadOnlyCollection<ITrackSection> Sections { get; }
}