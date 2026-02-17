using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Roads;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void PowerSimpleSuccess()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(10000));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        var segments = new List<ITrackSection> { road1, road2 };

        var expected = new SimulatorResult.Success(new Time(2));

        var route = new Route(segments, new Speed(1000));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.Equal(expected, actual);
        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void PowerForceMoreThanMaxTrainForceFailed()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(20000));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        var segments = new List<ITrackSection> { road1, road2 };

        var route = new Route(segments, new Speed(199));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void PowerSimpleStationSuccess()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(10));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        ITrackSection road3 = new SimpleRoad(new Distance(200));

        ITrackSection station1 = new Station(new Speed(200), new Time(10));

        var segments = new List<ITrackSection> { road1, road2, station1, road3 };

        var route = new Route(segments, new Speed(1000));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void SpeedMoreTHanStationMaxSpeedFailed()
    {
        // Assert
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(20000));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        ITrackSection station1 = new Station(new Speed(200), new Time(10));

        var segments = new List<ITrackSection> { road1, station1, road2 };

        var route = new Route(segments, new Speed(100));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void SpeedLessMaxStationSpeedButMoreRoouteMaxSpeed()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(20000));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        ITrackSection station1 = new Station(new Speed(300), new Time(10));

        var segments = new List<ITrackSection> { road1, road2, station1, road2 };

        var route = new Route(segments, new Speed(100));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Asset
        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void SpeedMoreStationMaxSpeedThanLessSuccess()
    {
        // Assert
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road0 = new PowerRoad(new Distance(100), new Force(20000));

        ITrackSection road1 = new PowerRoad(new Distance(100), new Force(10000));

        ITrackSection road2 = new SimpleRoad(new Distance(100));

        ITrackSection road3 = new PowerRoad(new Distance(100), new Force(-10000));

        ITrackSection station1 = new Station(new Speed(100), new Time(10));

        var segments = new List<ITrackSection> { road0, road2, road3, station1, road2, road1, road2, road3 };

        var route = new Route(segments, new Speed(150));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Success>(actual);
    }

    [Fact]
    public void SimpleRoadFailed()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new SimpleRoad(new Distance(100));

        var segments = new List<ITrackSection> { road1 };

        var route = new Route(segments, new Speed(150));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Failed>(actual);
    }

    [Fact]
    public void ForceStopsTrain()
    {
        // Arrange
        var train = new Train(new Mass(100), new Force(100000));

        ITrackSection road1 = new PowerRoad(new Distance(200), new Force(10000));

        ITrackSection road2 = new PowerRoad(new Distance(200), new Force(-20000));

        var segments = new List<ITrackSection> { road1, road2 };

        var route = new Route(segments, new Speed(150));

        // Act
        SimulatorResult actual = route.Simulate(train, new Time(1));

        // Assert
        Assert.IsType<SimulatorResult.Failed>(actual);
    }
}