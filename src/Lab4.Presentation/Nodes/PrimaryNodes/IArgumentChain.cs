namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;

public interface IArgumentChain : IParseNode
{
    IArgumentChain AddNextArgument(IArgumentChain node);
}