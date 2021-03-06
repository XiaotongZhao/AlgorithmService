using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode
    {
        public int Key;
        public bool IsRoot;
        public bool IsNull;
        public Color NodeColor = Color.Red;
        public RedBlackTreeNode Parent;

        private RedBlackTreeNode leftChildNode;
        private RedBlackTreeNode rightChildNode;


        public RedBlackTreeNode LeftChildNode
        {
            set => leftChildNode = value;
            get =>
                leftChildNode ?? (leftChildNode = new RedBlackTreeNode()
                {
                    IsNull = true,
                    Parent = this,
                    leftChildNode = null,
                    rightChildNode = null,
                    NodeColor = Color.Black
                });
        }

        public RedBlackTreeNode RightChildNode
        {
            set => rightChildNode = value;
            get =>
                rightChildNode ?? (rightChildNode = new RedBlackTreeNode()
                {
                    IsNull = true,
                    Parent = this,
                    leftChildNode = null,
                    rightChildNode = null,
                    NodeColor = Color.Black
                });
        }

        public RedBlackTreeNode GetRoot()
        {
            RedBlackTreeNode currentNode = this;
            if (currentNode.Parent == null)
            {
                currentNode.IsRoot = true;
            }

            while (currentNode != null && currentNode.IsRoot == false)
            {
                currentNode = currentNode.Parent;
            }

            return currentNode;
        }

        public void Transplant(RedBlackTreeNode behindChildNode)
        {
            var currentNode = this;
            if (currentNode.Parent == null)
                behindChildNode.IsRoot = true;
            else if (currentNode.Parent.LeftChildNode.Key == currentNode.Key)
                currentNode.Parent.LeftChildNode = behindChildNode;
            else
                currentNode.Parent.RightChildNode = behindChildNode;
            if (behindChildNode != null)
            {
                behindChildNode.Parent = currentNode.Parent;
            }
        }

        public void LeftRotate()
        {
            var currentRightChildNode = this.RightChildNode;
            if (this.Parent == null)
            {
                currentRightChildNode.IsRoot = true;
                currentRightChildNode.Parent = null;
            }
            else if (this.Parent.LeftChildNode.Key == this.Key)
                this.Parent.LeftChildNode = currentRightChildNode;
            else
                this.Parent.RightChildNode = currentRightChildNode;

            currentRightChildNode.Parent = this.Parent;
            this.RightChildNode = currentRightChildNode.LeftChildNode;
            currentRightChildNode.LeftChildNode.Parent = this;
            currentRightChildNode.LeftChildNode = this;
            this.Parent = currentRightChildNode;
        }

        public void RightRotate()
        {
            var currentLeftChildNode = this.LeftChildNode;
            if (this.Parent == null)
            {
                currentLeftChildNode.IsRoot = true;
                currentLeftChildNode.Parent = null;
            }
            else if (this.Parent.LeftChildNode.Key == this.Key)
                this.Parent.LeftChildNode = currentLeftChildNode;
            else
                this.Parent.RightChildNode = currentLeftChildNode;

            currentLeftChildNode.Parent = this.Parent;
            this.LeftChildNode = currentLeftChildNode.RightChildNode;
            currentLeftChildNode.RightChildNode.Parent = this;
            currentLeftChildNode.RightChildNode = this;
            this.Parent = currentLeftChildNode;
        }

        public RedBlackTreeNode TreeMinimum()
        {
            var currentTreeNode = this;
            if (currentTreeNode.leftChildNode == null)
            {
                currentTreeNode = currentTreeNode.LeftChildNode;
            }
            else
            {
                while (currentTreeNode.leftChildNode != null)
                {
                    currentTreeNode = currentTreeNode.leftChildNode;
                }
            }
            return currentTreeNode;
        }
    }

    public enum Color
    {
        Red,
        Black
    }
}