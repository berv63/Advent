using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent07_NoSpaceTests
    {
        [Test]
        public void NoSpace_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var fileStructure = Advent2022.NoSpace.BuildFileStructure(fileData);
            var directorySum = Advent2022.NoSpace.GetSumOfDirectories(fileStructure, 100000);
            Assert.AreEqual(95437, directorySum);
        }
        
        [Test]
        public void NoSpace_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var fileStructure = Advent2022.NoSpace.BuildFileStructure(fileData);
            var directorySum = Advent2022.NoSpace.GetSumOfDirectories(fileStructure, 100000);
            Assert.AreEqual(1915606, directorySum);
        }
        
        [Test]
        public void FreeSpace_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var fileStructure = Advent2022.NoSpace.BuildFileStructure(fileData);
            var directorySize = Advent2022.NoSpace.FreeSpace(fileStructure, 70000000, 30000000);
            Assert.AreEqual(24933642, directorySize);
        }
        
        [Test]
        public void FreeSpace_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var fileStructure = Advent2022.NoSpace.BuildFileStructure(fileData);
            var directorySize = Advent2022.NoSpace.FreeSpace(fileStructure, 70000000, 30000000);
            Assert.AreNotEqual(7132763, directorySize);
            Assert.AreNotEqual(98780, directorySize);
            Assert.AreNotEqual(5049879, directorySize);
            Assert.AreNotEqual(27760227, directorySize);
            Assert.AreNotEqual(6835091, directorySize);
            Assert.AreEqual(5025657, directorySize);
        }
    }
}