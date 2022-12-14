using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent13_DistressSignalTests
    {
        [Test]
        public void DistressSignalPre_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var pairs = Advent2022.DistressSignal.BuildDistressPairs(fileData);
            Assert.AreEqual(true, pairs[0].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(true, pairs[1].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(false, pairs[2].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(true, pairs[3].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(false, pairs[4].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(true, pairs[5].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(false, pairs[6].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(false, pairs[7].ArePacketsInTheCorrectOrder());
            Assert.AreEqual(false, pairs[8].ArePacketsInTheCorrectOrder());
        }
        
        [Test]
        public void DistressSignal_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var pairs = Advent2022.DistressSignal.BuildDistressPairs(fileData);
            var orderedSum = Advent2022.DistressSignal.GetOrderedSum(pairs);
            Assert.AreEqual(13, orderedSum);
        }
        
        [Test]
        public void DistressSignal_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var pairs = Advent2022.DistressSignal.BuildDistressPairs(fileData);
            foreach (var pair in pairs)
            {
                pair.ArePacketsInTheCorrectOrder();
            }
            
            var orderedSum = Advent2022.DistressSignal.GetOrderedSum(pairs);
            Assert.AreNotEqual(711, orderedSum);
            Assert.AreNotEqual(5761, orderedSum);//too low
            Assert.AreNotEqual(9308, orderedSum);//too high
            Assert.AreNotEqual(6157, orderedSum);//shrug
            Assert.AreEqual(5905, orderedSum);
        }
        
        [Test]
        public void DistressSignalSort_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var packets = Advent2022.DistressSignal.BuildPackets(fileData);
            Advent2022.DistressSignal.SortPackets(packets);
            var decoder = Advent2022.DistressSignal.GetDecoderKey(packets);
            Assert.AreEqual(140, decoder);
        }
        
        [Test]
        public void DistressSignalSort_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var packets = Advent2022.DistressSignal.BuildPackets(fileData);
            Advent2022.DistressSignal.SortPackets(packets);
            var decoder = Advent2022.DistressSignal.GetDecoderKey(packets);
            Assert.AreEqual(21691, decoder);
        }
    }
}