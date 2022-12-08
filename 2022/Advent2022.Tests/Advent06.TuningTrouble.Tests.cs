using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent06_TuningTroubleTests
    {
        [Test]
        public void TuningTrouble_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var result = Advent2022.TuningTrouble.FindUnique(fileData[0], 4);
            Assert.AreEqual(7, result);
        }
        
        [Test]
        public void TuningTrouble_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var result = Advent2022.TuningTrouble.FindUnique(fileData[0], 4);
            Assert.AreEqual(1544, result);
        }
        
        [Test]
        public void TuningTroubleLonger_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var result = Advent2022.TuningTrouble.FindUnique(fileData[0], 14);
            Assert.AreEqual(19, result);
        }
        
        [Test]
        public void TuningTroubleLonger_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var result = Advent2022.TuningTrouble.FindUnique(fileData[0], 14);
            Assert.AreEqual(2145, result);
        }
    }
}