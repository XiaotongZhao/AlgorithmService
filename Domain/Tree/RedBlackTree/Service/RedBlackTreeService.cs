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

        public void DeleteRedBlackTreeNode(RedBlackTreeNode redBlackTree, int key)
        {
            var deleteBinaryTreeNode = TreeSearch(redBlackTree, key);
            if (deleteBinaryTreeNode.LeftChildNode == null)
                deleteBinaryTreeNode.Transplant(deleteBinaryTreeNode.RightChildNode);
            else if (deleteBinaryTreeNode.RightChildNode == null)
                deleteBinaryTreeNode.Transplant(deleteBinaryTreeNode.LeftChildNode);
            else
            {
                var behindChildNode = deleteBinaryTreeNode.RightChildNode.TreeMinimum();
                if (behindChildNode.Parent.Key != deleteBinaryTreeNode.Key)
                {
                    behindChildNode.Transplant(behindChildNode.RightChildNode);
                    behindChildNode.RightChildNode = deleteBinaryTreeNode.RightChildNode;
                    behindChildNode.RightChildNode.Parent = behindChildNode;
                }

                deleteBinaryTreeNode.Transplant(behindChildNode);
                behindChildNode.LeftChildNode = deleteBinaryTreeNode.LeftChildNode;
                behindChildNode.LeftChildNode.Parent = behindChildNode;
            }
        }
    }
}