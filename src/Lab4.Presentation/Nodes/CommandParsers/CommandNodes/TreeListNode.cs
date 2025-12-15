using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class TreeListNode : CommandNode
{
    public string TokenName => "list";

    public DepthNode<TreeListBuilder>? SubChain { get; set; }

    public CommandNode AddSubchain(DepthNode<TreeListBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(new TreeListBuilder(), tokens);
        }

        return new ParseResultType.Success(new TreeListBuilder());
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (SubChain != null) return NextSubchainParse(enumerator);
                return new ParseResultType.Success(new TreeListBuilder());
            }
        }

        return NextNodeParse(enumerator);
    }
}