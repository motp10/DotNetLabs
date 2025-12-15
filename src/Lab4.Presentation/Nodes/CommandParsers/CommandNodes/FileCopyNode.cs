using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileCopyNode : CommandNode
{
    public string TokenName => "copy";

    public SourcePathNode<FileCopyBuilder>? SubChain { get; set; }

    public CommandNode AddSubchain(SourcePathNode<FileCopyBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(new FileCopyBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileCopyBuilder());
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                return NextSubchainParse(enumerator);
            }
        }

        return NextNodeParse(enumerator);
    }
}