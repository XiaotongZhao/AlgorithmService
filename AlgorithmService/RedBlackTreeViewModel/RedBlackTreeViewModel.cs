using AlgorithmService.Domain.Tree.RedBlackTree.Model;

namespace AlgorithmService.RedBlackTreeViewModel;

public static class RedBlackTree
{
    public static RedBlackTreeViewModel ConvertBlackRedTreeToViewModel(RedBlackTreeNode redBlackTree)
    {
        var redBlackTreeViewModel = new RedBlackTreeViewModel();
        var root = redBlackTree.GetRoot();
        redBlackTreeViewModel.Nodes.Add(new Node()
        {
            Id = root.Key,
            Name = root.Key.ToString(),
            Value = root.Key,
            Category = (int)root.NodeColor
        });
        var stack = new Stack<RedBlackTreeNode>();
        var currentNode = root;
        stack.Push(root);
        while (stack.Count > 0)
        {
            if (currentNode.LeftChildNode != null)
            {
                stack.Push(currentNode.LeftChildNode);
                currentNode = currentNode.LeftChildNode;
            }
            else if (currentNode.RightChildNode != null)
            {
                currentNode = currentNode.RightChildNode;
                stack.Push(currentNode);
            }
            else
            {
                var popNode = stack.Pop();
                currentNode = stack.Peek();
                if (stack.Any(data => data.Key == currentNode.RightChildNode.Key))
                { }
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

public class RedBlackTreeViewModel
{
    public List<Node> Nodes { get; set; }
    public List<Link> Links { get; set; }
}
