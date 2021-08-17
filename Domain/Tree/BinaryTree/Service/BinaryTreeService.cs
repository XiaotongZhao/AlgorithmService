using System;
using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.BinaryTree.Service
{
    public class BinaryTreeService:IBinaryTreeService
    {
        public string InorderTreeWalk(BinaryTreeNode binaryTreeNode)
        {
            throw new System.NotImplementedException();
        }

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

        public void TreeInsert(BinaryTreeNode binaryTreeNode)
        {
            throw new System.NotImplementedException();
        }
    }
}