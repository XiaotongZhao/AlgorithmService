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

        public void InsertBinaryTreeNode(BinaryTreeNode tree, BinaryTreeNode insertNode)
        {
            var currentNode = (BinaryTreeNode)tree.GetRoot();
            BinaryTreeNode tempTreeNode = null;
            while (currentNode != null)
            {
                tempTreeNode = currentNode;
                currentNode = currentNode.Key > insertNode.Key ? currentNode.LeftChildNode : currentNode.RightChildNode;
            }

            if (currentNode != null)
            {
                currentNode = (BinaryTreeNode)tempTreeNode.Parent;
                if (currentNode.Key > insertNode.Key)
                    currentNode.LeftChildNode = insertNode;
                else
                    currentNode.RightChildNode = insertNode;
                insertNode.Parent = currentNode;
            }
        }

        private void transplant(BinaryTreeNode deleteBinaryTreeNode, BinaryTreeNode childNode)
        {
            if (deleteBinaryTreeNode.Parent == null)
                childNode.IsRoot = true;
            else if (deleteBinaryTreeNode.Parent.LeftChildNode.Key == deleteBinaryTreeNode.Key)
                deleteBinaryTreeNode.Parent.LeftChildNode = childNode;
            else
                deleteBinaryTreeNode.Parent.RightChildNode = childNode;
            if (childNode != null)
                childNode.Parent = deleteBinaryTreeNode.Parent;
        }

        public bool DeleteBinaryTreeNode(BinaryTreeNode tree, int key)
        {
            var deleteBinaryTreeNode = TreeSearch(tree, key);
            if (deleteBinaryTreeNode.LeftChildNode == null)
                transplant(deleteBinaryTreeNode, deleteBinaryTreeNode.RightChildNode);
            else if (deleteBinaryTreeNode.RightChildNode == null)
                transplant(deleteBinaryTreeNode, deleteBinaryTreeNode.LeftChildNode);
            else
            {
                var behindChildNode = deleteBinaryTreeNode.RightChildNode.TreeMinimum();
                transplant(deleteBinaryTreeNode, behindChildNode);
                if (behindChildNode.RightChildNode != null)
                {
                    var behindChildNodeOfRightChild = behindChildNode.RightChildNode;
                    behindChildNode.Parent.LeftChildNode = behindChildNodeOfRightChild;
                    behindChildNodeOfRightChild.Parent = behindChildNode.Parent;
                }
            }
            return true;
        }

        public BinaryTreeNode CreateBinaryTree(int[] keys)
        {
            throw new NotImplementedException();
        }
    }
}