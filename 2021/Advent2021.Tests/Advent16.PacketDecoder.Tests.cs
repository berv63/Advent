using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent16PacketDecoderTests
    {
        [Test]
        public void DecodePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent16\Practice.txt");

            var sum1 = PacketDecoder.GetPacketVersionSum(rows[0]);
            Assert.AreEqual(16, sum1);
            
            var sum2 = PacketDecoder.GetPacketVersionSum(rows[1]);
            Assert.AreEqual(12, sum2);
            
            var sum3 = PacketDecoder.GetPacketVersionSum(rows[2]);
            Assert.AreEqual(23, sum3);
            
            var sum4 = PacketDecoder.GetPacketVersionSum(rows[3]);
            Assert.AreEqual(31, sum4);

        }
        
        [Test]
        public void Decode()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent16\Actual.txt");
            
            var sum = PacketDecoder.GetPacketVersionSum(rows[0]);
            Assert.AreEqual(967, sum);
        }
        
        [Test]
        public void DecodePracticePart2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent16\PracticePart2.txt");

            var sum1 = PacketDecoder.GetPacketValue(rows[0]);
            Assert.AreEqual(3, sum1);
            
            var sum2 = PacketDecoder.GetPacketValue(rows[1]);
            Assert.AreEqual(54, sum2);
            
            var sum3 = PacketDecoder.GetPacketValue(rows[2]);
            Assert.AreEqual(7, sum3);
            
            var sum4 = PacketDecoder.GetPacketValue(rows[3]);
            Assert.AreEqual(9, sum4);
            
            var sum5 = PacketDecoder.GetPacketValue(rows[4]);
            Assert.AreEqual(1, sum5);
            
            var sum6 = PacketDecoder.GetPacketValue(rows[5]);
            Assert.AreEqual(0, sum6);
            
            var sum7 = PacketDecoder.GetPacketValue(rows[6]);
            Assert.AreEqual(0, sum7);
            
            var sum8 = PacketDecoder.GetPacketValue(rows[7]);
            Assert.AreEqual(1, sum8);

        }
        
        [Test]
        public void DecodePart2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent16\Actual.txt");
            
            var sum = PacketDecoder.GetPacketValue(rows[0]);
            Assert.AreEqual(12883091136209, sum);
        }
    }
}