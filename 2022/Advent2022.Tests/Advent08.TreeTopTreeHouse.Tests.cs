using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent08_TreeTopTreeHouseTests
    {
        [Test]
        public void TreeTopTreeHouse_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var treeCount = Advent2022.TreeTopTreeHouse.GetVisibleTreeCount(forrest);
            Assert.AreEqual(21, treeCount);
        }
        
        [Test]
        public void TreeTopTreeHouse_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var treeCount = Advent2022.TreeTopTreeHouse.GetVisibleTreeCount(forrest);
            Assert.AreNotEqual(3087, treeCount);
            Assert.AreEqual(1676, treeCount);
        }
        
        [Test]
        public void ScenicScore_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var scenicScore = Advent2022.TreeTopTreeHouse.GetScenicScore(forrest);
            Assert.AreEqual(8, scenicScore);
        }
        
        [Test]
        public void ScenicScore_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var scenicScore = Advent2022.TreeTopTreeHouse.GetScenicScore(forrest);
            Assert.AreNotEqual(31248, scenicScore);
            Assert.AreEqual(313200, scenicScore);
        }
    }
}