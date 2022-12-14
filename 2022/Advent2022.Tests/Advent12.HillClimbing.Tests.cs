using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent12_HillClimbingTests
    {
        [Test]
        public void HillClimb_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var hills = Advent2022.HillClimbing.BuildHillClimbModels(fileData);
            var shortestRoute = Advent2022.HillClimbing.ClimbFromStartToEnd(hills);
            Assert.AreEqual(31, shortestRoute);
        }
        
        [Test]
        public void HillClimb_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var hills = Advent2022.HillClimbing.BuildHillClimbModels(fileData);
            var shortestRoute = Advent2022.HillClimbing.ClimbFromStartToEnd(hills);
            Assert.AreEqual(380, shortestRoute);
        }
        
        
        [Test]
        public void HillClimbAll_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var hills = Advent2022.HillClimbing.BuildHillClimbModels(fileData);
            var shortestRoute = Advent2022.HillClimbing.ClimbFromAllStartToEnd(hills);
            Assert.AreEqual(29, shortestRoute);
        }
        
        [Test]
        public void HillClimbAll_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var hills = Advent2022.HillClimbing.BuildHillClimbModels(fileData);
            var shortestRoute = Advent2022.HillClimbing.ClimbFromAllStartToEnd(hills);
            Assert.AreEqual(375, shortestRoute);
        }
    }
}