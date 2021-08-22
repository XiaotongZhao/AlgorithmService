using Domain.Tree.BinaryTree.Model;

namespace Domain.Tree.BinaryTree.Service
{
    public class BinaryTreeService : IBinaryTreeService
    {
        public BinaryTreeNode TreeSearch(BinaryTreeNode binaryTreeNode, int key)
        {
            var currentKey = binaryTreeNode.Key;
            if (key == currentKey)
                return binaryTreeNode;
            else if (key < currentKey)
                return TreeSearch(binaryTreeNode.LeftChildNode, key);
            else
                return TreeSearch(binaryTreeNode.RightChildNode, key);
        }

        public BinaryTreeNode IterActiveTreeSearch(BinaryTreeNode binaryTreeNode, int key)
        {
            while (binaryTreeNode != null && binaryTreeNode.Key != key)
            {
                binaryTreeNode = key < binaryTreeNode.Key
                    ? binaryTreeNode.LeftChildNode
                    : binaryTreeNode.RightChildNode;
            }

            return binaryTreeNode;
        }

        private void transplant(BinaryTreeNode deleteBinaryTreeNode, BinaryTreeNode childNode)
        {
            if (deleteBinaryTreeNode.Parent == null)
                childNode.IsRoot = true;
            else if (deleteBinaryTreeNode.Parent.LeftChildNode.Key == deleteBinaryTreeNode.Key)
                deleteBinaryTreeNode.Parent.LeftChildNode = childNode;
            else
                deleteBinaryTreeNode.Parent.RightChildNode = childNode;
            if (childNode != null)
                childNode.Parent = deleteBinaryTreeNode.Parent;
        }

        public bool DeleteBinaryTreeNode(BinaryTreeNode tree, int key)
        {
            var deleteBinaryTreeNode = TreeSearch(tree, key);
            if (deleteBinaryTreeNode.LeftChildNode == null)
                transplant(deleteBinaryTreeNode, deleteBinaryTreeNode.RightChildNode);
            else if (deleteBinaryTreeNode.RightChildNode == null)
                transplant(deleteBinaryTreeNode, deleteBinaryTreeNode.LeftChildNode);
            else
            {
                var behindChildNode = deleteBinaryTreeNode.RightChildNode.TreeMinimum();
                transplant(deleteBinaryTreeNode, behindChildNode);
                if (behindChildNode.RightChildNode != null)
                {
                    var behindChildNodeOfRightChild = behindChildNode.RightChildNode;
                    behindChildNode.Parent.LeftChildNode = behindChildNodeOfRightChild;
                    behindChildNodeOfRightChild.Parent = behindChildNode.Parent;
                }
            }
            return true;
        }
        
        public void InsertBinaryTreeNode(ref BinaryTreeNode tree, BinaryTreeNode insertNode)
        {
            if (tree == null)
            {
                insertNode.IsRoot = true;
                tree = insertNode;
            }
            else
            {
                var currentNode = (BinaryTreeNode)tree.GetRoot();
                BinaryTreeNode tempTreeNode = null;
                while (currentNode != null)
                {
                    tempTreeNode = currentNode;
                    currentNode = currentNode.Key > insertNode.Key ? currentNode.LeftChildNode : currentNode.RightChildNode;
                }

                if (tempTreeNode != null)
                {
                    currentNode = tempTreeNode;
                    if (currentNode.Key > insertNode.Key)
                        currentNode.LeftChildNode = insertNode;
                    else
                        currentNode.RightChildNode = insertNode;
                    insertNode.Parent = currentNode;
                }
            }
        }

        public BinaryTreeNode CreateBinaryTree(int[] keys)
        {
            BinaryTreeNode tree = null;
            for (int i = 0; i < keys.Length; i++)
            {
                var binaryNode = new BinaryTreeNode()
                {
                    Key = keys[i]
                };
                InsertBinaryTreeNode(ref tree, binaryNode);
            }
            return tree;
        }
    }
}