using System.Diagnostics;
using Domain.Tree.RedBlackTree.Model;
using Domain.Tree.RedBlackTree.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlgorithmServiceUnitTest
{
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
        public void TestLeftRotate()
        {
        }

        [Fact]
        public void TestDeleteRedBlackTreeNode()
        {
        }
    }
}