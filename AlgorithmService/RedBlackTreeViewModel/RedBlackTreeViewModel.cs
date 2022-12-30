using AlgorithmService.Domain.Tree.RedBlackTree.Model;

namespace AlgorithmService.RedBlackTreeViewModel;

public static class RedBlackTree
{
    public static RedBlackTreeModel ConvertBlackRedTreeToViewModel(RedBlackTreeNode redBlackTree)
    {
        var redBlackTreeViewModel = new RedBlackTreeModel();
        var root = redBlackTree.GetRoot();
        redBlackTreeViewModel.Nodes = new List<Node>()
        {
            new Node()
            {
                Id = root.Key,
                Name = root.Key.ToString(),
                Value = root.Key,
                Category = (int)root.NodeColor
            }
        };
        var stack = new Stack<RedBlackTreeNode>();
        RedBlackTreeNode currentNode, existNode;
        currentNode = root;
        existNode = null;
        stack.Push(currentNode);
        while (stack.Count > 0 || currentNode != null)
        {
            if (currentNode != null && currentNode.LeftChildNode != null)
            {
                currentNode = currentNode.LeftChildNode;
                stack.Push(currentNode);
            }
            else
            {
                currentNode = stack.Peek();
                if (currentNode.RightChildNode != null && (existNode == null || existNode.Key != currentNode.RightChildNode.Key))
                {
                    currentNode = currentNode.RightChildNode;
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftChildNode;
                }
                else
                {
                    var node = stack.Pop();
                    redBlackTreeViewModel.Nodes.Add(new Node()
                    {
                        Id = node.Key,
                        Name = node.Key.ToString(),
                        Value = node.Key,
                        Category = (int)node.NodeColor
                    });
                    existNode = currentNode;
                    currentNode = null;
                }
            }
        }
        return redBlackTreeViewModel;
    }
}

public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int SymbolSize { get; set; } = 20;
    public int X { get; set; }
    public int Y { get; set; }
    public int Category { get; set; }
}

public class Link
{
    public int Source { get; set; }
    public int Target { get; set; }
}

public class RedBlackTreeModel
{
    public List<Node> Nodes { get; set; }
    public List<Link> Links { get; set; }
}
