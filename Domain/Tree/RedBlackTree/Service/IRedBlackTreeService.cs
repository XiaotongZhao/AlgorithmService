using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public interface IRedBlackTreeService
    {
        bool InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode);
        bool DeleteRedBlackTreeNode(RedBlackTreeNode redBlackTree, int key);
    }
}