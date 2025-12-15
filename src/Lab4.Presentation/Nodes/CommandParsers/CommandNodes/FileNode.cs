using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileNode : CommandNode
{
    public string TokenName => "file";

    public CommandNode? SubChain { get; set; }

    public CommandNode AddSubchain(CommandNode? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(tokens);
        }

        return new ParseResultType.Failure();
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                return NextSubchainParse(enumerator);
            }

            return new ParseResultType.Failure();
        }

        return NextNodeParse(enumerator);
    }
}