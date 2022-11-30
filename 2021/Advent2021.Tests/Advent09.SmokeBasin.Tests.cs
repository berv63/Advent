using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent9SmokeBasinTests
    {
        [Test]
        public void SmokeBasinRiskPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent9\Practice.txt");
            var heightMap = rows.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();
            
            var endCount = SmokeBasin.GetLowPointRiskSummation(heightMap);
            Assert.AreEqual(15, endCount);
        }
        
        [Test]
        public void SmokeBasinRisk()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent9\Actual.txt");
            var heightMap = rows.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();
            
            var endCount = SmokeBasin.GetLowPointRiskSummation(heightMap);
            Assert.AreEqual(439, endCount);
        }
        
        [Test]
        public void SmokeBasinSizePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent9\Practice.txt");
            var heightMap = rows.Select(x => x.Select(y => int.Parse(y.ToString()) == 9 ? 1 : 0).ToList()).ToList();
            
            var endCount = SmokeBasin.GetBasinSizeScore(heightMap);
            Assert.AreEqual(1134, endCount);
        }
        
        [Test]
        public void SmokeBasinSize()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent9\Actual.txt");
            var heightMap = rows.Select(x => x.Select(y => int.Parse(y.ToString()) == 9 ? 1 : 0).ToList()).ToList();
            
            var endCount = SmokeBasin.GetBasinSizeScore(heightMap);
            Assert.AreNotEqual(854756, endCount); //forgot to check vertical i-1 because i didnt consider being able to go back up...
            Assert.AreEqual(900900, endCount);
        }
    }
}