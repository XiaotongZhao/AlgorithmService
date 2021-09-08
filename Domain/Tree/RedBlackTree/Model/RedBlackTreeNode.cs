using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode : BinaryTreeNode 
    {
        public Color NodeColor { get; set; } 
    }

    public enum Color
    {
        Red,
        Black
    }
}