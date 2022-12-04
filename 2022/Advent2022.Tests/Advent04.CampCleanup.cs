using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent04_CampCleanupTests
    {
        [Test]
        public void Cleanup_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var cleanupPairs = Advent2022.CampCleanup.BuildCleaningPairs(fileData); 
            var result = Advent2022.CampCleanup.FullyContainedPairs(cleanupPairs);
            Assert.AreEqual(2, result);
        }
        
        [Test]
        public void Cleanup_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var cleanupPairs = Advent2022.CampCleanup.BuildCleaningPairs(fileData); 
            var result = Advent2022.CampCleanup.FullyContainedPairs(cleanupPairs);
            Assert.AreEqual(534, result);
        }
        
        [Test]
        public void CleanupOverlap_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var cleanupPairs = Advent2022.CampCleanup.BuildCleaningPairs(fileData); 
            var result = Advent2022.CampCleanup.OverlappedPairs(cleanupPairs);
            Assert.AreEqual(4, result);
        }
        
        [Test]
        public void CleanupOverlap_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var cleanupPairs = Advent2022.CampCleanup.BuildCleaningPairs(fileData); 
            var result = Advent2022.CampCleanup.OverlappedPairs(cleanupPairs);
            Assert.AreEqual(841, result);
        }
    }
}