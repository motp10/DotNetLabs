using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class TreeListNode<T> : CommandNode<T> where T : ICommandBuilder
{
    public string TokenName => "list";

    public DepthNode<TreeListBuilder>? SubChain { get; set; }

    public IParseNode<T> AddSubchain(DepthNode<TreeListBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(TreeListBuilder commandBuilder, IEnumerator<string> tokens)
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
                if (SubChain != null) return NextSubchainParse(new TreeListBuilder(), enumerator);
                return new ParseResultType.Success(new TreeListBuilder());
            }
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}