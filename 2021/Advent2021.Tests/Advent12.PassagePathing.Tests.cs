using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent12PassagePathingTests
    {
        [Test]
        public void PassagePathsPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Practice.txt");
            var caves = PassagePathing.BuildPassages(rows);
            var paths = PassagePathing.CullUselessCaves(caves);

            var resultPaths = PassagePathing.GetPathCount(paths);
            Assert.AreEqual(10, resultPaths);
        }
        
        [Test]
        public void PassagePathsPractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Practice2.txt");
            var caves = PassagePathing.BuildPassages(rows);
            var paths = PassagePathing.CullUselessCaves(caves);

            var resultPaths = PassagePathing.GetPathCount(paths);
            Assert.AreEqual(19, resultPaths);
        }
        
        [Test]
        public void PassagePathsPractice3()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Practice3.txt");
            var caves = PassagePathing.BuildPassages(rows);
            var paths = PassagePathing.CullUselessCaves(caves);

            var resultPaths = PassagePathing.GetPathCount(paths);
            Assert.AreEqual(226, resultPaths);
        }
        
        [Test]
        public void PassagePaths()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Actual.txt");
            var caves = PassagePathing.BuildPassages(rows);
            var paths = PassagePathing.CullUselessCaves(caves);

            var resultPaths = PassagePathing.GetPathCount(paths);
            Assert.AreEqual(3369, resultPaths);
        }
        
        [Test]
        public void PassagePathsDupPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Practice.txt");
            var caves = PassagePathing.BuildPassages(rows);

            var resultPaths = PassagePathing.GetDupPathCount(caves);
            Assert.AreEqual(36, resultPaths);
        }
        
        [Test]
        public void PassagePathsDup()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent12\Actual.txt");
            var caves = PassagePathing.BuildPassages(rows);

            var resultPaths = PassagePathing.GetDupPathCount(caves);
            Assert.AreEqual(85883, resultPaths); //need to speed up.
        }
    }
}