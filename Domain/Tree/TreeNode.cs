using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree
{
    public class TreeNode
    {
        public bool IsRoot { get; set; }
        public int Key { get; set; }
        public BinaryTreeNode LeftChildNode { get; set; }
        public  BinaryTreeNode RightChildNode { get; set; }
        public  TreeNode Parent { get; set; }
        
        public TreeNode GetRoot()
        {
            TreeNode currentNode = this;
            while (currentNode.IsRoot == false)
            {
                currentNode = currentNode.Parent;
            }

            return currentNode;
        }
    }
}