using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.RedBlackTree.Model
{
    public class RedBlackTreeNode
    {
        public int Key;
        public bool IsNil;
        public bool IsRoot;
        public Color NodeColor = Color.Red;

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


        public RedBlackTreeNode Parent;

        public RedBlackTreeNode LeftChildNode
        {
            set => this.LeftChildNode = value;
            get
            {
                if (this.LeftChildNode == null)
                {
                    return new RedBlackTreeNode() { NodeColor = Color.Black, IsNil = true, Key = 0 };
                }
                return this.LeftChildNode;
            }
        }

        public RedBlackTreeNode RightChildNode
        {
            set => this.RightChildNode = value;
            get
            {
                if (this.RightChildNode == null)
                {
                    return new RedBlackTreeNode() { NodeColor = Color.Black, IsNil = true, Key = 0 };
                }
                return this.RightChildNode;
            }
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
            var currentTRightChildNode = this.RightChildNode;
            if (this.Parent.LeftChildNode.Key == this.Key)
                this.Parent.LeftChildNode = currentTRightChildNode;
            else
                this.Parent.RightChildNode = currentTRightChildNode;
            currentTRightChildNode.Parent = this.Parent;
            this.RightChildNode = currentTRightChildNode.LeftChildNode;
            currentTRightChildNode.LeftChildNode.Parent = this;
            currentTRightChildNode.LeftChildNode = this;
            this.Parent = currentTRightChildNode;
        }

        public void RightRotate()
        {
            var currentLeftChildNode = this.LeftChildNode;
            if (this.Parent.LeftChildNode.Key == this.Key)
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
            while (currentTreeNode.LeftChildNode != null)
            {
                currentTreeNode = currentTreeNode.LeftChildNode;
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