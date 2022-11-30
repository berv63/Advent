using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent5HydrothermalVentureTests
    {
        [Test]
        public void HydroPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent5\Practice.txt");
            var directions = rows.Select(x => new HydroDirectionModel(x)).ToList();
            
            var dangerCount = HydrothermalVenture.GetDangerCount(directions, true);
            Assert.AreEqual(5, dangerCount);
        }
        
        [Test]
        public void Hydro()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent5\Actual.txt");
            var directions = rows.Select(x => new HydroDirectionModel(x)).ToList();
            
            var dangerCount = HydrothermalVenture.GetDangerCount(directions, true);
            Assert.AreEqual(6548, dangerCount);;
        }
        
        [Test]
        public void HydroDiagonalPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent5\Practice.txt");
            var directions = rows.Select(x => new HydroDirectionModel(x)).ToList();
            
            var dangerCount = HydrothermalVenture.GetDangerCount(directions, false);
            Assert.AreEqual(12, dangerCount);
        }
        
        [Test]
        public void HydroDiagonal()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent5\Actual.txt");
            var directions = rows.Select(x => new HydroDirectionModel(x)).ToList();
            
            var dangerCount = HydrothermalVenture.GetDangerCount(directions, false);
            Assert.AreEqual(19663, dangerCount);;
        }
    }
}