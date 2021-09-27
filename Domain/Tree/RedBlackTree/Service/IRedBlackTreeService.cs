using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public interface IRedBlackTreeService
    {
        void InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode);
        void DeleteRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, int key);
        RedBlackTreeNode CreateRedBlackTree(int[] keys);
    }
}