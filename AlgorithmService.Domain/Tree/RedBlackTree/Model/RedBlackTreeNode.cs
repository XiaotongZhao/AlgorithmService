namespace AlgorithmService.Domain.Tree.RedBlackTree.Model;

public class RedBlackTreeNode
{
    public int Key;
    public bool IsNull;
    public Color NodeColor = Color.Red;
    public RedBlackTreeNode Parent { get; set; }

    public RedBlackTreeNode LeftChildNode { get; set; }

    public RedBlackTreeNode RightChildNode { get; set; }

    public RedBlackTreeNode GetRoot()
    {
        RedBlackTreeNode currentNode = this;
        while (currentNode != null && currentNode.Parent != null)
        {
            currentNode = currentNode.Parent;
        }
        return currentNode;
    }

    public void Transplant(RedBlackTreeNode behindChildNode)
    {
        var currentNode = this;
        if (currentNode.Parent != null)
        {
            if (currentNode.Parent.LeftChildNode.Key == currentNode.Key)
                currentNode.Parent.LeftChildNode = behindChildNode;
            else
                currentNode.Parent.RightChildNode = behindChildNode;
        }
    
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
        if (currentTreeNode.LeftChildNode == null)
        {
            currentTreeNode.LeftChildNode = new RedBlackTreeNode()
            {
                IsNull = true,
                Parent = this,
                NodeColor = Color.Black
            };
        }
        else
        {
            while (currentTreeNode.LeftChildNode != null)
            {
                currentTreeNode = currentTreeNode.LeftChildNode;
            }
        }
        return currentTreeNode;
    }
}

public enum Color
{
    Red = 3,
    Black = 0
}
