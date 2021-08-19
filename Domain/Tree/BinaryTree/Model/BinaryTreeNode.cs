namespace Domain.Tree.BinaryTree.Model
{
    public abstract class BinaryTreeNode : TreeNode
    {
        public BinaryTreeNode TreeMaximum(BinaryTreeNode treeNode)
        {
            var currentTreeNode = this;
            while (currentTreeNode.Right != null)
            {
                currentTreeNode = currentTreeNode.Right;
            }
            return currentTreeNode;
        }

        public BinaryTreeNode TreeMinimum()
        {
            var currentTreeNode = this;
            while (currentTreeNode.Left != null)
            {
                currentTreeNode = currentTreeNode.Left;
            }
            return currentTreeNode;
        }
        
    }
}