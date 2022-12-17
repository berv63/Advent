using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent15_BeaconExclusionZoneTests
    {
        [Test]
        public void Reservoir_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var (sensorList, beaconList) = Advent2022.BeaconExclusionZone.BuildSensorModels(fileData);
            var impossible = Advent2022.BeaconExclusionZone.GetImpossibleAtYCount(sensorList, beaconList, 10);
            Assert.AreEqual(26, impossible);
        }
        
        [Test]
        public void Reservoir_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var (sensorList, beaconList) = Advent2022.BeaconExclusionZone.BuildSensorModels(fileData);
            var impossible = Advent2022.BeaconExclusionZone.GetImpossibleAtYCount(sensorList, beaconList, 2000000);
            Assert.AreNotEqual(5543957, impossible); // too high
            Assert.AreEqual(4502208, impossible);
        }
        
        [Test]
        public void ReservoirOnly_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var (sensorList, beaconList) = Advent2022.BeaconExclusionZone.BuildSensorModels(fileData);
            var (x, y) = Advent2022.BeaconExclusionZone.GetOnlyLocation(sensorList, 20);
            var value = Advent2022.BeaconExclusionZone.GetValue(x, y);
            Assert.AreEqual(56000011, value);
        }
        
        [Test]
        public void ReservoirOnly_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var (sensorList, beaconList) = Advent2022.BeaconExclusionZone.BuildSensorModels(fileData);
            var (x, y) = Advent2022.BeaconExclusionZone.GetOnlyLocation(sensorList, 4000000);
            var value = Advent2022.BeaconExclusionZone.GetValue(x, y);
            
            Assert.AreEqual(3446137, x);
            Assert.AreEqual(3204480, y);
            
            Assert.AreNotEqual(2001151616, value);
            Assert.AreNotEqual(13784555204480, value);
            Assert.AreEqual(13784551204480, value);
        }
    }
}