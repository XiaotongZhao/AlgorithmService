using AlgorithmService.Domain.Tree.RedBlackTree.Model;
using AlgorithmService.Domain.Tree.RedBlackTree.Service;
using AlgorithmService.RedBlackTreeViewModel;
using System.Xml.Linq;

namespace AlgorithmService.UnitTest;

public class RedBlackTreeUnitTest : IClassFixture<StartupFixture>
{
    private readonly StartupFixture startupFixture;

    public RedBlackTreeUnitTest(StartupFixture startupFixture)
    {
        this.startupFixture = startupFixture;
    }

    [Fact]
    public void TestInsertRedBlackTreeNodeNotLeftOrRightRotate()
    {
        int[] keys = { 510, 82, 830, 11, 383, 647, 899, 261, 410, 815, 888, 972, 238, 292, 963 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        var root = tree.GetRoot();
        Assert.True(root.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.RightChildNode.LeftChildNode.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.RightChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.RightChildNode.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Red);
    }

    [Fact]
    public void TestInsertRedBlackTreeNodeWithLeftOrRightRotate()
    {
        int[] keys = { 11, 2, 14, 1, 7, 15, 5, 8, 4 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        var root = tree.GetRoot();
        Assert.True(root.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.NodeColor == Color.Red);
    }

    [Fact]
    public void TestInsertRedBlackTreeNodeWithRightOrLeftRotate()
    {
        int[] keys = { 11, 2, 18, 1, 14, 20, 13, 15, 4, 12 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        var root = tree.GetRoot();
        Assert.True(root.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Black);
        Assert.True(root.LeftChildNode.LeftChildNode.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.LeftChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.NodeColor == Color.Red);
        Assert.True(root.RightChildNode.LeftChildNode.NodeColor == Color.Black);
        Assert.True(root.RightChildNode.RightChildNode.NodeColor == Color.Black);
    }

    [Fact]
    public void TestDeleteRedBlackTreeNode()
    {
        int[] keys = { 11, 2, 14, 1, 7, 15, 5, 8, 4 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        redBlackTreeService.DeleteRedBlackTreeNode(ref tree, 1);
        var root = tree.GetRoot();
        Assert.True(root.NodeColor == Color.Black && root.Key == 7);
        Assert.True(root.LeftChildNode.NodeColor == Color.Red && root.LeftChildNode.Key == 4);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Black && root.LeftChildNode.LeftChildNode.Key == 2);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Black && root.LeftChildNode.RightChildNode.Key == 5);
        Assert.True(root.RightChildNode.NodeColor == Color.Red && root.RightChildNode.Key == 11);
        Assert.True(root.RightChildNode.LeftChildNode.NodeColor == Color.Black && root.RightChildNode.LeftChildNode.Key == 8);
        Assert.True(root.RightChildNode.RightChildNode.NodeColor == Color.Black && root.RightChildNode.RightChildNode.Key == 14);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.NodeColor == Color.Red && root.RightChildNode.RightChildNode.RightChildNode.Key == 15);
    }

    [Fact]
    public void TestDeleteRedBlackTreeNodeOtherSituation()
    {
        int[] keys = { 510, 82, 830, 11, 383, 647, 899, 261, 410, 815, 888, 972, 238, 292, 963 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        redBlackTreeService.DeleteRedBlackTreeNode(ref tree, 11);
        var root = tree.GetRoot();
        Assert.True(root.NodeColor == Color.Black && root.Key == 510);
        Assert.True(root.LeftChildNode.NodeColor == Color.Black && root.LeftChildNode.Key == 383);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Red && root.LeftChildNode.LeftChildNode.Key == 261);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Black && root.LeftChildNode.RightChildNode.Key == 410);
        Assert.True(root.LeftChildNode.LeftChildNode.LeftChildNode.NodeColor == Color.Black && root.LeftChildNode.LeftChildNode.LeftChildNode.Key == 82);
        Assert.True(root.LeftChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Black && root.LeftChildNode.LeftChildNode.RightChildNode.Key == 292);
        Assert.True(root.LeftChildNode.LeftChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Red && root.LeftChildNode.LeftChildNode.LeftChildNode.RightChildNode.Key == 238);
        Assert.True(root.RightChildNode.NodeColor == Color.Black && root.RightChildNode.Key == 830);
        Assert.True(root.RightChildNode.LeftChildNode.NodeColor == Color.Black && root.RightChildNode.LeftChildNode.Key == 647);
        Assert.True(root.RightChildNode.RightChildNode.NodeColor == Color.Red && root.RightChildNode.RightChildNode.Key == 899);
        Assert.True(root.RightChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Red && root.RightChildNode.LeftChildNode.RightChildNode.Key == 815);
        Assert.True(root.RightChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Black && root.RightChildNode.RightChildNode.LeftChildNode.Key == 888);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.NodeColor == Color.Black && root.RightChildNode.RightChildNode.RightChildNode.Key == 972);
        Assert.True(root.RightChildNode.RightChildNode.RightChildNode.LeftChildNode.NodeColor == Color.Red && root.RightChildNode.RightChildNode.RightChildNode.LeftChildNode.Key == 963);
        redBlackTreeService.DeleteRedBlackTreeNode(ref tree, 238);
        Assert.True(root.NodeColor == Color.Black && root.Key == 510);
        Assert.True(root.LeftChildNode.NodeColor == Color.Black && root.LeftChildNode.Key == 383);
        Assert.True(root.LeftChildNode.LeftChildNode.NodeColor == Color.Red && root.LeftChildNode.LeftChildNode.Key == 261);
        Assert.True(root.LeftChildNode.RightChildNode.NodeColor == Color.Black && root.LeftChildNode.RightChildNode.Key == 410);
        Assert.True(root.LeftChildNode.LeftChildNode.LeftChildNode.NodeColor == Color.Black && root.LeftChildNode.LeftChildNode.LeftChildNode.Key == 82);
        Assert.True(root.LeftChildNode.LeftChildNode.RightChildNode.NodeColor == Color.Black && root.LeftChildNode.LeftChildNode.RightChildNode.Key == 292);
    }


    [Fact]
    public void TestConvertBlackRedTreeToViewModel()
    {
        int[] keys = { 10, 6, 4, 7, 5, 17, 12, 19, 18, 20 };
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
        if (redBlackTreeService == null) return;
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        var root = tree.GetRoot();
        var redBlackTree = RedBlackTree.ConvertBlackRedTreeToViewModel(root);
        var nodes = redBlackTree.Nodes;
        var values = nodes.Select(a => a.Value).ToList();
        var res = string.Join(',', values);
        Assert.True(res == "5,4,7,6,12,18,20,19,17,10");
        var currentNode = root.FindNode(10);
        Assert.True(currentNode.NodeColor == Color.Black);
    }

}
