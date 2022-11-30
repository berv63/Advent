using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent15ChitonTests
    {
        [Test]
        public void ChitonRiskPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Practice.txt");
            var index = 0;
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), ++index)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(40, risk);
        }
        
        [Test]
        public void ChitonRiskPractice3()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Practice3.txt");
            var index = 0;
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), ++index)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(14, risk);
        }
        
        [Test]
        public void ChitonRisk()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Actual.txt");
            var index = 0;
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), ++index)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(456, risk);
        }
        
        [Test]
        public void ChitonRiskPart2Practice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Part2Practice.txt");
            var index = 0;
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), ++index)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(315, risk);
        }
        
        [Test]
        public void ChitonRiskPart2PracticeWithBuild()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Practice.txt");
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), 0)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            var index = 0;
            var riskSegments = Chiton.BuildRiskSegments(riskMap, ref index);
            riskMap = Chiton.ConvertSegments(riskSegments);
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(315, risk);
        }
        
        [Test]
        public void ChitonRiskPart2WithBuild()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent15\Actual.txt");
            var riskMap = rows.Select(x => x.Select(y => new ChitonRiskModel(int.Parse(y.ToString()), 0)).ToList()).ToList();
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            var index = 0;
            var riskSegments = Chiton.BuildRiskSegments(riskMap, ref index);
            riskMap = Chiton.ConvertSegments(riskSegments);
            riskMap = Chiton.BuildChitonRiskMap(riskMap);
            
            
            var risk = Chiton.CalculatePathRisk(riskMap, index);
            Assert.AreEqual(2831, risk);
        }
    }
}