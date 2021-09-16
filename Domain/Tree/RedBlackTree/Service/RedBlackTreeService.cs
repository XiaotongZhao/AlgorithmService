using Domain.Tree.BinaryTree.Model;
using Domain.Tree.BinaryTree.Service;
using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public class RedBlackTreeService : BinaryTreeService, IRedBlackTreeService
    {
        private bool fixRedBlackTreeAfterInsert(RedBlackTreeNode lastInsertRedBlackTreeNode)
        {
            if (!lastInsertRedBlackTreeNode.IsRoot)
            {
                var currentNode = lastInsertRedBlackTreeNode;
                var currentParentNode = lastInsertRedBlackTreeNode.RedBlackTreeParent;
                if (currentParentNode.Key == currentParentNode.RedBlackTreeLeftChildNode.Key)
                {
                    if (currentParentNode.NodeColor == Color.Red &&
                        currentParentNode.RedBlackTreeRightChildNode.NodeColor == Color.Red)
                    {
                        currentParentNode.NodeColor = Color.Black;
                        currentParentNode.RedBlackTreeRightChildNode.NodeColor = Color.Black;
                        currentNode = currentParentNode.RedBlackTreeParent;
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                lastInsertRedBlackTreeNode.NodeColor = Color.Black;
            }

            
        }

        public bool InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode)
        {
            var bianryTree = redBlackTree as BinaryTreeNode;
            var insertTreeNode = insertRedBlackTreeNode as BinaryTreeNode;
            InsertBinaryTreeNode(ref bianryTree, ref insertTreeNode);
            var res = fixRedBlackTreeAfterInsert(insertTreeNode as RedBlackTreeNode);
            return res;
        }
        

        public bool DeleteRedBlackTreeNode(RedBlackTreeNode redBlackTree, int key)
        {
            throw new System.NotImplementedException();
        }
    }
}