using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class ConnectNode : CommandNode
{
    private static string TokenName => "connect";

    private IArgumentNode<ConnectBuilder>? _argumentSubChain;

    public CommandNode AddArgument(IArgumentNode<ConnectBuilder>? node)
    {
        _argumentSubChain = node;
        return this;
    }

    private ParseResultType NextArgumentParse(ConnectBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (_argumentSubChain != null)
        {
            return _argumentSubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(new ConnectBuilder());
    }

    private FlagNode<ConnectBuilder>? _flagSubChain;

    public CommandNode AddFlag(FlagNode<ConnectBuilder>? node)
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
                var resultBuilder = new ConnectBuilder();
                resultBuilder.WithFileSystem(new LocalFileSystem());
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

    private ParseResultType NextFlagParse(ConnectBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (_flagSubChain != null)
        {
            return _flagSubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(new TreeListBuilder());
    }
}