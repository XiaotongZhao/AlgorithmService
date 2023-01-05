using AlgorithmService.Domain.Tree.RedBlackTree.Model;

namespace AlgorithmService.RedBlackTreeViewModel;

public static class RedBlackTree
{
    public static RedBlackTreeModel ConvertBlackRedTreeToViewModel(RedBlackTreeNode redBlackTree)
    {
        var redBlackTreeViewModel = new RedBlackTreeModel();
        var root = redBlackTree.GetRoot();
        redBlackTreeViewModel.Nodes = new List<Node>();
        redBlackTreeViewModel.Links= new List<Link>();
        redBlackTreeViewModel.DicKeyAndId = new Dictionary<int, int>();
        var stack = new Stack<RedBlackTreeNode>();
        RedBlackTreeNode currentNode, existNode;
        currentNode = root;
        existNode = null;
        stack.Push(currentNode);
        int id = 0;
        while (stack.Count > 0 || currentNode != null)
        {
            if (currentNode != null && currentNode.LeftChildNode.Key > 0 && currentNode.LeftChildNode != null)
            {
                currentNode = currentNode.LeftChildNode;
                stack.Push(currentNode);
            }
            else
            {
                currentNode = stack.Peek();
                if (currentNode.RightChildNode != null && currentNode.RightChildNode.Key > 0 && (existNode == null || existNode.Key != currentNode.RightChildNode.Key))
                {
                    currentNode = currentNode.RightChildNode;
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftChildNode.Key > 0 ? currentNode.LeftChildNode : null;
                    if(currentNode != null)
                        stack.Push(currentNode);
                }
                else
                {
                    var node = stack.Pop();
                    redBlackTreeViewModel.Nodes.Add(new Node()
                    {
                        Id = id++,
                        Name = node.Key.ToString(),
                        Value = node.Key,
                        Category = (int)node.NodeColor
                    });
                    redBlackTreeViewModel.DicKeyAndId.Add(node.Key, id);
                    if (node.LeftChildNode.Key > 0)
                    {
                        redBlackTreeViewModel.Links.Add(new Link() 
                        {
                            Source = node.Key,
                            Target = node.LeftChildNode.Key
                        });
                    }
                    if (node.RightChildNode.Key > 0)
                    {
                        redBlackTreeViewModel.Links.Add(new Link()
                        {
                            Source = node.Key,
                            Target = node.RightChildNode.Key
                        });
                    }

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
    public Dictionary<int, int> DicKeyAndId { get; set; }
}
