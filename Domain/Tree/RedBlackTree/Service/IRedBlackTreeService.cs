using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public interface IRedBlackTreeService
    {
        bool InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode);
        void DeleteRedBlackTreeNode(RedBlackTreeNode redBlackTree, int key);
    }
}