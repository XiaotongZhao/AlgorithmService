using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBackTreeNode : BinaryTreeNode 
    {
        public Color NodeColor { get; set; } 
    }

    public enum Color
    {
        Red,
        Black
    }
}