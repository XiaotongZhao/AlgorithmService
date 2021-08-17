using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree
{
    public class TreeNode
    {
        public bool IsRoot { get; set; }
        public int Key { get; set; }
        public BinaryTreeNode Left { get; set; }
        public  BinaryTreeNode Right { get; set; }
        public  TreeNode Parent { get; set; }
    }
}