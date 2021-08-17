using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.BinaryTree.Service
{
    public interface IBinaryTreeService
    {
        BinaryTreeNode TreeSearch(BinaryTreeNode binaryTreeNode, int key);
        BinaryTreeNode IterActiveTreeSearch(BinaryTreeNode binaryTreeNode, int key);
        void TreeInsert(BinaryTreeNode binaryTree, BinaryTreeNode insertNode);
    }
}