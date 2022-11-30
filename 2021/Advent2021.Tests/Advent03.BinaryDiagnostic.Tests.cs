using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent3BinaryDiagnosticTests
    {
        [Test]
        public void BinaryDiagnosticPractice()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Practice.txt");

            var powerConsumption = BinaryDiagnostic.GetPowerConsumption(diags);
            Assert.AreEqual(198, powerConsumption);
        }
        
        [Test]
        public void Diag()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Actual.txt");

            var powerConsumption = BinaryDiagnostic.GetPowerConsumption(diags);
            Assert.AreEqual(3969000, powerConsumption);
        }
        
        [Test]
        public void OxygenPractice()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Practice.txt");

            var lifeSupport = BinaryDiagnostic.GetOValues(diags, true);
            Assert.AreEqual(23, lifeSupport.ToDecimal());
        }
        
        [Test]
        public void Co2Practice()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Practice.txt");

            var lifeSupport = BinaryDiagnostic.GetOValues(diags, false);
            Assert.AreEqual(10, lifeSupport.ToDecimal());
        }
        
        [Test]
        public void LifeSupportPractice()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Practice.txt");

            var lifeSupport = BinaryDiagnostic.GetLifeSupportRating(diags);
            Assert.AreEqual(230, lifeSupport);
        }
        
        [Test]
        public void LifeSupport()
        {
            var diags = FileExtensions.ReadFile(@"..\..\..\Files\Advent3\Actual.txt");

            var powerConsumption = BinaryDiagnostic.GetLifeSupportRating(diags);
            Assert.AreEqual(4267809, powerConsumption);
        }
    }
}