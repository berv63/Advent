using AdventShared;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent1SonarSweepTests
    {
        [Test]
        public void SweepPractice()
        {
            var depths = FileExtensions.ReadFile(@"..\..\..\Files\Advent1\Practice.txt");
            var depthsInt = depths.Select(int.Parse).ToList();
            
            var deeperCount = Advent2021.SonarSweep.GetDeeperCount(depthsInt);
            Assert.AreEqual(7, deeperCount);
        }
        
        [Test]
        public void Sweep()
        {
            var depths = FileExtensions.ReadFile(@"..\..\..\Files\Advent1\Actual.txt");
            var depthsInt = depths.Select(int.Parse).ToList();
            
            var deeperCount = Advent2021.SonarSweep.GetDeeperCount(depthsInt);
            Assert.AreEqual(1162, deeperCount);
        }
        
        [Test]
        public void SlidingSweepPractice()
        {
            var depths = FileExtensions.ReadFile(@"..\..\..\Files\Advent1\Practice.txt");
            var depthsInt = depths.Select(int.Parse).ToList();
            
            var deeperCount = Advent2021.SonarSweep.GetSlidingDeeperCount(depthsInt);
            Assert.AreEqual(5, deeperCount);
        }
        
        [Test]
        public void SlidingSweep()
        {
            var depths = FileExtensions.ReadFile(@"..\..\..\Files\Advent1\Actual.txt");
            var depthsInt = depths.Select(int.Parse).ToList();
            
            var deeperCount = Advent2021.SonarSweep.GetSlidingDeeperCount(depthsInt);
            Assert.AreEqual(1190, deeperCount);
        }
    }
}