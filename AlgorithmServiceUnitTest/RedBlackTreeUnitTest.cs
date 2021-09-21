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
        public void TestRightRotate()
        {
            var a = 12;
            if (a > 2)
            {
            }
            else if (a > 5)
            {
            }
        }
        
        [Fact]
        public void TestLeftRotate()
        {
        }
        
        [Fact]
        public void TestInsertRedBlackTreeNode()
        {
        }
        
        [Fact]
        public void TestDeleteRedBlackTreeNode()
        {
        }
    }
}