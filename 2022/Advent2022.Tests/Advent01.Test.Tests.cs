using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent1TestTests
    {
        [Test]
        public void Advent1Practice()
        {
            var depths = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent1\Practice.txt");
            var depthsInt = depths.Select(int.Parse).ToList();
            
            var result = Advent2022.Test.Prep();
            Assert.AreEqual(1, result);
        }
    }
}