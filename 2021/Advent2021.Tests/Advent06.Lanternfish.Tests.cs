using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent6LanternfishTests
    {
        [Test]
        public void FishCountPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent6\Practice.txt");
            var fish = rows[0].Split(',').Select(x => new LanternfishModel(int.Parse(x), 1)).ToList();
            
            var endCount = Lanternfish.SpawnLanternfish(fish, 18);
            Assert.AreEqual(26, endCount);
        }
        
        [Test]
        public void FishCountPractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent6\Practice.txt");
            var fish = rows[0].Split(',').Select(x => new LanternfishModel(int.Parse(x), 1)).ToList();
            
            var endCount = Lanternfish.SpawnLanternfish(fish, 80);
            Assert.AreEqual(5934, endCount);
        }
        
        [Test]
        public void FishCount()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent6\Actual.txt");
            var fish = rows[0].Split(',').Select(x => new LanternfishModel(int.Parse(x), 1)).ToList();
            
            var endCount = Lanternfish.SpawnLanternfish(fish, 80);
            Assert.AreEqual(386755, endCount);
        }
        
        [Test]
        public void AgelessFishCountPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent6\Practice.txt");
            var fish = rows[0].Split(',').Select(x => new LanternfishModel(int.Parse(x), 1)).ToList();
            
            var endCount = Lanternfish.SpawnLanternfish(fish, 256);
            Assert.AreEqual(26984457539, endCount);
        }
        
        [Test]
        public void AgelessFishCount()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent6\Actual.txt");
            var fish = rows[0].Split(',').Select(x => new LanternfishModel(int.Parse(x), 1)).ToList();
            
            var endCount = Lanternfish.SpawnLanternfish(fish, 256);
            Assert.AreEqual(1732731810807, endCount);
        }
    }
}