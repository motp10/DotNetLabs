using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;

public class ParserFabric
{
    public IParseNode Make()
    {
        var connectNode = new ConnectNode();
        connectNode.AddNextArgument(new PathNode<ConnectBuilder>());

        var disconnectNode = new DisconnectNode();

        var fileNode = new FileNode();

        var fileCopyNode = new FileCopyNode();
        fileCopyNode.AddNextArgument(new SourcePathNode<FileCopyBuilder>()).AddNextArgument(new DestinationPathNode<FileCopyBuilder>());

        var fileMoveNode = new FileMoveNode();
        fileMoveNode.AddNextArgument(new SourcePathNode<FileMoveBuilder>()).AddNextArgument(new DestinationPathNode<FileMoveBuilder>());

        var fileDeleteNode = new FileDeleteNode();
        fileDeleteNode.AddNextArgument(new PathNode<FileDeleteBuilder>());

        var fileRenameNode = new FileRenameNode();
        fileRenameNode.AddNextArgument(new PathNode<FileRenameBuilder>()).AddNextArgument(new NameNode<FileRenameBuilder>());

        var fileShowNode = new FIleShowNode();
        fileShowNode.AddNextArgument(new PathNode<FileShowBuilder>());
        fileShowNode.AddNextFlag(new ModeNode<FileShowBuilder>());

        fileCopyNode.AddNextNode(fileMoveNode).AddNextNode(fileDeleteNode).AddNextNode(fileRenameNode).AddNextNode(fileShowNode);
        fileNode.AddNextSubcommand(fileCopyNode);

        var treeNode = new TreeNode();
        var treeGoTo = new TreeGoToNode();
        treeGoTo.AddNextArgument(new PathNode<TreeGoToBuilder>());
        var treeList = new TreeListNode();
        treeList.AddNextFlag(new DepthNode<TreeListBuilder>());
        treeNode.AddNextSubcommand(treeGoTo).AddNextSubcommand(treeList);
        FileNode root = fileNode;
        root.AddNextNode(connectNode).AddNextNode(disconnectNode).AddNextNode(treeNode);
        return root;
    }
}