using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;

public interface IParseNode
{
    ParseResultType TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator);
}