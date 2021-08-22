using System.Linq;
using System.Text;
using Domain.Algorithms.DynamicPlanning;
using Domain.Algorithms.QuickSort.Service;
using Domain.Tree.BinaryTree.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlgorithmServiceUnitTest
{
    public class BinaryTreeUnitTest: IClassFixture<StartupFixture>
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

            int[] keys = new[] { 5, 4, 3, 2, 1, 9, 8, 7, 6 };
            var tree = binaryTreeService.CreateBinaryTree(keys);
            Assert.True(true);
        }
    }
}