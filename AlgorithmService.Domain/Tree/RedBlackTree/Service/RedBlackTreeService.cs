using AlgorithmService.Domain.Tree.RedBlackTree.Model;

namespace AlgorithmService.Domain.Tree.RedBlackTree.Service;

public class RedBlackTreeService : IRedBlackTreeService
{
    public RedBlackTreeNode CreateRedBlackTree(int[] keys)
    {
        RedBlackTreeNode redBlackTree = null;
        foreach (var key in keys)
        {
            var redBlackTreeNode = new RedBlackTreeNode()
            {
                Key = key                
            };
            redBlackTreeNode.LeftChildNode = new RedBlackTreeNode()
            {
                IsNull = true,
                Parent = redBlackTreeNode,
                NodeColor = Color.Black
            };
            redBlackTreeNode.RightChildNode = new RedBlackTreeNode()
            {
                IsNull = true,
                Parent = redBlackTreeNode,
                NodeColor = Color.Black
            };
            InsertRedBlackTreeNode(ref redBlackTree, redBlackTreeNode);
        }

        return redBlackTree;
    }

    private RedBlackTreeNode fixRedBlackTreeAfterInsert(RedBlackTreeNode insertTreeNode)
    {
        var currentNode = insertTreeNode;
        while (currentNode.Parent?.NodeColor == Color.Red)
        {
            if (currentNode.Parent.Key ==
                currentNode.Parent.Parent.RightChildNode.Key)
            {
                var uncleParentNode = currentNode.Parent.Parent.LeftChildNode;
                if (uncleParentNode.NodeColor == Color.Red)
                {
                    currentNode.Parent.NodeColor = Color.Black;
                    uncleParentNode.NodeColor = Color.Black;
                    currentNode.Parent.Parent.NodeColor = Color.Red;
                    currentNode = currentNode.Parent.Parent;
                }
                else
                {
                    if (currentNode.Key == currentNode.Parent.LeftChildNode.Key)
                    {
                        currentNode = currentNode.Parent;
                        currentNode.RightRotate();
                    }

                    currentNode.Parent.NodeColor = Color.Black;
                    currentNode.Parent.Parent.NodeColor = Color.Red;
                    currentNode.Parent.Parent.LeftRotate();
                }
            }
            else if (currentNode.Parent.Key ==
                     currentNode.Parent.Parent.LeftChildNode.Key)
            {
                var uncleParentNode = currentNode.Parent.Parent.RightChildNode;
                if (uncleParentNode.NodeColor == Color.Red)
                {
                    currentNode.Parent.NodeColor = Color.Black;
                    uncleParentNode.NodeColor = Color.Black;
                    currentNode.Parent.Parent.NodeColor = Color.Red;
                    currentNode = currentNode.Parent.Parent;
                }
                else
                {
                    if (currentNode.Key == currentNode.Parent.RightChildNode.Key)
                    {
                        currentNode = currentNode.Parent;
                        currentNode.LeftRotate();
                    }

                    currentNode.Parent.NodeColor = Color.Black;
                    currentNode.Parent.Parent.NodeColor = Color.Red;
                    currentNode.Parent.Parent.RightRotate();
                }
            }
        }

        var root = currentNode.GetRoot() as RedBlackTreeNode;
        if (root != null)
            root.NodeColor = Color.Black;
        return root;
    }

    public void InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode)
    {
        if (redBlackTree == null)
        {
            insertRedBlackTreeNode.IsRoot = true;
            redBlackTree = insertRedBlackTreeNode;
        }
        else
        {
            var currentNode = (RedBlackTreeNode)redBlackTree.GetRoot();
            RedBlackTreeNode tempTreeNode = null;
            while (!currentNode.IsNull)
            {
                tempTreeNode = currentNode;
                currentNode = currentNode.Key > insertRedBlackTreeNode.Key
                    ? currentNode.LeftChildNode
                    : currentNode.RightChildNode;
            }

            if (tempTreeNode != null)
            {
                currentNode = tempTreeNode;
                if (currentNode.Key > insertRedBlackTreeNode.Key)
                    currentNode.LeftChildNode = insertRedBlackTreeNode;
                else
                    currentNode.RightChildNode = insertRedBlackTreeNode;
                insertRedBlackTreeNode.Parent = currentNode;
            }
        }
        redBlackTree = fixRedBlackTreeAfterInsert(insertRedBlackTreeNode);
    }

    private RedBlackTreeNode fixRedBlackTreeAfterDelete(RedBlackTreeNode xPoint)
    {
        while (!xPoint.IsRoot & xPoint.NodeColor == Color.Black)
        {
            if (xPoint.Parent.LeftChildNode.Key == xPoint.Key)
            {
                var wPoint = xPoint.Parent.RightChildNode;
                if (xPoint.NodeColor == Color.Black && wPoint.NodeColor == Color.Red)
                {
                    wPoint.NodeColor = Color.Black;
                    wPoint.Parent.NodeColor = Color.Red;
                    wPoint.Parent.LeftRotate();
                    wPoint = xPoint.Parent.RightChildNode;
                }

                if (wPoint.NodeColor == Color.Black && wPoint.LeftChildNode.NodeColor == Color.Black &&
                    wPoint.RightChildNode.NodeColor == Color.Black)
                {
                    wPoint.NodeColor = Color.Red;
                    xPoint = xPoint.Parent;
                }
                else
                {
                    if (wPoint.LeftChildNode.NodeColor == Color.Red &&
                        wPoint.RightChildNode.NodeColor == Color.Black)
                    {
                        wPoint.NodeColor = Color.Red;
                        wPoint.LeftChildNode.NodeColor = Color.Black;
                        wPoint.RightRotate();
                        wPoint = wPoint.Parent;
                    }

                    if (wPoint.NodeColor == Color.Black && wPoint.RightChildNode.NodeColor == Color.Red)
                    {
                        wPoint.NodeColor = xPoint.Parent.NodeColor;
                        xPoint.Parent.NodeColor = Color.Black;
                        wPoint.RightChildNode.NodeColor = Color.Black;
                        wPoint.Parent.LeftRotate();
                        xPoint = xPoint.GetRoot();
                    }
                }
            }
            else if (xPoint.Parent.RightChildNode.Key == xPoint.Key)
            {
                var wPoint = xPoint.Parent.LeftChildNode;
                if (xPoint.NodeColor == Color.Black && wPoint.NodeColor == Color.Red)
                {
                    wPoint.NodeColor = Color.Black;
                    wPoint.Parent.NodeColor = Color.Red;
                    wPoint.Parent.RightRotate();
                    wPoint = xPoint.Parent.LeftChildNode;
                }

                if (wPoint.NodeColor == Color.Black && wPoint.LeftChildNode.NodeColor == Color.Black &&
                    wPoint.RightChildNode.NodeColor == Color.Black)
                {
                    wPoint.NodeColor = Color.Red;
                    xPoint = xPoint.Parent;
                }
                else
                {
                    if (wPoint.RightChildNode.NodeColor == Color.Red &&
                        wPoint.LeftChildNode.NodeColor == Color.Black)
                    {
                        wPoint.NodeColor = Color.Red;
                        wPoint.RightChildNode.NodeColor = Color.Black;
                        wPoint.LeftRotate();
                        wPoint = wPoint.Parent;
                    }

                    if (wPoint.NodeColor == Color.Black && wPoint.LeftChildNode.NodeColor == Color.Red)
                    {
                        wPoint.NodeColor = xPoint.Parent.NodeColor;
                        xPoint.Parent.NodeColor = Color.Black;
                        wPoint.LeftChildNode.NodeColor = Color.Black;
                        wPoint.Parent.RightRotate();
                        xPoint = xPoint.GetRoot();
                    }
                }
            }

        }

        xPoint.NodeColor = Color.Black;
        var root = xPoint.GetRoot();
        return root;
    }

    private RedBlackTreeNode treeSearch(RedBlackTreeNode redBlackTreeNode, int key)
    {
        var currentKey = redBlackTreeNode.Key;
        if (key == currentKey)
            return redBlackTreeNode;
        else if (key < currentKey)
            return treeSearch(redBlackTreeNode.LeftChildNode, key);
        else
            return treeSearch(redBlackTreeNode.RightChildNode, key);
    }

    public void DeleteRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, int key)
    {
        var deletedTreeNode = treeSearch(redBlackTree, key);
        var originalColor = deletedTreeNode.NodeColor;
        RedBlackTreeNode xPoint;
        if (deletedTreeNode.LeftChildNode.IsNull)
        {
            xPoint = deletedTreeNode.RightChildNode;
            deletedTreeNode.Transplant(deletedTreeNode.RightChildNode);
        }
        else if (deletedTreeNode.RightChildNode.IsNull)
        {
            xPoint = deletedTreeNode.LeftChildNode;
            deletedTreeNode.Transplant(deletedTreeNode.LeftChildNode);
        }
        else
        {
            var behindChildNode = deletedTreeNode.RightChildNode.TreeMinimum() as RedBlackTreeNode;
            originalColor = behindChildNode.NodeColor;
            xPoint = behindChildNode.RightChildNode;
            if (behindChildNode.Parent.Key != deletedTreeNode.Key)
            {
                behindChildNode.Transplant(behindChildNode.RightChildNode);
                behindChildNode.RightChildNode = deletedTreeNode.RightChildNode;
                behindChildNode.RightChildNode.Parent = behindChildNode;
            }

            deletedTreeNode.Transplant(behindChildNode);
            behindChildNode.LeftChildNode = deletedTreeNode.LeftChildNode;
            behindChildNode.LeftChildNode.Parent = behindChildNode;
        }

        if (originalColor == Color.Black)
        {
            redBlackTree = fixRedBlackTreeAfterDelete(xPoint);
        }
    }
}