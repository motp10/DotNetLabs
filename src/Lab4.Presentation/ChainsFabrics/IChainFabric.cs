using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;

public interface IChainFabric
{
    IParseNode<ICommandBuilder> Make();
}