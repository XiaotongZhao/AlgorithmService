using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode : BinaryTreeNode
    {
        public bool IsNil { get; set; }
        public Color NodeColor { get; set; }

        public RedBlackTreeNode RedBlackParent
        {
            set { this.Parent = value; }
            get => this.Parent as RedBlackTreeNode;
        }

        public RedBlackTreeNode RedBlackLeftChildNode
        {
            set => this.LeftChildNode = value;
            get
            {
                if (this.LeftChildNode == null)
                {
                    return new RedBlackTreeNode() { NodeColor = Color.Black, IsNil = true, Key = 0 };
                }
                return this.LeftChildNode as RedBlackTreeNode;
            }
        }

        public RedBlackTreeNode RedBlackRightChildNode
        {
            set => this.RightChildNode = value;
            get
            {
                if (this.RightChildNode == null)
                {
                    return new RedBlackTreeNode() { NodeColor = Color.Black, IsNil = true, Key = 0 };
                }
                return this.RightChildNode as RedBlackTreeNode;
            }
        }


        public void LeftRotate()
        {
            var currentRedBlackTreeRightChildNode = this.RedBlackRightChildNode;
            if (this.RedBlackParent.RedBlackLeftChildNode.Key == this.Key)
                this.RedBlackParent.RedBlackLeftChildNode = currentRedBlackTreeRightChildNode;
            else
                this.RedBlackParent.RightChildNode = currentRedBlackTreeRightChildNode;
            currentRedBlackTreeRightChildNode.RedBlackParent = this.RedBlackParent;
            this.RightChildNode = currentRedBlackTreeRightChildNode.RedBlackLeftChildNode;
            currentRedBlackTreeRightChildNode.RedBlackLeftChildNode.RedBlackParent = this;
            currentRedBlackTreeRightChildNode.RedBlackLeftChildNode = this;
            this.RedBlackParent = currentRedBlackTreeRightChildNode;
        }

        public void RightRotate()
        {
            var currentRedBlackTreeLeftChildNode = this.RedBlackLeftChildNode;
            if (this.RedBlackParent.RedBlackLeftChildNode.Key == this.Key)
                this.RedBlackParent.RedBlackLeftChildNode = currentRedBlackTreeLeftChildNode;
            else
                this.RedBlackParent.RedBlackRightChildNode = currentRedBlackTreeLeftChildNode;
            currentRedBlackTreeLeftChildNode.RedBlackParent = this.RedBlackParent;
            this.LeftChildNode = currentRedBlackTreeLeftChildNode.RedBlackRightChildNode;
            currentRedBlackTreeLeftChildNode.RedBlackRightChildNode.RedBlackParent = this;
            currentRedBlackTreeLeftChildNode.RedBlackRightChildNode = this;
            this.RedBlackParent = currentRedBlackTreeLeftChildNode;
        }
    }

    public enum Color
    {
        Red,
        Black
    }
}