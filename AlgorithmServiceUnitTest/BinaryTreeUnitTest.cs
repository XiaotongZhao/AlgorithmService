using System.Linq;
using System.Text;
using Domain.Algorithms.DynamicPlanning;
using Domain.Algorithms.QuickSort.Service;
using Domain.Tree.BinaryTree.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlgorithmServiceUnitTest
{
    public class BinaryTreeUnitTest : IClassFixture<StartupFixture>
    {
        private readonly StartupFixture startupFixture;

        public BinaryTreeUnitTest(StartupFixture startupFixture)
        {
            this.startupFixture = startupFixture;
        }

        [Fact]
        public void TestCreateBinaryTree()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var binaryTreeService = scope.ServiceProvider.GetService<IBinaryTreeService>();
            int[] keys = new[] { 9, 7, 3, 8, 2, 6, 5, 13, 10, 11, 15, 14, 16 };
            var tree = binaryTreeService.CreateBinaryTree(keys);
            var root = tree.GetRoot();
            var checkLeft = root.Key == 9
                            && root.LeftChildNode.Key == 7
                            && root.LeftChildNode.LeftChildNode.Key == 3
                            && root.LeftChildNode.RightChildNode.Key == 8
                            && root.LeftChildNode.LeftChildNode.LeftChildNode.Key == 2
                            && root.LeftChildNode.LeftChildNode.RightChildNode.Key == 6
                            && root.LeftChildNode.LeftChildNode.RightChildNode.LeftChildNode.Key == 5
                            && root.LeftChildNode.LeftChildNode.RightChildNode.RightChildNode == null;
            var checkRight = root.RightChildNode.Key == 13
                             && root.RightChildNode.LeftChildNode.Key == 10
                             && root.RightChildNode.RightChildNode.Key == 15
                             && root.RightChildNode.LeftChildNode.RightChildNode.Key == 11
                             && root.RightChildNode.RightChildNode.LeftChildNode.Key == 14
                             && root.RightChildNode.RightChildNode.RightChildNode.Key == 16;
            Assert.True(checkLeft == true && checkRight == true);
        }

        [Fact]
        public void TestDeleteLeftBinaryNode()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var binaryTreeService = scope.ServiceProvider.GetService<IBinaryTreeService>();
            int[] keys = new[] { 9, 7, 3, 8, 2, 6, 5, 12, 11, 15, 13, 14, 16 };
            var tree = binaryTreeService.CreateBinaryTree(keys);
            binaryTreeService.DeleteBinaryTreeNode(tree, 3);
            Assert.True(tree.GetRoot().LeftChildNode.LeftChildNode.Key == 5);
            Assert.True(tree.GetRoot().LeftChildNode.LeftChildNode.LeftChildNode.Key == 2);
            Assert.True(tree.GetRoot().LeftChildNode.LeftChildNode.RightChildNode.Key == 6 
                        && tree.GetRoot().LeftChildNode.LeftChildNode.RightChildNode.LeftChildNode == null
                        && tree.GetRoot().LeftChildNode.LeftChildNode.RightChildNode.RightChildNode == null);

        }
        
        [Fact]
        public void TestDeleteRightBinaryNode()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var binaryTreeService = scope.ServiceProvider.GetService<IBinaryTreeService>();
            int[] keys = new[] { 9, 7, 3, 8, 2, 6, 5, 12, 11, 15, 13, 14, 16 };
            var tree = binaryTreeService.CreateBinaryTree(keys);
            binaryTreeService.DeleteBinaryTreeNode(tree, 12);
            Assert.True(tree.GetRoot().RightChildNode.Key == 13);
        }
    }
}