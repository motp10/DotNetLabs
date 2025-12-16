using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FIleShowNode : CommandNode
{
    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                ParseResultType reult = NextArgumentParse(enumerator);
                while (true)
                {
                    NextFlagParse(enumerator);
                    if (!enumerator.MoveNext()) break;
                }

                return reult;
            }
        }

        return NextNodeParse(enumerator);
    }

    private string TokenName => "show";

    private ArgumentNode<FileShowBuilder>? _argumentSubChain;

    public CommandNode AddArgument(ArgumentNode<FileShowBuilder>? node)
    {
        _argumentSubChain = node;

        return this;
    }

    private ParseResultType NextArgumentParse(IEnumerator<string> tokens)
    {
        if (_argumentSubChain != null)
        {
            return _argumentSubChain.TryParse(new FileShowBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileShowBuilder());
    }

    private FlagNode<FileShowBuilder>? _flagSubChain;

    public CommandNode AddFlag(FlagNode<FileShowBuilder>? node)
    {
        _flagSubChain = node;

        return this;
    }

    private ParseResultType NextFlagParse(IEnumerator<string> tokens)
    {
        if (_flagSubChain != null)
        {
            return _flagSubChain.TryParse(new FileShowBuilder(), tokens);
        }

        return new ParseResultType.Success(new TreeListBuilder());
    }
}