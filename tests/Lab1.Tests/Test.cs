using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Fact]
    public void Script1()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(100, 10000);
        ITrackSection road2 = new SimpleRoad(100);
        var segments = new List<ITrackSection> { road1, road2 };

        var expected = new SimulatorResult.Success(new Time(2));
        var route = new Route(segments, new Speed(1000));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.Equal(expected, actual);
        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void Script2()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(100, 20000);
        ITrackSection road2 = new SimpleRoad(100);
        var segments = new List<ITrackSection> { road1, road2 };

        var route = new Route(segments, new Speed(199));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void Script3()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(100, 10);
        ITrackSection road2 = new SimpleRoad(100);
        ITrackSection road3 = new SimpleRoad(200);
        ITrackSection station1 = new Station(200, 10);
        var segments = new List<ITrackSection> { road1, road2, station1, road3 };

        var route = new Route(segments, new Speed(1000));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void Script4()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(100, 20000);
        ITrackSection road2 = new SimpleRoad(100);
        ITrackSection station1 = new Station(200, 10);
        var segments = new List<ITrackSection> { road1, station1, road2 };

        var route = new Route(segments, new Speed(100));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void Script5()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(100, 20000);
        ITrackSection road2 = new SimpleRoad(100);
        ITrackSection station1 = new Station(300, 10);
        var segments = new List<ITrackSection> { road1, road2, station1, road2 };

        var route = new Route(segments, new Speed(100));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void Script6()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road0 = new PowerRoad(100, 20000);
        ITrackSection road1 = new PowerRoad(100, 10000);
        ITrackSection road2 = new SimpleRoad(100);
        ITrackSection road3 = new PowerRoad(100, -10000);
        ITrackSection station1 = new Station(100, 10);
        var segments = new List<ITrackSection> { road0, road2, road3, station1, road2, road1, road2, road3 };

        var route = new Route(segments, new Speed(150));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));
        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void Script7()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new SimpleRoad(100);
        var segments = new List<ITrackSection> { road1 };

        var route = new Route(segments, new Speed(150));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void Script8()
    {
        var train = new Train(new Mass(100), new Force(100000));
        ITrackSection road1 = new PowerRoad(200, 10000);
        ITrackSection road2 = new PowerRoad(200, -20000);

        var segments = new List<ITrackSection> { road1, road2 };

        var route = new Route(segments, new Speed(150));
        SimulatorResult actual = new RouteSimulator().Simulate(route, train, new Time(1));

        Assert.IsType<SimulatorResult.Failed>(actual);
    }
}