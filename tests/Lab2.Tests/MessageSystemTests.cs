using Itmo.ObjectOrientedProgramming.Lab2.Archivators;
using Itmo.ObjectOrientedProgramming.Lab2.Destinations;
using Itmo.ObjectOrientedProgramming.Lab2.Destinations.DestinationDecorators;
using Itmo.ObjectOrientedProgramming.Lab2.Destinations.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MessageSystemTests
{
    [Fact]
    public void UnreadMessageForUser()
    {
        // Arrange
        var user = new User();
        var mockMessage = new Message("sda", "sdasd", MessageImportanceLevel.High);

        // Act
        user.ReceiveMessage(mockMessage);

        // Assert
        Assert.False(user.IsMessageMarked(mockMessage));
    }

    [Fact]
    public void MarkUnreadMessage()
    {
        // Arrange
        var user = new User();
        var mockMessage = new Message("sda", "sdasd", MessageImportanceLevel.High);

        // Act
        user.ReceiveMessage(mockMessage);
        user.MarkMessage(mockMessage);

        // Assert
        Assert.True(user.IsMessageMarked(mockMessage));
    }

    [Fact]
    public void DoubleMarkMessage()
    {
        // Arrange
        var user = new User();
        var mockMessage = new Message("sda", "sdasd", MessageImportanceLevel.High);

        // Act
        user.ReceiveMessage(mockMessage);
        user.MarkMessage(mockMessage);
        MarkResult res = user.MarkMessage(mockMessage);

        // Assert
        Assert.IsType<MarkResult.Failed>(res);
    }

    [Fact]
    public void FilterMessange()
    {
        // Arrange
        IDestination mockDestination = Substitute.For<IDestination>();
        var filterDest = new FilterDecorator(mockDestination, MessageImportanceLevel.High);
        var lowMessage = new Message("ddj", "asdlkasjd", MessageImportanceLevel.Medium);

        // Act
        filterDest.Recieve(lowMessage);

        // Assert
        mockDestination.DidNotReceive().Recieve(Arg.Any<Message>());
    }

    [Fact]
    public void LoggerDecorator()
    {
        // Arrange
        ILogger moqLogger = Substitute.For<ILogger>();
        IDestination moqDestination = Substitute.For<IDestination>();
        var logDestination = new LoggerDecorator(moqDestination, moqLogger);
        var someMessage = new Message("ddj", "asdlkasjd", MessageImportanceLevel.Medium);

        // Act
        logDestination.Recieve(someMessage);

        // Assert
        moqLogger.Received().Log(Arg.Any<Message>());
    }

    [Fact]
    public void ArchivatorDestination()
    {
        // Arrange
        IArchivator moqArchivator = Substitute.For<IArchivator>();
        var archDestination = new ArchivatorDestination(moqArchivator);
        var someMessage = new Message("ddj", "asdlkasjd", MessageImportanceLevel.Medium);

        // Act
        archDestination.Recieve(someMessage);

        // Assert
        moqArchivator.Received().WriteMessage(Arg.Any<Message>());
    }

    [Fact]
    public void TwoDiffUsers()
    {
        // Arrange
        IUser moqUser = Substitute.For<IUser>();
        var dest = new UserDestination(moqUser);
        var filteredDestination = new FilterDecorator(dest, MessageImportanceLevel.High);
        var someMessage = new Message("ddj", "asdlkasjd", MessageImportanceLevel.Medium);

        // Act
        dest.Recieve(someMessage);
        filteredDestination.Recieve(someMessage);

        // Assert
        moqUser.Received(1).ReceiveMessage(someMessage);
    }
}
