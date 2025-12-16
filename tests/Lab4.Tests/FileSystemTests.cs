using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemTests
{
    [Fact]
    public void FileCopyTest()
    {
        // Arrange
        string s = "file copy /s /d";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        var fabric = new ParserFabric();

        // Act
        SimpleParser parser = fabric.Make();
        enumerator.MoveNext();
        ParseResultType pr = parser.Parse(enumerator);

        // Assert
        if (pr is ParseResultType.Success p)
        {
            ICommandBuilder b = p.Builder;
            if (b is FileCopyBuilder builder)
            {
                Assert.Equal("/d", builder.DestinationFile);
                Assert.Equal("/s", builder.SourceFile);
                Assert.IsType<FileCopyBuilder>(builder);
            }
        }
    }

    [Fact]
    public void FileMoveTest()
    {
        // Arrange
        string s = "file move /s /d";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        var fabric = new ParserFabric();
        SimpleParser parser = fabric.Make();
        enumerator.MoveNext();

        // Act
        ParseResultType pr = parser.Parse(enumerator);

        // Assert
        if (pr is ParseResultType.Success p)
        {
            ICommandBuilder b = p.Builder;
            if (b is FileMoveBuilder builder)
            {
                Assert.Equal("/d", builder.DestinationFile);
                Assert.Equal("/s", builder.SourceFile);
                Assert.IsType<FileMoveBuilder>(builder);
            }
        }
    }

    [Fact]
    public void FileRenameTest()
    {
        // Arrange
        string s = "file rename /p /name";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        var fabric = new ParserFabric();
        SimpleParser parser = fabric.Make();
        enumerator.MoveNext();

        // Act
        ParseResultType pr = parser.Parse(enumerator);

        // Assert
        if (pr is ParseResultType.Success p)
        {
            ICommandBuilder b = p.Builder;
            if (b is FileRenameBuilder builder)
            {
                Assert.Equal("/p", builder.Path);
                Assert.Equal("/name", builder.Name);
                Assert.IsType<FileRenameBuilder>(builder);
            }
        }
    }

    [Fact]
    public void FileDeleteNode()
    {
        // Arrange
        string s = "file delete /p";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        var fabric = new ParserFabric();
        SimpleParser parser = fabric.Make();
        enumerator.MoveNext();

        // Act
        ParseResultType pr = parser.Parse(enumerator);

        // Assert
        if (pr is ParseResultType.Success p)
        {
            ICommandBuilder b = p.Builder;
            if (b is FileDeleteBuilder builder)
            {
                Assert.Equal("/p", builder.AbsolutePath);
                Assert.IsType<FileDeleteBuilder>(builder);
            }
        }
    }

    [Fact]
    public void TreeListPatse()
    {
        // Arrange
        string s = "tree list -d 2";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        var fabric = new ParserFabric();
        SimpleParser parser = fabric.Make();
        enumerator.MoveNext();

        // Act
        ParseResultType pr = parser.Parse(enumerator);

        // Assert
        if (pr is ParseResultType.Success p)
        {
            ICommandBuilder b = p.Builder;
            Assert.IsType<TreeListBuilder>(b);
        }
    }
}