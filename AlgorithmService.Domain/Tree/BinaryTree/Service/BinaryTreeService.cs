using AlgorithmService.Domain.Tree.BinaryTree.Model;

namespace AlgorithmService.Domain.Tree.BinaryTree.Service;

public class BinaryTreeService : IBinaryTreeService
{
    public BinaryTreeNode TreeSearch(BinaryTreeNode binaryTreeNode, int key)
    {
        var currentKey = binaryTreeNode.Key;
        if (key == currentKey)
            return binaryTreeNode;
        else if (key < currentKey)
            return TreeSearch(binaryTreeNode.LeftChildNode, key);
        else
            return TreeSearch(binaryTreeNode.RightChildNode, key);
    }

    public BinaryTreeNode IterActiveTreeSearch(BinaryTreeNode binaryTreeNode, int key)
    {
        while (binaryTreeNode != null && binaryTreeNode.Key != key)
        {
            binaryTreeNode = key < binaryTreeNode.Key
                ? binaryTreeNode.LeftChildNode
                : binaryTreeNode.RightChildNode;
        }

        return binaryTreeNode;
    }

    public void DeleteBinaryTreeNode(BinaryTreeNode tree, int key)
    {
        var deleteBinaryTreeNode = TreeSearch(tree, key);
        if (deleteBinaryTreeNode.LeftChildNode == null)
            deleteBinaryTreeNode.Transplant(deleteBinaryTreeNode.RightChildNode);
        else if (deleteBinaryTreeNode.RightChildNode == null)
            deleteBinaryTreeNode.Transplant(deleteBinaryTreeNode.LeftChildNode);
        else
        {
            var behindChildNode = deleteBinaryTreeNode.RightChildNode.TreeMinimum();
            if (behindChildNode.Parent.Key != deleteBinaryTreeNode.Key)
            {
                behindChildNode.Transplant(behindChildNode.RightChildNode);
                behindChildNode.RightChildNode = deleteBinaryTreeNode.RightChildNode;
                behindChildNode.RightChildNode.Parent = behindChildNode;
            }

            deleteBinaryTreeNode.Transplant(behindChildNode);
            behindChildNode.LeftChildNode = deleteBinaryTreeNode.LeftChildNode;
            behindChildNode.LeftChildNode.Parent = behindChildNode;
        }
    }

    public void InsertBinaryTreeNode(ref BinaryTreeNode tree, ref BinaryTreeNode insertNode)
    {
        if (tree == null)
        {
            insertNode.IsRoot = true;
            tree = insertNode;
        }
        else
        {
            var currentNode = (BinaryTreeNode)tree.GetRoot();
            BinaryTreeNode tempTreeNode = null;
            while (currentNode != null)
            {
                tempTreeNode = currentNode;
                currentNode = currentNode.Key > insertNode.Key
                    ? currentNode.LeftChildNode
                    : currentNode.RightChildNode;
            }

            if (tempTreeNode != null)
            {
                currentNode = tempTreeNode;
                if (currentNode.Key > insertNode.Key)
                    currentNode.LeftChildNode = insertNode;
                else
                    currentNode.RightChildNode = insertNode;
                insertNode.Parent = currentNode;
            }
        }
    }

    public BinaryTreeNode CreateBinaryTree(int[] keys)
    {
        BinaryTreeNode tree = null;
        for (int i = 0; i < keys.Length; i++)
        {
            var binaryNode = new BinaryTreeNode()
            {
                Key = keys[i]
            };
            InsertBinaryTreeNode(ref tree, ref binaryNode);
        }

        return tree;
    }
}