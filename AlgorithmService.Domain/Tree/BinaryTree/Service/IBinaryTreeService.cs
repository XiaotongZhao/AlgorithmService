using AlgorithmService.Domain.Tree.BinaryTree.Model;

namespace AlgorithmService.Domain.Tree.BinaryTree.Service;

public interface IBinaryTreeService
{
    BinaryTreeNode TreeSearch(BinaryTreeNode binaryTreeNode, int key);
    BinaryTreeNode IterActiveTreeSearch(BinaryTreeNode binaryTreeNode, int key);
    void InsertBinaryTreeNode(ref BinaryTreeNode tree, ref BinaryTreeNode insertNode);
    void DeleteBinaryTreeNode(BinaryTreeNode tree, int key);
    BinaryTreeNode CreateBinaryTree(int[] keys);
}