using Domain.Tree.BinaryTree.Model;
using Domain.Tree.BinaryTree.Service;
using Domain.Tree.RedBlackTree.Model;

namespace Domain.Tree.RedBlackTree.Service
{
    public class RedBlackTreeService : BinaryTreeService, IRedBlackTreeService
    {
        private RedBlackTreeNode fixRedBlackTreeAfterInsert(RedBlackTreeNode insertTreeNode)
        {
            var currentNode = insertTreeNode;
            while (insertTreeNode.RedBlackParent?.NodeColor == Color.Red)
            {
                if (insertTreeNode.RedBlackParent.Key ==
                    insertTreeNode.RedBlackParent.RedBlackParent.RightChildNode.Key)
                {
                    var uncleParentNode = insertTreeNode.RedBlackParent.RedBlackParent.RedBlackLeftChildNode;
                    if (uncleParentNode.NodeColor == Color.Red)
                    {
                        insertTreeNode.RedBlackParent.NodeColor = Color.Black;
                        uncleParentNode.NodeColor = Color.Black;
                        currentNode.RedBlackParent.RedBlackParent.NodeColor = Color.Red;
                        currentNode = currentNode.RedBlackParent.RedBlackParent;
                    }
                    else
                    {
                        if (currentNode.Key == currentNode.RedBlackParent.LeftChildNode.Key)
                        {
                            currentNode = currentNode.RedBlackParent;
                            currentNode.RightRotate();
                        }

                        currentNode.RedBlackParent.NodeColor = Color.Black;
                        currentNode.RedBlackParent.RedBlackParent.NodeColor = Color.Red;
                        currentNode.RedBlackParent.RedBlackParent.LeftRotate();
                    }
                }
                else if (insertTreeNode.RedBlackParent.Key ==
                         insertTreeNode.RedBlackParent.RedBlackParent.LeftChildNode.Key)
                {
                    var uncleParentNode = insertTreeNode.RedBlackParent.RedBlackParent.RedBlackRightChildNode;
                    if (uncleParentNode.NodeColor == Color.Red)
                    {
                        insertTreeNode.RedBlackParent.NodeColor = Color.Black;
                        uncleParentNode.NodeColor = Color.Black;
                        currentNode.RedBlackParent.RedBlackParent.NodeColor = Color.Red;
                        currentNode = currentNode.RedBlackParent.RedBlackParent;
                    }
                    else
                    {
                        if (currentNode.Key == currentNode.RedBlackParent.RightChildNode.Key)
                        {
                            currentNode = currentNode.RedBlackParent;
                            currentNode.LeftRotate();
                        }

                        currentNode.RedBlackParent.NodeColor = Color.Black;
                        currentNode.RedBlackParent.RedBlackParent.NodeColor = Color.Red;
                        currentNode.RedBlackParent.RedBlackParent.RightRotate();
                    }
                }
            }

            var root = currentNode.GetRoot() as RedBlackTreeNode;
            if (root != null)
                root.NodeColor = Color.Black;
            return root;
        }

        public bool InsertRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, RedBlackTreeNode insertRedBlackTreeNode)
        {
            var bianryTree = redBlackTree as BinaryTreeNode;
            var insertTreeNode = insertRedBlackTreeNode as BinaryTreeNode;
            InsertBinaryTreeNode(ref bianryTree, ref insertTreeNode);
            var redBlackTreeFixed = fixRedBlackTreeAfterInsert(insertTreeNode as RedBlackTreeNode);
            return true;
        }

        public void DeleteRedBlackTreeNode(ref RedBlackTreeNode redBlackTree, int key)
        {
            if (!(TreeSearch(redBlackTree, key) is RedBlackTreeNode deletedRedBlackTreeNode)) return;
            var originalColor = deletedRedBlackTreeNode.NodeColor;
            var xPoint = deletedRedBlackTreeNode;
            if (deletedRedBlackTreeNode.LeftChildNode == null)
            {
                xPoint = deletedRedBlackTreeNode.RedBlackRightChildNode;
                deletedRedBlackTreeNode.Transplant( deletedRedBlackTreeNode.RedBlackRightChildNode);
            }
            else if (deletedRedBlackTreeNode.RightChildNode == null)
            {
                xPoint = deletedRedBlackTreeNode.RedBlackLeftChildNode;
                deletedRedBlackTreeNode.Transplant(deletedRedBlackTreeNode.LeftChildNode);
            }
            else
            {
                var behindChildNode = deletedRedBlackTreeNode.RightChildNode.TreeMinimum() as RedBlackTreeNode;
                originalColor = behindChildNode.NodeColor;
                xPoint = behindChildNode.RedBlackRightChildNode;
                if (behindChildNode.Parent.Key != deletedRedBlackTreeNode.Key)
                {
                    behindChildNode.Transplant(behindChildNode.RightChildNode);
                    behindChildNode.RightChildNode = deletedRedBlackTreeNode.RightChildNode;
                    behindChildNode.RightChildNode.Parent = behindChildNode;
                }

                deletedRedBlackTreeNode.Transplant(behindChildNode);
                behindChildNode.LeftChildNode = deletedRedBlackTreeNode.LeftChildNode;
                behindChildNode.LeftChildNode.Parent = behindChildNode;
            }

            if (originalColor == Color.Black)
            {
                fixRedBlackTreeAfterDelete(xPoint);
            }

        }

        private void fixRedBlackTreeAfterDelete(RedBlackTreeNode xPoint)
        {
            while (!xPoint.IsRoot & xPoint.NodeColor == Color.Black)
            {
                if (xPoint.RedBlackParent.RedBlackLeftChildNode.Key == xPoint.Key)
                {
                    var wPoint = xPoint.RedBlackParent.RedBlackRightChildNode;
                    if (xPoint.NodeColor == Color.Black && wPoint.NodeColor == Color.Red)
                    {
                        wPoint.NodeColor = Color.Black;
                        wPoint.RedBlackParent.NodeColor = Color.Red;
                        wPoint.RedBlackParent.LeftRotate();
                        wPoint = xPoint.RedBlackParent.RedBlackRightChildNode;
                    }
                    if (wPoint.NodeColor == Color.Black && wPoint.RedBlackLeftChildNode.NodeColor == Color.Black &&
                        wPoint.RedBlackRightChildNode.NodeColor == Color.Black)
                    {
                        wPoint.NodeColor = Color.Red;
                        xPoint = xPoint.RedBlackParent;
                    }
                    else
                    {
                        if (wPoint.RedBlackLeftChildNode.NodeColor == Color.Red &&
                            wPoint.RedBlackRightChildNode.NodeColor == Color.Black)
                        {
                            wPoint.NodeColor = Color.Red;
                            wPoint.RedBlackLeftChildNode.NodeColor = Color.Black;
                            wPoint.RightRotate();
                            wPoint = wPoint.RedBlackParent;
                        }
                        if (wPoint.NodeColor == Color.Black && wPoint.RedBlackRightChildNode.NodeColor == Color.Red)
                        {
                            wPoint.NodeColor = xPoint.RedBlackParent.NodeColor;
                            xPoint.RedBlackParent.NodeColor = Color.Black;
                            wPoint.RedBlackRightChildNode.NodeColor = Color.Black;
                            wPoint.RedBlackParent.LeftRotate();
                        }
                    }
                }
                else if (xPoint.RedBlackParent.RedBlackRightChildNode.Key == xPoint.Key)
                {
                    var wPoint = xPoint.RedBlackParent.RedBlackLeftChildNode;
                    if (xPoint.NodeColor == Color.Black && wPoint.NodeColor == Color.Red)
                    {
                        wPoint.NodeColor = Color.Black;
                        wPoint.RedBlackParent.NodeColor = Color.Red;
                        wPoint.RedBlackParent.RightRotate();
                        wPoint = xPoint.RedBlackParent.RedBlackLeftChildNode;
                    }
                    if (wPoint.NodeColor == Color.Black && wPoint.RedBlackLeftChildNode.NodeColor == Color.Black &&
                        wPoint.RedBlackRightChildNode.NodeColor == Color.Black)
                    {
                        wPoint.NodeColor = Color.Red;
                        xPoint = xPoint.RedBlackParent;
                    }
                    else
                    {
                        if (wPoint.RedBlackRightChildNode.NodeColor == Color.Red &&
                            wPoint.RedBlackLeftChildNode.NodeColor == Color.Black)
                        {
                            wPoint.NodeColor = Color.Red;
                            wPoint.RedBlackRightChildNode.NodeColor = Color.Black;
                            wPoint.LeftRotate();
                            wPoint = wPoint.RedBlackParent;
                        }
                        if (wPoint.NodeColor == Color.Black && wPoint.RedBlackLeftChildNode.NodeColor == Color.Red)
                        {
                            wPoint.NodeColor = xPoint.RedBlackParent.NodeColor;
                            xPoint.RedBlackParent.NodeColor = Color.Black;
                            wPoint.RedBlackLeftChildNode.NodeColor = Color.Black;
                            wPoint.RedBlackParent.RightRotate();
                        }
                    }
                }
            }
            xPoint.NodeColor = Color.Black;
        }
    }
}