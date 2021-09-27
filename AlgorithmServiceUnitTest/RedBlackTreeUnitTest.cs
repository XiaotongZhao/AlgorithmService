using Domain.Tree.RedBlackTree.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlgorithmServiceUnitTest
{
    public class RedBlackTreeUnitTest : IClassFixture<StartupFixture>
    {
        private readonly StartupFixture startupFixture;
        private int[] keys = new[] { 9, 7, 3, 8, 2, 6, 5, 13, 10, 11, 15, 14, 16 };

        public RedBlackTreeUnitTest(StartupFixture startupFixture)
        {
            this.startupFixture = startupFixture;
        }
        
        [Fact]
        public void TestInsertRedBlackTreeNode()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var redBlackTreeService = scope.ServiceProvider.GetService<IRedBlackTreeService>();
            if (redBlackTreeService != null)
            {
                var tree = redBlackTreeService.CreateRedBlackTree(keys);
                var root = tree.GetRoot();
            }
        }
        
        [Fact]
        public void TestRightRotate()
        {
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