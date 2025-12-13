using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileRenameNode<T> : CommandNode<T> where T : ICommandBuilder
{
    public string TokenName => "rename";

    public PathNode<FileRenameBuilder>? SubChain { get; set; }

    public IParseNode<T> AddSubchain(PathNode<FileRenameBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(FileRenameBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (SubChain != null) return NextSubchainParse(new FileRenameBuilder(), enumerator);
                return new ParseResultType.Success(new FileRenameBuilder());
            }
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}