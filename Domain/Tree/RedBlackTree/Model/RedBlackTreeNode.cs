using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode : BinaryTreeNode
    {
        public Color NodeColor { get; set; }

        public void LeftRotate()
        {
            var currentRightChild = this.RightChildNode;
            this.RightChildNode = currentRightChild.LeftChildNode;
            if (currentRightChild.LeftChildNode != null)
                currentRightChild.LeftChildNode.Parent = this;
            currentRightChild.Parent = this.Parent;
            if (currentRightChild.Parent == null)
                currentRightChild.IsRoot = true;
            else if (currentRightChild.Parent.LeftChildNode.Key == this.Key)
                currentRightChild.Parent.LeftChildNode = currentRightChild;
            else
                currentRightChild.Parent.RightChildNode = currentRightChild;
            currentRightChild.LeftChildNode = this;
        }

        public void RightRotate()
        {
            var currentNode = this.Parent;
            var currentLeftChild = currentNode.LeftChildNode;
            currentNode.LeftChildNode = currentLeftChild.RightChildNode;
            if (currentLeftChild.RightChildNode != null)
                currentLeftChild.RightChildNode.Parent = currentNode;
            this.Parent = currentNode.Parent;
            if (this.Parent == null)
                this.IsRoot = true;
            else if (this.Parent.LeftChildNode.Key == currentNode.Key)
                this.Parent.LeftChildNode = this;
            else
                this.Parent.RightChildNode = this;
            this.RightChildNode = currentNode as BinaryTreeNode;
        }
    }

    public enum Color
    {
        Red,
        Black
    }
}