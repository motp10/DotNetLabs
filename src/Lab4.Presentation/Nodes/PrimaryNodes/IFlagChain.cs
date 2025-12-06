namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;

public interface IFlagChain : IParseNode
{
    IFlagChain AddNextFlag(IFlagChain node);
}