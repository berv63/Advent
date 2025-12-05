using AdventShared;
using NUnit.Framework;

namespace Advent2020.Tests
{
    [TestFixture]
    public class Advent01ReportRepairTests
    {
        [Test]
        public void Report()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent1\Practice.txt");
            
            var deeperCount = ReportRepair.GetReport();
            Assert.AreEqual(7, deeperCount);
            Assert.True(true);
        }
    }
}