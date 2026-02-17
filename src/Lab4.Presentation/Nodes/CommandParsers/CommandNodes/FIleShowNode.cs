using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FIleShowNode : CommandNode
{
    private string TokenName => "show";

    private ArgumentNode<FileShowBuilder>? _argumentSubChain;

    public CommandNode AddArgument(ArgumentNode<FileShowBuilder>? node)
    {
        _argumentSubChain = node;

        return this;
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                var resultBuilder = new FileShowBuilder();
                resultBuilder.WithWriter(new ConsoleWriter());

                NextArgumentParse(resultBuilder, enumerator);
                ParseResultType resultType = new ParseResultType.Success(resultBuilder);
                while (true)
                {
                    resultType = NextFlagParse(resultBuilder, enumerator);
                    if (resultType is ParseResultType.Failure) return resultType;
                    if (!enumerator.MoveNext()) break;
                }

                return new ParseResultType.Success(resultBuilder);
            }
        }

        return NextNodeParse(enumerator);
    }

    private ParseResultType NextArgumentParse(FileShowBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (_argumentSubChain != null)
        {
            return _argumentSubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    private FlagNode<FileShowBuilder>? _flagSubChain;

    public CommandNode AddFlag(FlagNode<FileShowBuilder>? node)
    {
        _flagSubChain = node;

        return this;
    }

    private ParseResultType NextFlagParse(FileShowBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (_flagSubChain != null)
        {
            return _flagSubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}