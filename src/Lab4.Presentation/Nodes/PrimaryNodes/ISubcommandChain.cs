namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;

public interface ISubcommandChain : IParseNode
{
    ISubcommandChain AddNextSubcommand(ISubcommandChain node);
}