using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;

public class SimpleParser
{
    private readonly IParseNode<ICommandBuilder> _root;

    public SimpleParser(IParseNode<ICommandBuilder> root)
    {
        _root = root;
    }

    public ParseResultType Parse(IEnumerator<string> iterator)
    {
        return _root.TryParse(new EmptyBuilder(), iterator);
    }
}