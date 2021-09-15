using Domain.Tree.BinaryTree.Model;
using Domain.Tree.BinaryTree.Service;
using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public class RedBlackTreeService : BinaryTreeService, IRedBlackTreeService
    {
        private bool fixRedBlackTreeAfterInsert(RedBlackTreeNode lastInsertRedBlackTreeNode)
        {
            return false;
        }

        public bool InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode)
        {
            var bianryTree = redBlackTree as BinaryTreeNode;
            var insertTreeNode = insertRedBlackTreeNode as BinaryTreeNode;
            InsertBinaryTreeNode(ref bianryTree, ref insertTreeNode);
            var res = fixRedBlackTreeAfterInsert(insertRedBlackTreeNode);
            return res;
        }
        

        public bool DeleteRedBlackTreeNode(RedBlackTreeNode redBlackTree, int key)
        {
            throw new System.NotImplementedException();
        }
    }
}