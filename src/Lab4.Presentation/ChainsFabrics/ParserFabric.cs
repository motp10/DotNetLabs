using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers.FlagValueNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;

public class ParserFabric
{
    public SimpleParser Make()
    {
        var connectNode = new ConnectNode();
        var pathNode = new PathNode<ConnectBuilder>();
        var modeNode = new ModeNode<ConnectBuilder>();
        modeNode.AddSubchain(new ConnectModeNode<ConnectBuilder>());
        pathNode.AddNextNode(modeNode);
        connectNode.AddSubchain(pathNode);

        var disconnectNode = new DisconnectNode();

        var fileNode = new FileNode();

        var fileCopyNode = new FileCopyNode();
        var copySourcePathNode = new SourcePathNode<FileCopyBuilder>();
        copySourcePathNode.AddNextNode(new DestinationPathNode<FileCopyBuilder>());
        fileCopyNode.AddSubchain(copySourcePathNode);

        var fileMoveNode = new FileMoveNode();
        var moveSourcePathNode = new SourcePathNode<FileMoveBuilder>();
        moveSourcePathNode.AddNextNode(new DestinationPathNode<FileMoveBuilder>());
        fileMoveNode.AddSubchain(moveSourcePathNode);

        var fileDeleteNode = new FileDeleteNode();
        var deletePathNode = new PathNode<FileDeleteBuilder>();
        fileDeleteNode.AddSubchain(deletePathNode);

        var fileRenameNode = new FileRenameNode();
        var renamePathNode = new PathNode<FileRenameBuilder>();
        renamePathNode.AddNextNode(new NameNode<FileRenameBuilder>());
        fileRenameNode.AddSubchain(renamePathNode);

        var fileShowNode = new FIleShowNode();
        var showPathNode = new PathNode<FileShowBuilder>();
        var fileShowModeNode = new ModeNode<FileShowBuilder>();
        fileShowModeNode.AddSubchain(new FileShowMode<FileShowBuilder>());
        showPathNode.AddNextNode(fileShowModeNode);
        fileShowNode.AddSubchain(showPathNode);

        fileCopyNode.AddNextNode(fileMoveNode).AddNextNode(fileDeleteNode).AddNextNode(fileRenameNode).AddNextNode(fileShowNode);
        fileNode.AddSubchain(fileCopyNode);

        var treeNode = new TreeNode();
        var treeGoTo = new TreeGoToNode();
        treeGoTo.AddSubchain(new PathNode<IPathBuilder>());

        var treeList = new TreeListNode();
        var treeDepthFlag = new DepthNode<TreeListBuilder>();
        treeList.AddSubchain(treeDepthFlag);
        treeGoTo.AddNextNode(treeList);

        treeNode.AddSubchain(treeGoTo);
        FileNode root = fileNode;
        root.AddNextNode(connectNode).AddNextNode(disconnectNode).AddNextNode(treeNode);
        return new SimpleParser(root);
    }
}