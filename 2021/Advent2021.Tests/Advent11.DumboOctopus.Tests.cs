using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent11DumboOctopusTests
    {
        [Test]
        public void OctopusPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent11\Practice.txt");
            var octopusMap = rows.Select(x => x.Select(y => new DumboOctopusModel(y)).ToList()).ToList();
            
            var endCount = DumboOctopus.GetFlashCount(octopusMap, 100);
            Assert.AreEqual(1656, endCount);
        }
        
        [Test]
        public void Octopus()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent11\Actual.txt");
            var octopusMap = rows.Select(x => x.Select(y => new DumboOctopusModel(y)).ToList()).ToList();
            
            var endCount = DumboOctopus.GetFlashCount(octopusMap, 100);
            Assert.AreEqual(1688, endCount);
        }
        
        [Test]
        public void OctopusSimultaneousPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent11\Practice.txt");
            var octopusMap = rows.Select(x => x.Select(y => new DumboOctopusModel(y)).ToList()).ToList();
            
            var endCount = DumboOctopus.AllFlashedStep(octopusMap, 100);
            Assert.AreEqual(195, endCount);
        }
        
        [Test]
        public void OctopusSimultaneous()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent11\Actual.txt");
            var octopusMap = rows.Select(x => x.Select(y => new DumboOctopusModel(y)).ToList()).ToList();
            
            var endCount = DumboOctopus.AllFlashedStep(octopusMap, 100);
            Assert.AreEqual(403, endCount);
        }
    }
}