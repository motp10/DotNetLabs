using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class TreeListNode : CommandNode
{
    private string TokenName => "list";

    private FlagNode<TreeListBuilder>? _flagSubChain;

    public CommandNode AddFlag(FlagNode<TreeListBuilder>? node)
    {
        _flagSubChain = node;

        return this;
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                var result = new TreeListBuilder();
                while (true)
                {
                    NextFlagParse(result, enumerator);
                    if (!enumerator.MoveNext()) break;
                }

                return new ParseResultType.Success(result);
            }
        }

        return NextNodeParse(enumerator);
    }

    private ParseResultType NextFlagParse(TreeListBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (_flagSubChain != null)
        {
            return _flagSubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}