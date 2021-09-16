using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode : BinaryTreeNode
    {
        public Color NodeColor { get; set; }

        public RedBlackTreeNode RedBlackTreeParent
        {
            set { this.Parent = value; }
            get => this.Parent as RedBlackTreeNode;
        }

        public RedBlackTreeNode RedBlackTreeLeftChildNode
        {
            set { this.Parent = value; }
            get => this.Parent as RedBlackTreeNode;
        }
        public RedBlackTreeNode RedBlackTreeRightChildNode
        {
            set { this.Parent = value; }
            get => this.Parent as RedBlackTreeNode;
        }


        public void LeftRotate()
        {
            var currentRedBlackTreeRightChildNode = this.RedBlackTreeRightChildNode;
            if (this.RedBlackTreeParent.RedBlackTreeLeftChildNode.Key == this.Key)
                this.RedBlackTreeParent.RedBlackTreeLeftChildNode = currentRedBlackTreeRightChildNode;
            else
                this.RedBlackTreeParent.RightChildNode = currentRedBlackTreeRightChildNode;
            currentRedBlackTreeRightChildNode.RedBlackTreeParent = this.RedBlackTreeParent;

            this.RightChildNode = currentRedBlackTreeRightChildNode.RedBlackTreeLeftChildNode;
            currentRedBlackTreeRightChildNode.RedBlackTreeLeftChildNode.RedBlackTreeParent = this;

            currentRedBlackTreeRightChildNode.RedBlackTreeLeftChildNode = this;
            this.RedBlackTreeParent = currentRedBlackTreeRightChildNode;
        }

        public void RightRotate()
        {
            var currentRedBlackTreeLeftChildNode = this.RedBlackTreeLeftChildNode;
            if (this.RedBlackTreeParent.RedBlackTreeLeftChildNode.Key == this.Key)
                this.RedBlackTreeParent.RedBlackTreeLeftChildNode = currentRedBlackTreeLeftChildNode;
            else
                this.RedBlackTreeParent.RedBlackTreeRightChildNode = currentRedBlackTreeLeftChildNode;
            currentRedBlackTreeLeftChildNode.RedBlackTreeParent = this.RedBlackTreeParent;

            this.LeftChildNode = currentRedBlackTreeLeftChildNode.RedBlackTreeRightChildNode;
            currentRedBlackTreeLeftChildNode.RedBlackTreeRightChildNode.RedBlackTreeParent = this;

            currentRedBlackTreeLeftChildNode.RedBlackTreeRightChildNode = this;
            this.RedBlackTreeParent = currentRedBlackTreeLeftChildNode;
        }
    }

    public enum Color
    {
        Red,
        Black
    }
}