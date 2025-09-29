using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRouteSimulator
{
    ResultType Simulate(Route route, ITrain train, decimal time = 1);
}