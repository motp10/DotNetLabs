using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;

public class SimpleParser
{
    private readonly CommandNode _root;

    public SimpleParser(CommandNode root)
    {
        _root = root;
    }

    public ParseResultType Parse(IEnumerator<string> iterator)
    {
        return _root.TryParse(iterator);
    }
}