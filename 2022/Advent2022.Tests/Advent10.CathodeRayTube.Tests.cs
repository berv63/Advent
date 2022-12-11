using System.Linq;
using Advent2022.Models;
using Advent2022.Models.Advent10;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent10_CathodeRayTube
    {
        [Test]
        public void CathodeRay_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.CathodeRayTube.BuildCommands(fileData);
            var result = new CRTModel().GetCountAt(commands, 6);
            Assert.AreEqual(-1, result);
        }
        
        [Test]
        public void CathodeRay_Practice2()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.CathodeRayTube.BuildCommands(fileData);
            var result = Advent2022.CathodeRayTube.GetIntervals(commands);
            Assert.AreEqual(13140, result);
        }
        
        [Test]
        public void CathodeRay_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.CathodeRayTube.BuildCommands(fileData);
            var result = Advent2022.CathodeRayTube.GetIntervals(commands);
            Assert.AreEqual(14540, result);
        }
        
        
        [Test]
        public void CathodeRayScreen_Practice2()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var commands = Advent2022.CathodeRayTube.BuildCommands(fileData);
            Advent2022.CathodeRayTube.RunCRT(commands);
        }
        
        [Test]
        public void CathodeRayScreen_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.CathodeRayTube.BuildCommands(fileData);
            Advent2022.CathodeRayTube.RunCRT(commands);
        }
    }
}