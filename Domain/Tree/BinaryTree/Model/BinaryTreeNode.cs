namespace Domain.Tree.BinaryTree.Model
{
    public class BinaryTreeNode : TreeNode
    {
        public BinaryTreeNode TreeMaximum(BinaryTreeNode treeNode)
        {
            var currentTreeNode = this;
            while (currentTreeNode.RightChildNode != null)
            {
                currentTreeNode = currentTreeNode.RightChildNode;
            }
            return currentTreeNode;
        }
        
        public BinaryTreeNode TreeMinimum()
        {
            var currentTreeNode = this;
            while (currentTreeNode.LeftChildNode != null)
            {
                currentTreeNode = currentTreeNode.LeftChildNode;
            }
            return currentTreeNode;
        }
        
    }
}