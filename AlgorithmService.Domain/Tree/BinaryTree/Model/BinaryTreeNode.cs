namespace AlgorithmService.Domain.Tree.BinaryTree.Model;

public class BinaryTreeNode : TreeNode
{
    public BinaryTreeNode TreeMaximum(BinaryTreeNode treeNode)
    {
        var currentTreeNode = this;
        while (currentTreeNode.RightChildNode != null)
        {
            currentTreeNode = currentTreeNode.RightChildNode;
        }
        return currentTreeNode;
    }

    public BinaryTreeNode TreeMinimum()
    {
        var currentTreeNode = this;
        while (currentTreeNode.LeftChildNode != null)
        {
            currentTreeNode = currentTreeNode.LeftChildNode;
        }
        return currentTreeNode;
    }

    public void Transplant(BinaryTreeNode behindChildNode)
    {
        var currentBinaryTreeNode = this;
        if (currentBinaryTreeNode.Parent == null)
            behindChildNode.IsRoot = true;
        else if (currentBinaryTreeNode.Parent.LeftChildNode.Key == currentBinaryTreeNode.Key)
            currentBinaryTreeNode.Parent.LeftChildNode = behindChildNode;
        else
            currentBinaryTreeNode.Parent.RightChildNode = behindChildNode;
        if (behindChildNode != null)
        {
            behindChildNode.Parent = currentBinaryTreeNode.Parent;
        }
    }
}