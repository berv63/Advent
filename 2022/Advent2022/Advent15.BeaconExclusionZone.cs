using Advent2022.Models.Advent15;

namespace Advent2022;

public static class BeaconExclusionZone
{
    public static (List<SensorModel>, List<BeaconModel>) BuildSensorModels(List<string> fileData)
    {
        var beaconList = new List<BeaconModel>();
        return (fileData.Select(row => new SensorModel(row, beaconList)).ToList(), beaconList);
    }
    
    public static int GetImpossibleAtYCount(List<SensorModel> sensorModels, List<BeaconModel> beaconModels, int y)
    {
        var result = new List<int>();
        foreach (var sensor in sensorModels)
        {
            result.AddRange(sensor.GetImpossibleBeaconLocations(y));
        }

        foreach (var beacon in beaconModels)
        {
            if (beacon.YCoordinate == y)
            {
                result = result.Where(x => beacon.XCoordinate != x).ToList();
            }
        }

        return result.Distinct().Count();
    }
    
    public static (int, int) GetOnlyLocation(List<SensorModel> sensorModels, int max)
    {
        for (var i = 0; i <= max; i++)
        {
            foreach (var sensor in sensorModels)
            {
                sensor.SetImpossibleBeaconLocationsForRow(i);
            }
        
            var sensorsBlockingXatY = sensorModels.Where(x => x.MinXImpossibleAtY.HasValue).OrderBy(x => x.MinXImpossibleAtY).ToList();
            var hasCoverage = sensorsBlockingXatY[0].MinXImpossibleAtY == 0;
            var sensorIndex = 0;
            while(sensorIndex < sensorsBlockingXatY.Count - 1 && hasCoverage)
            {
                if (sensorsBlockingXatY[sensorIndex].DoImpossibleLocationsFullyInclude(sensorsBlockingXatY[sensorIndex + 1]))
                {
                    sensorsBlockingXatY.RemoveAt(sensorIndex+1);
                    continue;
                }
                
                hasCoverage = hasCoverage && sensorsBlockingXatY[sensorIndex].DoImpossibleLocationsButtOrOverlap(sensorsBlockingXatY[++sensorIndex]);
            }

            if (!hasCoverage)
                return (sensorsBlockingXatY[sensorIndex].MinXImpossibleAtY.Value - 1, i);
        }

        return (-1, -1);
    }

    public static long GetValue(int x, int y)
    {
        var multiply = x * (long)4000000;
        var add = multiply + y;
        return add;
    }
}