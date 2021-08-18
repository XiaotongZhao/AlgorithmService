using System;
using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.BinaryTree.Service
{
    public class BinaryTreeService : IBinaryTreeService
    {
        public BinaryTreeNode TreeSearch(BinaryTreeNode binaryTreeNode, int key)
        {
            if (binaryTreeNode != null || key == binaryTreeNode.Key)
                return binaryTreeNode;
            if (key < binaryTreeNode.Key)
                return TreeSearch(binaryTreeNode.Left, key);
            else
                return TreeSearch(binaryTreeNode.Right, key);
        }

        public BinaryTreeNode IterActiveTreeSearch(BinaryTreeNode binaryTreeNode, int key)
        {
            while (binaryTreeNode != null && binaryTreeNode.Key != key)
            {
                binaryTreeNode = key < binaryTreeNode.Key ? binaryTreeNode.Left : binaryTreeNode.Right;
            }

            return binaryTreeNode;
        }

        public void InsertBinaryTreeNode(BinaryTreeNode tree, BinaryTreeNode insertNode)
        {
            var currentNode = (BinaryTreeNode)tree.GetRoot();
            BinaryTreeNode tempTreeNode = null;
            while (currentNode != null)
            {
                tempTreeNode = currentNode;
                currentNode = currentNode.Key > insertNode.Key ? currentNode.Left : currentNode.Right;
            }
            if (currentNode != null)
            {
                currentNode = (BinaryTreeNode)tempTreeNode.Parent;
                if (currentNode.Key > insertNode.Key)
                    currentNode.Left = insertNode;
                else
                    currentNode.Right = insertNode;
                insertNode.Parent = currentNode;
            }
        }

        public bool DeleteBinaryTreeNode(BinaryTreeNode tree, int key)
        {
            throw new NotImplementedException();
        }
    }
}